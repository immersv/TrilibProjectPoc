using System.Collections;
using System.Collections.Generic;
using TriLib;
using TriLib.Samples;
using UnityEngine;
using UnityEngine.Networking;

public class AnimationPOCFromUrl : MonoBehaviour
{
    // this script allow users to download animation in 3d model from url

    public string url,extension;

    [SerializeField]
    private UnityEngine.UI.Text _animationsText;

    [SerializeField]
    private UnityEngine.UI.ScrollRect _animationsScrollRect;

    private GameObject _rootGameObject;

    [SerializeField]
    private Transform _containerTransform;

    [SerializeField]
    private AnimationText _animationTextPrefab;

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
    public void HandleEvent(string animationName)
    {
        _rootGameObject.GetComponent<Animation>().Play(animationName);
       
    }
    private void CreateItem(string text)
    {
        var instantiated = Instantiate(_animationTextPrefab, _containerTransform);
        instantiated.Text = text;
    }
    private void PostLoadSetup()
    {
        var mainCamera = Camera.main;
        mainCamera.FitToBounds(_rootGameObject.transform, 3f);

        var rootAnimation = _rootGameObject.GetComponent<Animation>();
        if (rootAnimation != null)
        {
            _animationsText.gameObject.SetActive(true);
            _animationsScrollRect.gameObject.SetActive(true);

            foreach (AnimationState animationState in rootAnimation)
            {
                CreateItem(animationState.name);
            }
        }
    }

    }
