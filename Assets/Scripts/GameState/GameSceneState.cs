using System;
using Audio;
using Cysharp.Threading.Tasks;
using GameTemplate.Events;
using GameTemplate.Managers.Scene;
using GameTemplate.UI;
using UnityEngine;
using VContainer;

namespace GameTemplate.GameState
{
    public class GameSceneState : GameStateBehaviour
    {
        [Inject] LevelManager _levelManager;
        [Inject] CurrencyManager _currencyManager;
        [Inject] SceneLoader _sceneLoader;
        [Inject] SoundPlayer _soundPlayer;
        [Inject] UIGameCanvas _uiGameCanvas;
        [Inject] EarningsUI _earningsUI;
        [Inject] TimerController _timerController;

        LevelPrefab _currentLevel;

        public override GameState ActiveState => GameState.Game;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UIGameCanvas>();
            builder.RegisterComponentInHierarchy<EarningsUI>();
            builder.RegisterComponentInHierarchy<TimerController>();
        }

        protected override void Start()
        {
            base.Start();

            _currentLevel = _levelManager.LoadCurrentLevel(transform);
            _currentLevel.OnGameFinished += OnGameFinished;
            _uiGameCanvas.SetLevelText(_levelManager.UILevelId);
            _timerController.Initialize(_levelManager.CurrentLevelData.levelTimer);
        }

        public void StartTimer()
        {
            if (_levelManager.LevelId == 0) return;
            _timerController.StartTimer();
        }

        void OnGameFinished(bool win, bool allLinesFilled)
        {
            CoroGameOver(win, allLinesFilled).Forget();
        }

        async UniTaskVoid CoroGameOver(bool win, bool allLinesFilled)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            var earnings = _earningsUI.SetEarnings();
            _currencyManager.EarnCurrency(earnings);

            if (win)
            {
                _soundPlayer.PlayWinSound();
            }
            else
            {
                _soundPlayer.PlayLoseSound();
            }

            _uiGameCanvas.GameFinished(win ? WinState.Win : WinState.Loss);
        }

        public void NextButtonClick()
        {
            if (_levelManager.UILevelId >= 2)
                _sceneLoader.LoadSceneByType(SceneType.MainMenu);
            else
            {
                _levelManager.SetNextLevel();
                _sceneLoader.LoadSceneByType(SceneType.Game);
            }
        }

        public void RetryButtonClick()
        {
            _sceneLoader.LoadSceneByType(SceneType.Game);
        }

        void Update()
        {
#if UNITY_EDITOR
            if (UnityEngine.Input.GetKeyDown(KeyCode.N))
            {
                _levelManager.SetNextLevel();
                _sceneLoader.LoadSceneByType(SceneType.Game);
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.P))
            {
                _levelManager.SetPreviousLevel();
                _sceneLoader.LoadSceneByType(SceneType.Game);
            }
#endif
        }

        protected override void OnDestroy()
        {
            if (_currentLevel != null)
                _currentLevel.OnGameFinished -= OnGameFinished;
            base.OnDestroy();
        }
    }
}
