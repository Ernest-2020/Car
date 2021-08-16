using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] 
    private Button _buttonStart;

    [SerializeField]
    private Button _buttonReward;

    [SerializeField]
    private Button _buttonExit;

    [SerializeField]
    private Button _buttonEnglish;

    [SerializeField]
    private Button _buttonRussian;

    public void Init(UnityAction startGame, UnityAction dailyReward)
    {
        _buttonStart.onClick.AddListener(startGame);
        _buttonReward.onClick.AddListener(dailyReward);
        _buttonExit.onClick.AddListener(ExitGame);
        _buttonEnglish.onClick.AddListener(() => ChangeLocale(1));
        _buttonRussian.onClick.AddListener(() => ChangeLocale(0));
    }

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
        _buttonReward.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();
        _buttonRussian.onClick.RemoveAllListeners();
        _buttonEnglish.onClick.RemoveAllListeners();


    }
    private void ExitGame()
    {
        Application.Quit();
    }

    private void ChangeLocale(int indexLocale)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[indexLocale];
    }
}

