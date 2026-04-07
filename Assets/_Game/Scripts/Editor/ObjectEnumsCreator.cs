#if UNITY_EDITOR
using System.IO;
using System.Text;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace GameTemplate._Game.Scripts.Editor
{
    public class ObjectEnumsCreator : MonoBehaviour
    {
        public ItemType[] objects;

        [Button("Apply Enums")]
        public void CreateObjectEnums()
        {
            var sb = new StringBuilder();
            sb.AppendLine("public enum ObjectID");
            sb.AppendLine("{");
            foreach (var obj in objects)
            {
                var parts = obj.name.Split('_');
                if (parts.Length > 1)
                    sb.AppendLine($"    {parts[1]},");
            }
            sb.AppendLine("}");

            File.WriteAllText("Assets/_Game/Scripts/Objects/ObjectId.cs", sb.ToString());
            AssetDatabase.Refresh();
        }
    }
}
#endif
