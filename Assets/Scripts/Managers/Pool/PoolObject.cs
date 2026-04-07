using System;
using UnityEngine;

namespace GameTemplate.Managers.Pool
{
    [Serializable]
    public class PoolObject
    {
        public GameObject objectPrefab;
        public string poolName;
        public int objectCount;
        public bool goBackOnDisable;
    }
}
