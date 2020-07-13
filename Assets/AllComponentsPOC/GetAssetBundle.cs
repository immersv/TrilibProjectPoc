using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class GetAssetBundle : MonoBehaviour
{
    AssetBundle bundle;
    public string url;
    void Start()
    {
        StartCoroutine(GetAssetbundle(url));
    }
    public string[] tempObjects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObjects = bundle.GetAllAssetNames();

        }
    }
    //  public Transform[] allgameObjects;
    public List<GameObject> allgameObjects;
   // public List<GameObject> allchildgameObjects;
    IEnumerator GetAssetbundle(string uri)
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(uri);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            bundle = DownloadHandlerAssetBundle.GetContent(www);
            Debug.Log("Sucessfull");
            GameObject gm=Instantiate(bundle.LoadAsset("xlzbctemplate1")) as GameObject;
           
            foreach(Transform c in gm.transform)
            {
                if (c != null)
                {
                    allgameObjects.Add(c.gameObject);
                    Debug.Log("All GameObjectNames " + c.gameObject.name);
                    if (c.gameObject != null)
                    {
                        foreach (Transform c1 in c.transform)
                        {
                            allgameObjects.Add(c1.gameObject);
                            Debug.Log("All Child GameObjectNames " + c1.gameObject.name);
                            if (c1.gameObject != null)
                             {
                                 foreach(Transform c2 in c1.transform)
                                 {
                                     allgameObjects.Add(c2.gameObject);
                                     Debug.Log("All Child in child GameObjectNames " + c2.gameObject.name);
                                 }
                             }
                        }

                    }
                }
                
                
                 
                
            }
           
        }
    }
}
