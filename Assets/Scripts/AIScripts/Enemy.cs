using UnityEngine;


public class Enemy : IEnemy
{
  
    private string _name;

    private int _countMoney;
    private int _countHealth;
    private int _countPower;
    

    public Enemy(string name)
    {
        _name = name;
    }

    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:
                _countHealth = dataPlayer.Health;
                break;

            case DataType.Money:
                _countMoney = dataPlayer.Money;
                break;

            case DataType.Power:
                _countPower = dataPlayer.Power;
                break;

        }
        

        Debug.Log($"Update data: {dataType}. Enemy: {_name}");
    }

    public int Power
    {
        get
        {
            var power = _countPower + _countHealth * (_countMoney/2);
            return power;
        }
    }

   
}
