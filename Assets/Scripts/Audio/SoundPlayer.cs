using DG.Tweening;
using UnityEngine;

namespace Audio
{
    public class SoundPlayer
    {
        readonly AudioData _audioData;
        AudioSource _audioSource;

        public SoundPlayer(AudioData audioData)
        {
            _audioData = audioData;
        }

        AudioSource GetOrCreateAudioSource()
        {
            if (_audioSource == null)
            {
                var go = Object.Instantiate(_audioData.audioObject);
                _audioSource = go.GetComponent<AudioSourceView>().audioSource;
                Object.DontDestroyOnLoad(go);
            }
            return _audioSource;
        }

        public void PlayThemeMusic(bool restart = false)
        {
            PlayTrack(_audioData.GetAudio(AudioID.Music), true, restart);
        }

        public void PlayTimerMusic()
        {
            PlayTrack(_audioData.GetAudio(AudioID.Ticking), true, false);
        }

        public void PlayWinSound()
        {
            PlayTrack(_audioData.GetAudio(AudioID.Win), false, true);
        }

        public void PlayLoseSound()
        {
            PlayTrack(_audioData.GetAudio(AudioID.Lose), false, true);
        }

        public void PlayTimesUpSound()
        {
            PlayTrack(_audioData.GetAudio(AudioID.TimesUp), false, true);
        }

        public void StopTrack()
        {
            var source = GetOrCreateAudioSource();
            source.DOFade(0, 1).OnComplete(() => source.Stop());
        }

        public void PlayTrack(AudioClip clip, bool loop, bool restart)
        {
            var source = GetOrCreateAudioSource();
            if (!restart && source.isPlaying && source.clip == clip) return;
            source.clip = clip;
            source.loop = loop;
            source.volume = 1f;
            source.Play();
        }
    }
}
