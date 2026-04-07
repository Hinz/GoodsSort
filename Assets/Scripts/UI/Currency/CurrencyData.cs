using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace GameTemplate.UI
{
    [CreateAssetMenu(fileName = "CurrencyData", menuName = "Scriptable Objects/Currency Data")]
    public class CurrencyData : ScriptableObject, IStartable
    {
        public List<Currency> currencies;

        public void Start()
        {
            Debug.Log("Currency Data");
            for (int i = 0; i < currencies.Count; i++)
                currencies[i].Initialize(i);
        }
    }
}
