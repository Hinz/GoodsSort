using System;
using Cysharp.Threading.Tasks;
using GameTemplate.ScriptableObjects;
using UnityEngine.SceneManagement;

namespace GameTemplate.Managers.Scene
{
    public enum SceneType { MainMenu, Game, Startup }

    public class SceneLoader
    {
        readonly SceneData _sceneData;

        public static event Action OnBeforeSceneLoad;
        public static event Action OnSceneLoaded;

        public SceneLoader(SceneData sceneData)
        {
            _sceneData = sceneData;
        }

        public void LoadSceneByType(SceneType type)
        {
            var sceneName = _sceneData.scenes[type];
            LoadScene(new SceneLoadData(sceneName, LoadSceneMode.Single, true, true));
        }

        void LoadScene(SceneLoadData data)
        {
            LoadSceneAsync(data).Forget();
        }

        async UniTaskVoid LoadSceneAsync(SceneLoadData data)
        {
            OnBeforeSceneLoad?.Invoke();
            await SceneManager.LoadSceneAsync(data.SceneName, data.SceneMode).ToUniTask();
            OnSceneLoaded?.Invoke();
        }
    }
}
