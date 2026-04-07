using UnityEngine;
using VContainer.Unity;

namespace Audio
{
    public class MainMenuMusicStarter : IStartable
    {
        readonly SoundPlayer _soundPlayer;
        [SerializeField] bool restartIfPlaying;

        public MainMenuMusicStarter(SoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }

        public void Start()
        {
            _soundPlayer.PlayThemeMusic(restartIfPlaying);
        }
    }
}
