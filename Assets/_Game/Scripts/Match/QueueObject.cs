using DG.Tweening;
using UnityEngine;

public class QueueObject : MonoBehaviour
{
    public ItemType itemType;

    static bool _firstTouchFired;

    public void TryToDropNewPlace()
    {
        if (!_firstTouchFired)
        {
            _firstTouchFired = true;
            // Notify GameSceneState.StartTimer()
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var matchGroup = hit.collider.GetComponentInParent<MatchGroup>();
            if (matchGroup != null)
            {
                matchGroup.CheckMatchAndEmpty();
            }
        }
    }

    public void Pop()
    {
        transform.DOPunchScale(Vector3.one * 0.2f, 0.2f).OnComplete(() => Destroy(gameObject));
    }

    public void SetInteractState(bool state)
    {
        // Enable/disable Flexalon interactable
        // Also block if z position > 0
        bool blocked = transform.position.z > 0;
        // flexalonInteractable.enabled = state && !blocked;
    }

#if UNITY_EDITOR
    [UnityEditor.ContextMenu("Spawn Object (Editor)")]
    void SpawnObjectEditor() { }
#endif
}
