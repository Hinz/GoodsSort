using UnityEngine.SceneManagement;

namespace GameTemplate.Managers.Scene
{
    public struct SceneLoadData
    {
        public string SceneName { get; }
        public LoadSceneMode SceneMode { get; }
        public bool ActivateLoadingCanvas { get; }
        public bool SetActiveScene { get; }

        public SceneLoadData(string sceneName, LoadSceneMode sceneMode, bool activateLoadingCanvas, bool setActiveScene)
        {
            SceneName = sceneName;
            SceneMode = sceneMode;
            ActivateLoadingCanvas = activateLoadingCanvas;
            SetActiveScene = setActiveScene;
        }
    }
}
