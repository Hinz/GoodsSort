using GameTemplate.Managers.Scene;
using UnityEngine;

namespace GameTemplate.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelDataHolder", menuName = "Scriptable Objects/Level data holder")]
    public class LevelDataHolder : ScriptableObject
    {
        public LevelType levelType;
        public LevelData[] levels;
    }
}
