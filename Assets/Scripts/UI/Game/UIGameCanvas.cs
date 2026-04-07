using DG.Tweening;
using GameTemplate.GameState;
using GameTemplate.Managers.Scene;
using UnityEngine;
using VContainer;

namespace GameTemplate.UI
{
    public class UIGameCanvas : MonoBehaviour
    {
        [SerializeField] CanvasGroup winPanel;
        [SerializeField] CanvasGroup lossPanel;
        [SerializeField] GameObject topPanel;

        [Inject] LevelManager _levelManager;

        void Start()
        {
            foreach (var setter in GetComponentsInChildren<LevelTextSetter>())
                setter.SetLevelText(_levelManager.UILevelId);

            if (_levelManager.UILevelId == 1 && topPanel != null)
                topPanel.SetActive(false);
        }

        public void SetLevelText(int levelId)
        {
            foreach (var setter in GetComponentsInChildren<LevelTextSetter>())
                setter.SetLevelText(levelId);
        }

        public void GameFinished(WinState state)
        {
            if (state == WinState.Win)
                OpenPanel(winPanel);
            else
                OpenPanel(lossPanel);
        }

        void OpenPanel(CanvasGroup panel)
        {
            panel.alpha = 0f;
            panel.gameObject.SetActive(true);
            panel.DOFade(1f, 1f).OnComplete(() =>
            {
                panel.interactable = true;
                panel.blocksRaycasts = true;
            });
        }
    }
}
