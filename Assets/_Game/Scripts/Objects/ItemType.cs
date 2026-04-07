using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemType", menuName = "Scriptable Objects/Item Type")]
public class ItemType : ScriptableObject
{
    [FormerlySerializedAs("type")]
    public ItemID itemID;
    public GameObject prefab;
}
