using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimationLoader : MonoBehaviour
{
    //this Script is to load animations from local Resource folder
    // Start is called before the first frame update

    Animation anim;
    private void Awake()
    {
      

    }
    void Start()
    {
        /* ModelImporter model_imp = AssetImporter.GetAtPath("Assets/Spider.fbx") as ModelImporter;
         foreach (var anim_clip in model_imp.clipAnimations)
         {
             Debug.Log(anim_clip.name);
         }*/
        //gameObject.AddComponent<Animation>();
        /*GameObject anim= AssetDatabase.LoadAssetAtPath("Assets/Spider.fbx", typeof(GameObject)) as GameObject;
        AnimationClip[] clips = AnimationUtility.GetAnimationClips(anim);
        // var clips =Resources.FindObjectsOfTypeAll<AnimationClip>();
        foreach (var c in clips)
        {
            Debug.Log(c.name);
        }
        */
       /* var modelImporter = assetImporter as ModelImporter;
        if (modelImporter == null)
        {
            Debug.LogError("Error during import of models: ModelImporter is null");
            return;
        }*/

        ModelImporter MI = (ModelImporter)AssetImporter.GetAtPath("Assets/Spider.fbx");
        var skinObj = AssetDatabase.LoadAssetAtPath<Object>(MI.assetPath);
        var prefabInstance = (GameObject)GameObject.Instantiate(skinObj);
        if (prefabInstance == null)
        {
            Debug.LogError("Failed to initialize prefab " + skinObj);
            return;
        }
        else
        {
            //anim= prefabInstance.AddComponent<Animation>();
        }
        ModelImporterClipAnimation[] clips = MI.defaultClipAnimations;
        foreach (ModelImporterClipAnimation c in clips)
        {
            Debug.Log(c.name);
            c.loopTime = true;
                      
        }
        MI.clipAnimations = clips;
        AssetDatabase.ImportAsset(MI.assetPath);

        // or get animation Clip
        Object[] objects = AssetDatabase.LoadAllAssetsAtPath(MI.assetPath);
        foreach (Object obj in objects)
        {
            AnimationClip clip = obj as AnimationClip;
            if (clip != null)
            {
                anim.AddClip(clip,obj.name);
            }
        }
    }
}

   
