namespace GameTemplate.GameState
{
    public enum WinState { Invalid, Win, Loss }

    public class PersistentGameState
    {
        public WinState WinState { get; private set; }

        public void SetWinState(WinState state)
        {
            WinState = state;
        }

        public void Reset()
        {
            WinState = WinState.Invalid;
        }
    }
}
