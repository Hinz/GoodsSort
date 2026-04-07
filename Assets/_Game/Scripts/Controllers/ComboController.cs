using System.Collections;
using GameTemplate.Managers.Scene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboController : MonoBehaviour
{
    [SerializeField] TMP_Text _comboText;
    [SerializeField] Slider _comboSlider;

    const int ComboTime = 25;

    int _comboCount;
    Coroutine _countdownCoroutine;

    void OnEnable()
    {
        MatchGroup.OnMatched += OnMatch;
        LevelPrefab.OnGameFinished += OnGameFinished;
    }

    void OnDisable()
    {
        MatchGroup.OnMatched -= OnMatch;
        LevelPrefab.OnGameFinished -= OnGameFinished;
    }

    void OnMatch(Vector3 position)
    {
        _comboCount++;
        if (_countdownCoroutine != null) StopCoroutine(_countdownCoroutine);
        _countdownCoroutine = StartCoroutine(CountdownCoroutine());
        UpdateUI();
    }

    void OnGameFinished(bool win, bool allLinesFilled)
    {
        if (_countdownCoroutine != null) StopCoroutine(_countdownCoroutine);
    }

    IEnumerator CountdownCoroutine()
    {
        float timer = ComboTime - _comboCount;
        float elapsed = 0f;

        while (elapsed < timer)
        {
            elapsed += Time.deltaTime;
            _comboSlider.value = 1f - (elapsed / timer);
            yield return null;
        }

        _comboCount = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        _comboText.text = _comboCount.ToString();
    }

    public int GetComboCount() => _comboCount;
}
