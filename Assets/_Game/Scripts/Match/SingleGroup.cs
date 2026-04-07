using System.Collections.Generic;
using UnityEngine;

public class SingleGroup : MonoBehaviour
{
    [SerializeField] List<QueueObject> _queueObjects;
    [SerializeField] GameObject QueueObjectPrefab;

    void Awake()
    {
        _queueObjects = new List<QueueObject>(GetComponentsInChildren<QueueObject>());
    }

    public bool IsFirstEmpty()
    {
        return _queueObjects.Count == 0 || _queueObjects[0].itemType == null;
    }

    public void TakeThisObject(QueueObject obj)
    {
        for (int i = 0; i < _queueObjects.Count; i++)
        {
            if (_queueObjects[i].itemType == null)
            {
                _queueObjects[i].itemType = obj.itemType;
                return;
            }
        }
    }

    public QueueObject GetFirstObject()
    {
        return _queueObjects.Count > 0 ? _queueObjects[0] : null;
    }

    public ItemType GetFirstObjectType()
    {
        return _queueObjects.Count > 0 ? _queueObjects[0].itemType : null;
    }

    public void PopFirstObject()
    {
        if (_queueObjects.Count == 0) return;
        var first = _queueObjects[0];
        _queueObjects.RemoveAt(0);
        first.Pop();

        if (_queueObjects.Count > 0)
            _queueObjects[0].gameObject.SetActive(true);
        else if (QueueObjectPrefab != null)
        {
            var newObj = Instantiate(QueueObjectPrefab, transform);
            _queueObjects.Add(newObj.GetComponent<QueueObject>());
        }
    }

    public void DestroyFirstObject()
    {
        if (_queueObjects.Count > 0)
        {
            Destroy(_queueObjects[0].gameObject);
            _queueObjects.RemoveAt(0);
        }
    }

#if UNITY_EDITOR
    [UnityEditor.ContextMenu("Add Queue")]
    void AddQueue() { }
#endif
}
