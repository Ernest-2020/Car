using Profile;
using UnityEngine;
using UnityEngine.Advertisements;

public class MainMenuController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/mainMenu"};
    private readonly ProfilePlayer _profilePlayer;
    private readonly MainMenuView _view;

    public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _view = LoadView(placeForUi);
        _view.Init(StartGame);
    }
    
    private MainMenuView LoadView(Transform placeForUi)
    {
        var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObjects(objectView);
        
        return objectView.GetComponent<MainMenuView>();
    }

    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
        _profilePlayer.AnaliticsTools.SendMessage("start_game", ("time", Time.realtimeSinceStartup));
        _profilePlayer.AdsShower.ShowRewardedVideo();
        Advertisement.AddListener(_profilePlayer.AdsListener);
    }
    protected override void OnDispose()
    {
        Advertisement.RemoveListener(_profilePlayer.AdsListener);
    }
}

