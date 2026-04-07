using System.Collections.Generic;
using GameTemplate.Managers.Scene;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameTemplate.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "Scriptable Objects/Scene Data")]
    public class SceneData : SerializedScriptableObject
    {
        public Dictionary<SceneType, string> scenes;
    }
}
