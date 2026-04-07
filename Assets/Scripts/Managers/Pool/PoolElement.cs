using UnityEngine;

namespace GameTemplate.Managers.Pool
{
    public class PoolElement : MonoBehaviour
    {
        PoolID _poolId;
        bool _goBackOnDisable;
        bool _isApplicationQuitting;

        public void Initialize(bool goBackOnDisable, PoolID poolId)
        {
            _goBackOnDisable = goBackOnDisable;
            _poolId = poolId;
        }

        public void GoBackToPool()
        {
            PoolingManager.Instance.GoBackToPool(_poolId, gameObject);
        }

        void OnDisable()
        {
            if (_goBackOnDisable && !_isApplicationQuitting)
                GoBackToPool();
        }

        void OnApplicationQuit()
        {
            _isApplicationQuitting = true;
        }
    }
}
