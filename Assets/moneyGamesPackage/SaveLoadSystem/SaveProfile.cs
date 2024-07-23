using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class SaveProfile {
    public static SaveProfile Load(int profileIndex) {
        string key = "saveProfile_" + profileIndex;
        if (!PlayerPrefs.HasKey(key)) {
            SaveProfile empty = SaveProfile.Empty();
            Save(empty, profileIndex);
        }

        string json = PlayerPrefs.GetString(key);
        return JsonUtility.FromJson<SaveProfile>(json);
    }

    public static void Save(SaveProfile profile, int profileIndex) {
        string key = "saveProfile_" + profileIndex;
        string json = JsonUtility.ToJson(profile);
        PlayerPrefs.SetString(key, json);
    }

    public static SaveProfile Empty() {
        return GetEmptyProfile();
    }

    protected virtual SaveProfile GetEmptyProfile() {
        return new SaveProfile() {
        };
    }
}