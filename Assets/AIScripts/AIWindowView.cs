using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AIWindowView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _countMoneyText;

    [SerializeField]
    private TMP_Text _countPowerText;

    [SerializeField]
    private TMP_Text _countHealthText;
    
    [SerializeField]
    private TMP_Text _countCrimeText;

    [SerializeField]
    private TMP_Text _countPowerEnemyText;

    [SerializeField]
    private Button _addMoneyButton;

    [SerializeField]
    private Button _minusMoneyButton;

    [SerializeField]
    private Button _addPowerButton;

    [SerializeField]
    private Button _minusPowerButton;

    [SerializeField]
    private Button _addHealthButton;

    [SerializeField]
    private Button _minusHealthButton;

    [SerializeField]
    private Button _fightButton;

    [SerializeField]
    private Button _addCrimeButton;
    
    [SerializeField]
    private Button _minusCrimeButton;

    [SerializeField]
    private GameObject _noFigt;

    [SerializeField]
    private Button _noFighBotton;

    private int _allCountMoney;
    private int _allCountPower;
    private int _allCountHealth;
    private int _allCountCrime;

    private Enemy _enemy;

    private Money _money;
    private Power _power;
    private Health _health;
    private Crime _crime;

    private void Start()
    {
        _enemy = new Enemy("Car");

        _money = new Money(nameof(Money));
        _money.Attach(_enemy);

        _power = new Power(nameof(Power));
        _power.Attach(_enemy);

        _health = new Health(nameof(Health));
        _health.Attach(_enemy);
        
        _crime = new Crime(nameof(Crime));
        _crime.Attach(_enemy);

        _addMoneyButton.onClick.AddListener(() => ChangeMoney(true));
        _minusMoneyButton.onClick.AddListener(() => ChangeMoney(false));

        _addPowerButton.onClick.AddListener(() => ChangePower(true));
        _minusPowerButton.onClick.AddListener(() => ChangePower(false));

        _addHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _minusHealthButton.onClick.AddListener(() => ChangeHealth(false));
        
        _addCrimeButton.onClick.AddListener(() => ChangeCrime(true));
        _minusCrimeButton.onClick.AddListener(() => ChangeCrime(false));

        _fightButton.onClick.AddListener(Fight);
        _noFighBotton.onClick.AddListener(NoFight);
    }   

    private void OnDestroy()
    {
        _addMoneyButton.onClick.RemoveAllListeners();
        _minusMoneyButton.onClick.RemoveAllListeners();

        _addPowerButton.onClick.RemoveAllListeners();
        _minusPowerButton.onClick.RemoveAllListeners();

        _addHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();

        _addCrimeButton.onClick.RemoveAllListeners();
        _minusCrimeButton.onClick.RemoveAllListeners();

        _fightButton.onClick.RemoveAllListeners();
        _noFighBotton.onClick.RemoveAllListeners();

        _money.Detach(_enemy);
        _power.Detach(_enemy);
        _health.Detach(_enemy);
        _crime.Detach(_enemy);
    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
            _allCountMoney++;
        else
            _allCountMoney--;

        ChangeDataWindow(_allCountMoney, DataType.Money);
    }

    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            _allCountPower++;
        else
            _allCountPower--;

        ChangeDataWindow(_allCountPower, DataType.Power);
    }

    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
            _allCountHealth++;
        else
            _allCountHealth--;

        ChangeDataWindow(_allCountHealth, DataType.Health);
    }
    private void ChangeCrime(bool isAddCount)
    {

        if (isAddCount)
        {
            if (_allCountCrime>=5)
            {
                return;
            }
            _allCountCrime++;
        }
        else
        {
            _allCountCrime--;
        }



        ChangeDataWindow(_allCountCrime, DataType.Crime);
    }

    private void Fight()
    {
        Debug.Log(_allCountPower >= _enemy.Power ? "Win!" : "Lose!");
    }
    private void NoFight()
    {
        Debug.Log("You passed by");
    }

    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:
                _countHealthText.text = $"Health Player: {countChangeData}";
                _health.Health = countChangeData;
                break;

            case DataType.Power:
                _countPowerText.text = $"Power Player: {countChangeData}";
                _power.Power = countChangeData;
                break;

            case DataType.Money:
                _countMoneyText.text = $"Money Player: {countChangeData}";
                _money.Money = countChangeData;
                break;

            case DataType.Crime:
                _countCrimeText.text = $"Crime Player: {countChangeData}";
                _crime.Crime = countChangeData;
                break;
        }

        _countPowerEnemyText.text = $"Power Enemy: {_enemy.Power}";
    }
    private void Update()
    {
        if (_allCountCrime<=2)
        {
            _noFigt.SetActive(true);
        }
        else
        {
            _noFigt.SetActive(false);
        }
  
    }
}
