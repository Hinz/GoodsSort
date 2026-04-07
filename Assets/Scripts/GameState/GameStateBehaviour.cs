using UnityEngine;
using VContainer.Unity;

namespace GameTemplate.GameState
{
    public abstract class GameStateBehaviour : LifetimeScope
    {
        static GameObject s_ActiveStateGO;

        public abstract GameState ActiveState { get; }
        public virtual bool Persists => false;

        protected override void Start()
        {
            base.Start();

            if (Persists && s_ActiveStateGO != null &&
                s_ActiveStateGO.GetComponent<GameStateBehaviour>()?.ActiveState == ActiveState)
            {
                Destroy(gameObject);
                return;
            }

            if (s_ActiveStateGO != null)
            {
                Destroy(s_ActiveStateGO);
            }

            s_ActiveStateGO = gameObject;

            if (Persists)
                DontDestroyOnLoad(gameObject);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (s_ActiveStateGO == gameObject)
                s_ActiveStateGO = null;
        }
    }

    public enum GameState { MainMenu, Game }
}
