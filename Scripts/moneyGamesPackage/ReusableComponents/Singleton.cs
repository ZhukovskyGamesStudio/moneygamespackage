using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
            OnFirstInited();
        } else {
            Destroy(gameObject);
        }
    }

    protected virtual void OnFirstInited() {
        
    }
}