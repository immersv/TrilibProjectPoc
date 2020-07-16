using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GetAssetBundle : MonoBehaviour
{
    
    public string url;
    public bool mclearCache = false;
    private void Awake()
    {
        Caching.compressionEnabled = false;
        if (mclearCache)
            Caching.ClearCache();

    }
    void Start()
    {
        StartCoroutine(GetAssetbundle(url));
    }
    /*public string[] tempObjects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObjects = bundle.GetAllAssetNames();

        }
    }*/
    

    public List<Transform> childs;

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
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            Debug.Log("Sucessfull Downloaded Asset Bundle");
            GameObject gm = Instantiate(bundle.LoadAsset("xlzbctemplate1")) as GameObject;
            childs = GetAllObjectsAndComponents.GetAllChildren(gm.transform, null);
           // Transform[] arrayOfGameObjects = childs.ToArray();
          // FindGameObjectsChildrenByTag( arrayOfGameObjects);
        }

    }
    void FindGameObjectsChildrenByTag( Transform[] gameobjectArray)
    {
        GameObject[] go =new GameObject[gameobjectArray.Length];

        
            for (int i = 0; i < gameobjectArray.Length; i++)
            {
                
                go[i].transform.name = gameobjectArray[i].name.ToString();
                Debug.Log("Game Object Name :" + go[i].name);
            }
        


    }
}
public static class GetAllObjectsAndComponents
{
    
    public static List<Transform> GetAllChildren(this Transform parent, List<Transform> transformList = null)
    {
        if (transformList == null)
            transformList = new List<Transform>();

        foreach (Transform child in parent)
        {
            transformList.Add(child);
            child.GetAllChildren(transformList);
            Debug.Log("Game object Name: " + child.name);
           
            Component[] components = child.GetComponents(typeof(Component));
            
            foreach (Component component in components)
            {
                Debug.Log("Component Names: "+component.ToString());
                string name = "Text";
                if (child.name == name)
                {
                    Text txt = child.GetComponent<Text>();
                    txt.text = "Anil";
                    Debug.Log("Replaced Text Name: " + txt.text);
                }
            }
            

        }
        return transformList;

    }
}
