using Profile;
using System.Collections.Generic;
using UnityEngine;


public class Root : MonoBehaviour
{
    [SerializeField] 
    private Transform _placeForUi;

    [SerializeField]
    private DailyRewardView _dailyRewardView;

    [SerializeField]
    private CurrencyView _currencyView;

    [SerializeField]
    private StartFightView _startFightView;

    [SerializeField]
    private FightWindowView _fightWindowView;

    [SerializeField]
    private UnityAdsTools _unityAdsTools;

    [SerializeField]
    private List<ItemConfig> _itemConfigs;

    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer, _fightWindowView,
            _startFightView,_dailyRewardView,_currencyView);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
