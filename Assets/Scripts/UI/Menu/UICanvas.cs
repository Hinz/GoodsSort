using Audio;
using GameTemplate.Managers.Scene;
using VContainer;
using VContainer.Unity;

namespace GameTemplate.UI
{
    public class UICanvas : IStartable
    {
        [Inject] CurrencyManager _currencyManager;
        [Inject] SceneLoader _sceneLoader;
        [Inject] SoundPlayer _soundPlayer;
        [Inject] LevelManager _levelManager;

        public void Start()
        {
            // Initialize currency UI for each currency
        }

        public void OnPlayButtonClick()
        {
            _soundPlayer.StopTrack();
            _sceneLoader.LoadSceneByType(SceneType.Game);
        }
    }
}
