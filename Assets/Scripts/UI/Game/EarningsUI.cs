using GameTemplate.Events;
using TMPro;
using UnityEngine;

namespace GameTemplate.UI
{
    public class EarningsUI : MonoBehaviour
    {
        [SerializeField] TMP_Text _earningsText;

        public CurrencyArgs SetEarnings()
        {
            int amount = Random.Range(10, 20);
            _earningsText.text = "+" + amount;
            return new CurrencyArgs(0, amount, false);
        }
    }
}
