using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class LoadAssetView : AssetBundleViewBase
{
    [SerializeField]
    private AssetReference _loadPrefab;

    [SerializeField]
    private RectTransform _mountRoot;

    [SerializeField]
    private Button _spawnPrefabButton;

    [SerializeField]
    private Button _buttonAssetLoad;

    private List<AsyncOperationHandle<GameObject>> _addresablePrefab = new List<AsyncOperationHandle<GameObject>>();

    private void Start()
    {
        _buttonAssetLoad.onClick.AddListener(AssetLoad);
        _spawnPrefabButton.onClick.AddListener(CreateAddresablePrefab);
    }

    
    private void OnDestroy()
    {
        _buttonAssetLoad.onClick.RemoveAllListeners();
        _spawnPrefabButton.onClick.RemoveAllListeners();

        foreach (var addresablePrefab in _addresablePrefab)
        {
            Addressables.ReleaseInstance(addresablePrefab);
        }
    }
    private void AssetLoad()
    {
        _buttonAssetLoad.interactable = false;
        StartCoroutine(DownloadAndSetAssetBundle());
    }
    private void CreateAddresablePrefab()
    {
        var addressablePrefab = Addressables.InstantiateAsync(_loadPrefab,_mountRoot);
        _addresablePrefab.Add(addressablePrefab);
    }
}
