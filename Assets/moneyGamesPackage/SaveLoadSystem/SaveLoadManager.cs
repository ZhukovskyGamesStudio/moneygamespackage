using System;
using UnityEngine;

public class SaveLoadManager<T> : MonoBehaviour where T : SaveProfile {
    public static SaveLoadManager<T> Instance;
    public static T Profile;

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        int index = PlayerPrefs.GetInt("profileIndex", 0);
        ChooseProfile(index);
    }

    public void ChooseProfile(int index) {
        Profile = T.Load(index);
        PlayerPrefs.SetInt("profileIndex", index);
    }

    public static void Save() {
        T.Save(Profile,PlayerPrefs.GetInt("profileIndex", 0) );
    }
}