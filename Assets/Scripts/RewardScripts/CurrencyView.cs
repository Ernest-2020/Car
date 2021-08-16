using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    private const string WoodKey = nameof(WoodKey);
    private const string DiamondKey = nameof(DiamondKey);
    private const string MetallKey = nameof(MetallKey);
    private const string CoinKey = nameof(CoinKey);
    private const string FoodKey = nameof(FoodKey);

    public static CurrencyView Instance;

    [SerializeField]
    private TMP_Text _currentCountWood;
    
    [SerializeField] 
    private TMP_Text _currentCountDiamond;

    [SerializeField]
    private TMP_Text _currentCountMetall;

    [SerializeField]
    private TMP_Text _currentCountCoin;

    [SerializeField]
    private TMP_Text _currentCountFood;

    private int Wood
    {
        get => PlayerPrefs.GetInt(WoodKey, 0);
        set => PlayerPrefs.SetInt(WoodKey, value);
    }

    private int Diamonds
    {
        get => PlayerPrefs.GetInt(DiamondKey, 0);
        set => PlayerPrefs.SetInt(DiamondKey, value);
    }

    private int Metall
    {
        get => PlayerPrefs.GetInt(MetallKey, 0);
        set => PlayerPrefs.SetInt(MetallKey, value);
    }

    private int Coin
    {
        get => PlayerPrefs.GetInt(CoinKey, 0);
        set => PlayerPrefs.SetInt(CoinKey, value);
    }

    private int Food
    {
        get => PlayerPrefs.GetInt(FoodKey, 0);
        set => PlayerPrefs.SetInt(FoodKey, value);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RefreshText();
    }

    public void AddWood(int value)
    {
        Wood += value;

        RefreshText();
    }
    
    public void AddDiamonds(int value)
    {
        Diamonds += value;
        
        RefreshText();
    }

    public void AddMetall(int value)
    {
        Metall += value;

        RefreshText();
    }

    public void AddCoin(int value)
    {
        Coin += value;

        RefreshText();
    }

    public void AddFood(int value)
    {
        Food += value;

        RefreshText();
    }

    private void RefreshText()
    {
        _currentCountWood.text = Wood.ToString();
        _currentCountDiamond.text = Diamonds.ToString();
        _currentCountMetall.text = Metall.ToString();
        _currentCountCoin.text = Coin.ToString();
        _currentCountFood.text = Food.ToString();
    }
}
