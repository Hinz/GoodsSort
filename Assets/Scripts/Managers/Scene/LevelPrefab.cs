using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameTemplate.Managers.Scene
{
    public class LevelPrefab : MonoBehaviour, IDisposable
    {
        public List<MatchGroup> matchGroups;
        public List<QueueObject> queueObjects;
        public List<GroupBlocker> groupBlockers;

        public event Action<bool, bool> OnGameFinished;

        public async void CheckLevelOver()
        {
            await UniTask.Yield();
            if (queueObjects.Count == 0)
                OnGameFinished?.Invoke(true, false);
        }

        public async void CheckAllFirstFilled()
        {
            await UniTask.Yield();
            bool allFilled = matchGroups.All(g => g.IsAllFirstFilled());
            if (allFilled)
                OnGameFinished?.Invoke(false, true);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("CONTEXT/LevelPrefab/Create Random Level")]
        static void CreateRandomLevel(UnityEditor.MenuCommand command)
        {
            var levelPrefab = command.context as LevelPrefab;
            levelPrefab?.GenerateRandomLevel();
        }

        void GenerateRandomLevel()
        {
            // Editor-only procedural level generation
        }

        [UnityEditor.MenuItem("CONTEXT/LevelPrefab/Clear Level")]
        static void ClearLevel(UnityEditor.MenuCommand command)
        {
            var levelPrefab = command.context as LevelPrefab;
            if (levelPrefab == null) return;

            foreach (var q in levelPrefab.queueObjects.ToList())
                DestroyImmediate(q.gameObject);
            foreach (var b in levelPrefab.groupBlockers.ToList())
                DestroyImmediate(b.gameObject);

            levelPrefab.queueObjects.Clear();
            levelPrefab.groupBlockers.Clear();
        }
#endif

        public static List<T> ShuffleListWithOrderBy<T>(List<T> list)
        {
            return list.OrderBy(_ => UnityEngine.Random.value).ToList();
        }
    }
}
