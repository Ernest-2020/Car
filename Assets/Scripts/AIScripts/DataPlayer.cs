using System.Collections.Generic;

public class DataPlayer
{
    private string _titleData;

    private int _countHealth;
    private int _countMoney;
    private int _countPower;
    private int _countCrime;

    private List<IEnemy> _enemies = new List<IEnemy>();

    public DataPlayer(string titleData)
    {
        _titleData = titleData;
    }

    public string TitleData => _titleData;

    public int Money
    {
        get => _countMoney;
        set
        {
            if (_countMoney != value)
            {
                _countMoney = value;
                Notifier(DataType.Money);
            }
        }
    }

    public int Health
    {
        get => _countHealth;
        set
        {
            if (_countHealth != value)
            {
                _countHealth = value;
                Notifier(DataType.Health);
            }
        }
    }

    public int Power
    {
        get => _countPower;
        set
        {
            if (_countPower != value)
            {
                _countPower = value;
                Notifier(DataType.Power);
            }
        }
    }

    public int Crime
    {
        get => _countCrime;
        set
        {
            if (_countCrime != value)
            {
                _countCrime = value;
                Notifier(DataType.Crime);
            }
        }
    }

    public void Attach(IEnemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void Detach(IEnemy enemy)
    {
        _enemies.Remove(enemy);
    }

    private void Notifier(DataType dataType)
    {
        foreach (var enemy in _enemies)
            enemy.Update(this, dataType);
    }
}

class Money : DataPlayer
{
    public Money(string titleData): base(titleData)
    {

    }
}

class Power : DataPlayer
{
    public Power(string titleData) : base(titleData)
    {

    }
}

class Health : DataPlayer
{
    public Health(string titleData) : base(titleData)
    {

    }
}
class Crime : DataPlayer
{
    public Crime(string titleData) : base(titleData)
    {

    }
}
