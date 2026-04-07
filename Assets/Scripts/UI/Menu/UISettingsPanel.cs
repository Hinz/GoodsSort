using GameTemplate.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace GameTemplate.UI
{
    public class UISettingsPanel : MonoBehaviour
    {
        [SerializeField] Toggle soundToggle;
        [SerializeField] Toggle musicToggle;

        void OnEnable()
        {
            soundToggle.isOn = UserPrefs.GetSoundState();
            musicToggle.isOn = UserPrefs.GetMusicState();

            soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
            musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
        }

        void OnDisable()
        {
            soundToggle.onValueChanged.RemoveListener(OnSoundToggleChanged);
            musicToggle.onValueChanged.RemoveListener(OnMusicToggleChanged);
        }

        void OnSoundToggleChanged(bool state)
        {
            UserPrefs.SetSoundState(state);
            Debug.Log(state);
        }

        void OnMusicToggleChanged(bool state)
        {
            UserPrefs.SetMusicState(state);
        }
    }
}
