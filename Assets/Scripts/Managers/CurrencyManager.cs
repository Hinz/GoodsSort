using System;
using GameTemplate.Events;
using GameTemplate.UI;

namespace GameTemplate.Managers
{
    public class CurrencyManager
    {
        readonly CurrencyData _currencyData;

        public CurrencyManager(CurrencyData currencyData)
        {
            _currencyData = currencyData;
        }

        public void EarnCurrency(EventArgs args)
        {
            var currencyArgs = (CurrencyArgs)args;
            _currencyData.currencies[currencyArgs.currencyId].Earn(currencyArgs.changeAmount);
        }

        public void SpendCurrency(EventArgs args)
        {
            var currencyArgs = (CurrencyArgs)args;
            _currencyData.currencies[currencyArgs.currencyId].Spend(currencyArgs.changeAmount);
        }
    }
}
