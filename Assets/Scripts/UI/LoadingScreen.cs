using System.Collections;
using GameTemplate.Managers.Scene;
using UnityEngine;

namespace GameTemplate.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] CanvasGroup _canvasGroup;
        [SerializeField] float _delay = 0.5f;
        [SerializeField] float _fadeDuration = 0.1f;

        Coroutine _fadeCoroutine;

        void OnEnable()
        {
            SceneLoader.OnBeforeSceneLoad += OpenLoadingScreen;
            SceneLoader.OnSceneLoaded += CloseLoadingScreen;
        }

        void OnDisable()
        {
            SceneLoader.OnBeforeSceneLoad -= OpenLoadingScreen;
            SceneLoader.OnSceneLoaded -= CloseLoadingScreen;
        }

        void OpenLoadingScreen()
        {
            if (_fadeCoroutine != null) StopCoroutine(_fadeCoroutine);
            _canvasGroup.alpha = 1f;
        }

        void CloseLoadingScreen()
        {
            if (_fadeCoroutine != null) StopCoroutine(_fadeCoroutine);
            _fadeCoroutine = StartCoroutine(FadeOutCoroutine());
        }

        IEnumerator FadeOutCoroutine()
        {
            yield return new WaitForSeconds(_delay);
            float elapsed = 0f;
            while (elapsed < _fadeDuration)
            {
                elapsed += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsed / _fadeDuration);
                yield return null;
            }
            _canvasGroup.alpha = 0f;
        }
    }
}
