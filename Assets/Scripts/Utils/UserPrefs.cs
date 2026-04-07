using UnityEngine;

namespace GameTemplate.Utils
{
    public static class UserPrefs
    {
        const string SOUND_KEY = "Sound";
        const string MUSIC_KEY = "Music";
        const string LEVEL_KEY = "Level";
        const string CURRENCY_KEY = "Currency";

        public static bool GetSoundState() => PlayerPrefs.GetInt(SOUND_KEY, 1) == 1;
        public static void SetSoundState(bool state) => PlayerPrefs.SetInt(SOUND_KEY, state ? 1 : 0);

        public static bool GetMusicState() => PlayerPrefs.GetInt(MUSIC_KEY, 1) == 1;
        public static void SetMusicState(bool state) => PlayerPrefs.SetInt(MUSIC_KEY, state ? 1 : 0);

        public static int GetLevelId() => PlayerPrefs.GetInt(LEVEL_KEY, 0);
        public static void SetLevelId(int id) => PlayerPrefs.SetInt(LEVEL_KEY, id);

        public static int GetCurrency(int id) => PlayerPrefs.GetInt(CURRENCY_KEY + id, 0);
        public static void SetCurrency(int id, int amount) => PlayerPrefs.SetInt(CURRENCY_KEY + id, amount);
    }
}
