using GameTemplate.ScriptableObjects;
using GameTemplate.Utils;
using UnityEngine;
using VContainer.Unity;

namespace GameTemplate.Managers.Scene
{
    public enum LevelType { Prefab, Scene }

    public class LevelManager : IInitializable
    {
        readonly SceneLoader _sceneLoader;
        readonly LevelDataHolder _levelDataHolder;

        public int LevelId => UserPrefs.GetLevelId();
        public int UILevelId => LevelId + 1;
        public LevelData CurrentLevelData => _levelDataHolder.levels[LevelId % _levelDataHolder.levels.Length];

        public LevelManager(SceneLoader sceneLoader, LevelDataHolder levelDataHolder)
        {
            _sceneLoader = sceneLoader;
            _levelDataHolder = levelDataHolder;
        }

        public void Initialize() { }

        public LevelPrefab LoadCurrentLevel(Transform parent)
        {
            var levelData = CurrentLevelData;

            if (_levelDataHolder.levelType == LevelType.Prefab)
            {
                var go = Object.Instantiate(levelData.levelPrefab, parent);
                return go.GetComponent<LevelPrefab>();
            }

            return null;
        }

        public void SetNextLevel()
        {
            UserPrefs.SetLevelId(LevelId + 1);
        }

        public void SetPreviousLevel()
        {
            if (LevelId > 0)
                UserPrefs.SetLevelId(LevelId - 1);
        }
    }
}
