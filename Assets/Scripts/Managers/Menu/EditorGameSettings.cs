using Sirenix.OdinInspector;
using UnityEngine;

namespace GameTemplate.Managers.Menu
{
    [CreateAssetMenu(fileName = "EditorGameSettings", menuName = "Scriptable Objects/EditorGameSettings")]
    public class EditorGameSettings : ScriptableObject
    {
        [TabGroup("Editor Settings")]
        public bool startFromGameScene;
    }
}
