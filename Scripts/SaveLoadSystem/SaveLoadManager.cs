using System;
using UnityEngine;

public class SaveLoadManager<T> : MonoBehaviour where T : SaveProfile, new() {
    public static SaveLoadManager<T> Instance;
    public static T Profile;

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        int index = PlayerPrefs.GetInt("profileIndex", 0);
        ChooseProfile(index);
    }

    public void ChooseProfile(int index) {
        Profile = Load(index);
        PlayerPrefs.SetInt("profileIndex", index);
    }

    public static T Load(int profileIndex) {
        string key = "saveProfile_" + profileIndex;
        if (!PlayerPrefs.HasKey(key)) {
            Profile = Instance.CreateNewProfile();
            Save();
        }

        string json = PlayerPrefs.GetString(key);
        return JsonUtility.FromJson<T>(json);
    }

    public static void Save() {
        int profileIndex = PlayerPrefs.GetInt("profileIndex", 0);
        string key = "saveProfile_" + profileIndex;
        string json = JsonUtility.ToJson(Profile);
        PlayerPrefs.SetString(key, json);
    }

    protected virtual T CreateNewProfile() {
        return new T();
    }
}