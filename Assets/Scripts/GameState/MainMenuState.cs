using GameTemplate.UI;
using VContainer;

namespace GameTemplate.GameState
{
    public class MainMenuState : GameStateBehaviour
    {
        public override GameState ActiveState => GameState.MainMenu;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<UICanvas>();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
