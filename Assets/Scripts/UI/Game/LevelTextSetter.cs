using TMPro;
using UnityEngine;

namespace GameTemplate.UI
{
    public class LevelTextSetter : MonoBehaviour
    {
        public void SetLevelText(int levelID)
        {
            GetComponent<TMP_Text>().text = "Level " + levelID;
        }
    }
}
