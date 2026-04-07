using GameTemplate.Utils;
using UnityEngine;

namespace GameTemplate.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/Level data")]
    public class LevelData : ScriptableObject
    {
        public int levelTimer;
        public GameObject levelPrefab;
        public SceneReference levelScene;
    }
}
