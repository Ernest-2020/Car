using Profile;
using System.Collections.Generic;
using UnityEngine;

public class MainController : BaseController
{
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<ItemConfig> itemsConfigs)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        _itemsConfigs = itemsConfigs;

        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private InvetoryController _invetoryController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private readonly List<ItemConfig> _itemsConfigs;

    protected override void OnDispose()
    {
        Allclear();

        _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        base.OnDispose();
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                break;
            case GameState.Game:
                _invetoryController = new InvetoryController(_itemsConfigs);
                _invetoryController.SowInventory();

                _gameController = new GameController(_profilePlayer);
                _mainMenuController?.Dispose();
                break;
            default:
                Allclear();
                break;
        }
    }

    private void Allclear()
    {
        _invetoryController.Dispose();
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
    }
}
