using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimationLoader : MonoBehaviour
{
    //this Script is to load animations from local Resource folder
    // Start is called before the first frame update
   
    
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
        ModelImporter MI = (ModelImporter)Instantiate(AssetImporter.GetAtPath("Assets/Spider.fbx"));
        ModelImporterClipAnimation[] clips = MI.defaultClipAnimations;
        foreach (var c in clips)
        {
            Debug.Log(c.name);
        }
    }
}

   
