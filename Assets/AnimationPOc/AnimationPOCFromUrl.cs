using System.Collections;
using System.Collections.Generic;
using TriLib;
using UnityEngine;
using UnityEngine.Networking;

public class AnimationPOCFromUrl : MonoBehaviour
{
    // this script allow users to download animation in 3d model from url

    public string url,extension;
    

    private void Awake()
    {
        gameObject.AddComponent<AssetDownloader>();
    }
    // Start is called before the first frame update
    void Start()
    {
        var assetDownloader = GetComponent<AssetDownloader>();
        assetDownloader.DownloadAsset(url, extension,null,null,null,null,null);
        
    }
   
}
