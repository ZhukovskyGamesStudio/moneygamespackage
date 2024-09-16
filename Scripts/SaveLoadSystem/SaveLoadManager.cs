using System;
using UnityEngine;

public class SaveLoadManager<TManager, TProfile> : Singleton<TManager> where TProfile : SaveProfile, new()
    where TManager : SaveLoadManager<TManager, TProfile> {
    public static TProfile Profile;

    protected override void OnFirstInited() {
        base.OnFirstInited();
        int index = PlayerPrefs.GetInt("profileIndex", 0);
        ChooseProfile(index);
    }

    public void ChooseProfile(int index) {
        Profile = Load(index);
        PlayerPrefs.SetInt("profileIndex", index);
    }

    public static TProfile Load(int profileIndex) {
        string key = "saveProfile_" + profileIndex;
        if (!PlayerPrefs.HasKey(key)) {
            Profile = Instance.CreateNewProfile();
            Save();
        }

        string json = PlayerPrefs.GetString(key);
        return JsonUtility.FromJson<TProfile>(json);
    }

    public static void Save() {
        int profileIndex = PlayerPrefs.GetInt("profileIndex", 0);
        string key = "saveProfile_" + profileIndex;
        string json = JsonUtility.ToJson(Profile);
        PlayerPrefs.SetString(key, json);
    }

    protected virtual TProfile CreateNewProfile() {
        return new TProfile();
    }
}