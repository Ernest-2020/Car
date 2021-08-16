using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleViewBase : MonoBehaviour
{
    private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1D-qlYG2kPASukrXMFaVTBgLpOD-Acj6p";
    private const string UrlAssetBundleAudio = "https://drive.google.com/uc?export=download&id=1oCiD5Yffbn3bBQjQrIPguJZ2wI48uEtF";


    [SerializeField]
    private DataAudioBundle[] _dataAudioBundle;

    [SerializeField]
    private DataSpriteBundle[] _dataSpriteBundle;

   
    private AssetBundle _spritesAssetBundle;
    private AssetBundle _audioAssetBundle;

    protected IEnumerator DownloadAndSetAssetBundle()
    {
        yield return GetSpritesAssetBundle();
        yield return GetAudioAssetBundle();

        if (_spritesAssetBundle == null || _audioAssetBundle == null)
        {
            Debug.LogError("Not download asset bundle");
            yield break;
        }

        SetDownloadAsset();

        yield return null;
    }

    private IEnumerator GetSpritesAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        StateRequest(request, ref _spritesAssetBundle);
    }

    private IEnumerator GetAudioAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleAudio);

        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        StateRequest(request, ref _audioAssetBundle);
    }

    private void StateRequest(UnityWebRequest request, ref AssetBundle assetBundle)
    {
        if (request.error == null)
        {
            assetBundle = DownloadHandlerAssetBundle.GetContent(request);
            Debug.Log("Complete download asset bundle");
        }
        else
        {
            Debug.Log($"{request.error}");
        }
    }

    private void SetDownloadAsset()
    {
        foreach (var data in _dataSpriteBundle)
            data.Image.sprite = _spritesAssetBundle.LoadAsset<Sprite>(data.NameAssetBundle);


        foreach (var data in _dataAudioBundle)
        {
            data.AudioSource.clip = _spritesAssetBundle.LoadAsset<AudioClip>(data.NameAssetBundle);
            data.AudioSource.Play();
        }
    }
}
