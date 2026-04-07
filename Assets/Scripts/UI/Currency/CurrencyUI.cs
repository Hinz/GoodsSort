using System.Collections;
using DG.Tweening;
using GameTemplate.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameTemplate.UI
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] Image _currencyIcon;
        [SerializeField] TMP_Text _currencySign;
        [SerializeField] TMP_Text _currencyAmount;
        [SerializeField] GameObject _buyButton;

        public void SetCurrency(Currency c)
        {
            _currencyIcon.sprite = c.currencyImage;
            _currencySign.text = c.currencySign;
            _currencyAmount.text = NumberHelper.ToStringScientific(c.currencyAmount);
            if (_buyButton != null)
                _buyButton.SetActive(c.isBuyable);
            transform.DOPunchScale(Vector3.one * 0.1f, 0.3f);
        }

        public void SetCurrencyIncremental(Currency c)
        {
            StartCoroutine(IncrementalUpdate(c));
        }

        IEnumerator IncrementalUpdate(Currency c)
        {
            float elapsed = 0f;
            float duration = 1f;
            int startAmount = int.Parse(_currencyAmount.text);
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                int current = (int)Mathf.Lerp(startAmount, c.currencyAmount, elapsed / duration);
                _currencyAmount.text = NumberHelper.ToStringScientific(current);
                yield return null;
            }
            SetCurrency(c);
        }
    }
}
