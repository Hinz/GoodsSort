using UnityEngine;

namespace GameTemplate.UI
{
    public class UISettingsCanvas : MonoBehaviour
    {
        [SerializeField] GameObject settingsPanel;

        void Awake()
        {
            settingsPanel.SetActive(false);
        }

        public void OnClickSettingsButton()
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }

        public void OnClickQuitButton()
        {
            settingsPanel.SetActive(false);
        }
    }
}
