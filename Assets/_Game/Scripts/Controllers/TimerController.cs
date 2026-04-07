using System;
using Audio;
using GameTemplate.Managers.Scene;
using TMPro;
using UnityEngine;
using VContainer;

public class TimerController : MonoBehaviour
{
    [SerializeField] TMP_Text _timerText;

    [Inject] SoundPlayer _soundPlayer;

    public static event Action<int> OnSetTimer;
    public static event Action OnTimesUp;

    float _timeRemaining;
    bool _timerRunning;
    bool _timerPaused;
    float _sineTimer;

    Color _originalColor;

    public void Initialize(int seconds)
    {
        _timeRemaining = seconds;
        _timerRunning = false;
        _timerPaused = false;
        if (_timerText != null)
        {
            _originalColor = _timerText.color;
            _timerText.text = FormatTime(_timeRemaining);
        }
        OnSetTimer?.Invoke(seconds);
        LevelPrefab.OnGameFinished += OnGameFinished;
    }

    public void StartTimer()
    {
        _timerRunning = true;
    }

    void OnGameFinished(bool win, bool allLinesFilled)
    {
        _timerRunning = false;
        LevelPrefab.OnGameFinished -= OnGameFinished;
    }

    void Update()
    {
        if (!_timerRunning || _timerPaused) return;

        _timeRemaining -= Time.deltaTime;

        if (_timerText != null)
            _timerText.text = FormatTime(_timeRemaining);

        if (_timeRemaining <= 5f)
        {
            _sineTimer += Time.deltaTime * 2f;
            float scale = Mathf.Cos(_sineTimer) * -1f / 2f + 0.5f;
            if (_timerText != null)
            {
                _timerText.transform.localScale = Vector3.one * (1f + scale * 0.2f);
                _timerText.color = Color.red;
            }
        }

        if (_timeRemaining <= 0f)
        {
            _timeRemaining = 0f;
            _timerRunning = false;
            OnTimesUp?.Invoke();
            _soundPlayer?.PlayTimesUpSound();
        }
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
}
