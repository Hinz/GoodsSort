using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GameTemplate.Utils
{
    [Serializable]
    public class SceneReference : ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        [SerializeField] UnityEngine.Object sceneAsset;
#endif
        [SerializeField] string scenePath = "";

        public string ScenePath
        {
            get
            {
#if UNITY_EDITOR
                return GetScenePathFromAsset();
#else
                return scenePath;
#endif
            }
            set
            {
                scenePath = value;
#if UNITY_EDITOR
                sceneAsset = GetSceneAssetFromPath();
#endif
            }
        }

        public static implicit operator string(SceneReference sceneReference)
        {
            return sceneReference.ScenePath;
        }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            if (sceneAsset == null) return;
            var assetPath = AssetDatabase.GetAssetPath(sceneAsset);
            if (!string.IsNullOrEmpty(assetPath))
                scenePath = assetPath;
#endif
        }

        public void OnAfterDeserialize()
        {
#if UNITY_EDITOR
            EditorApplication.delayCall += () =>
            {
                if (string.IsNullOrEmpty(scenePath)) return;
                sceneAsset = GetSceneAssetFromPath();
            };
#endif
        }

#if UNITY_EDITOR
        SceneAsset GetSceneAssetFromPath()
        {
            return string.IsNullOrEmpty(scenePath) ? null : AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        }

        string GetScenePathFromAsset()
        {
            return sceneAsset == null ? scenePath : AssetDatabase.GetAssetPath(sceneAsset);
        }
#endif
    }
}
