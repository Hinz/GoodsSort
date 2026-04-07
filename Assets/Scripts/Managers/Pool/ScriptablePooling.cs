using UnityEngine;
#if UNITY_EDITOR
using System.IO;
using System.Text;
using Sirenix.OdinInspector;
using UnityEditor;
#endif

namespace GameTemplate.Managers.Pool
{
    [CreateAssetMenu(fileName = "ScriptablePooling", menuName = "Scriptable Objects/Scriptable Pooling")]
    public class ScriptablePooling : ScriptableObject
    {
        public PoolObject[] poolObjects;

#if UNITY_EDITOR
        [Button]
        public void Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("// Auto-generated enum");
            sb.AppendLine("public enum PoolID");
            sb.AppendLine("{");
            foreach (var obj in poolObjects)
            {
                sb.AppendLine($"    {obj.poolName},");
            }
            sb.AppendLine("}");

            File.WriteAllText("Assets/Scripts/Managers/Pool/PoolId.cs", sb.ToString());
            AssetDatabase.Refresh();
        }
#endif
    }
}
