using UnityEngine;

public class PlayerManager : MonoBehaviour, ISaveManager
{
    public static PlayerManager instance;
    public Player player;

    public int currency;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    public bool HaveEnoughMoney(int _price)
    {
        if (_price > currency)
            return false;

        currency -= _price;
        return true;
    }

    public int GetCurrency() => currency;

    public void LoadDate(GameData _data)
    {
        this.currency = _data.currency;
    }

    public void SaveDate(ref GameData _data)
    {
        _data.currency = this.currency;
    }
}
