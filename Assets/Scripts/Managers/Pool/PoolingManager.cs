using System.Collections.Generic;
using UnityEngine;

namespace GameTemplate.Managers.Pool
{
    public class PoolingManager : MonoBehaviour
    {
        public static PoolingManager Instance { get; private set; }

        [SerializeField] ScriptablePooling scriptablePooling;

        readonly Dictionary<PoolID, Queue<GameObject>> objectPools = new();

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializePools();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void InitializePools()
        {
            foreach (var poolObject in scriptablePooling.poolObjects)
            {
                if (!System.Enum.TryParse<PoolID>(poolObject.poolName, out var poolId))
                    continue;

                var queue = new Queue<GameObject>();
                for (int i = 0; i < poolObject.objectCount; i++)
                {
                    var go = Instantiate(poolObject.objectPrefab, transform);
                    go.SetActive(false);
                    var element = go.GetComponent<PoolElement>() ?? go.AddComponent<PoolElement>();
                    element.Initialize(poolObject.goBackOnDisable, poolId);
                    queue.Enqueue(go);
                }
                objectPools[poolId] = queue;
            }
        }

        public GameObject GetGameObjectById(PoolID id, Vector3 position = default, Quaternion rotation = default, Transform parent = null)
        {
            if (objectPools.TryGetValue(id, out var queue) && queue.Count > 0)
            {
                var go = queue.Dequeue();
                go.transform.SetParent(parent);
                go.transform.SetPositionAndRotation(position, rotation);
                go.SetActive(true);
                return go;
            }
            return null;
        }

        public void GoBackToPool(PoolID id, GameObject go)
        {
            go.SetActive(false);
            go.transform.SetParent(transform);
            if (!objectPools.ContainsKey(id))
                objectPools[id] = new Queue<GameObject>();
            objectPools[id].Enqueue(go);
        }

        public void ResetPool()
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);
        }
    }
}
