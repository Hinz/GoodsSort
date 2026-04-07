using GameTemplate.Utils;
using UnityEngine;

namespace GameTemplate.UI
{
    [System.Serializable]
    public class Currency
    {
        public Sprite currencyImage;
        public string currencySign;
        public int currencyAmount;
        public bool isBuyable;

        public int CurrencyId { get; private set; }

        public void Initialize(int id)
        {
            CurrencyId = id;
            currencyAmount = UserPrefs.GetCurrency(id);
        }

        public void Earn(int amount)
        {
            currencyAmount += amount;
            SetPlayerPref();
        }

        public void Spend(int amount)
        {
            currencyAmount -= amount;
            SetPlayerPref();
        }

        public void Reset()
        {
            currencyAmount = 0;
            SetPlayerPref();
        }

        void SetPlayerPref()
        {
            UserPrefs.SetCurrency(CurrencyId, currencyAmount);
        }
    }
}
