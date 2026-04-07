using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameTemplate.Editor
{
    public static class SceneBoot
    {
        [RuntimeInitializeOnLoadMethod]
        static void OnBeforeSceneLoad()
        {
#if UNITY_EDITOR
            var settings = Resources.Load<GameTemplate.Managers.Menu.EditorGameSettings>("Managers/EditorGameSettings");
            if (settings != null && settings.startFromGameScene)
            {
                SceneManager.LoadScene("Startup");
            }
#endif
        }
    }
}
