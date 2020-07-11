using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimationLoader : MonoBehaviour
{
    //this Script is to load animations from local Resource folder
    // Start is called before the first frame update

    Animation anim;
    public string url;
    private void Awake()
    {
      

    }
    void Start()
    {
        ModelImporter MI = (ModelImporter)AssetImporter.GetAtPath(url);
        var skinObj = AssetDatabase.LoadAssetAtPath<Object>(MI.assetPath);
        var prefabInstance = (GameObject)GameObject.Instantiate(skinObj);
         if (prefabInstance == null)
            {
            Debug.LogError("Failed to initialize prefab " + skinObj);
            return;
            }
        else
            {
            if (prefabInstance.GetComponent<Animation>())
            {
                anim = prefabInstance.GetComponent<Animation>();
            }
            else
            {
                anim = prefabInstance.AddComponent<Animation>();
                anim = prefabInstance.GetComponent<Animation>();

            }
           
        }
       Object[] objects = AssetDatabase.LoadAllAssetsAtPath(skinObj.name);
        foreach (Object obj in objects)
        {
            AnimationClip clip = obj as AnimationClip;
            if (clip != null)
            {
                  
                    anim.AddClip(clip, obj.name);
               
            }
                
                
            
        }
    }
}

   
