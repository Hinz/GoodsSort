using System;
using System.Collections.Generic;
using UnityEngine;

public class MatchGroup : MonoBehaviour
{
    public List<SingleGroup> singleGroups;

    public static event Action<Vector3> OnMatched;

    public void CheckMatchAndEmpty()
    {
        if (singleGroups.Count == 0) return;

        var firstType = singleGroups[0].GetFirstObjectType();
        if (firstType == null) return;

        bool allMatch = true;
        foreach (var group in singleGroups)
        {
            if (group.GetFirstObjectType() != firstType)
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch)
        {
            OnMatched?.Invoke(transform.position);
            foreach (var group in singleGroups)
                group.PopFirstObject();
        }
    }

    public bool IsAllEmpty()
    {
        foreach (var group in singleGroups)
        {
            if (!group.IsFirstEmpty()) return false;
        }
        return true;
    }

    public bool IsAllFirstFilled()
    {
        foreach (var group in singleGroups)
        {
            if (group.IsFirstEmpty()) return false;
        }
        return true;
    }

    public void BlockerDeactivated()
    {
        // Re-enable interactables on associated queue objects
    }

#if UNITY_EDITOR
    [UnityEditor.ContextMenu("Spawn Row")]
    void SpawnRow() { }

    [UnityEditor.ContextMenu("Disable Interactables")]
    void DisableInteractables() { }
#endif
}
