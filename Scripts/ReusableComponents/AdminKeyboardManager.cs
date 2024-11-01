using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminKeyboardManager : Singleton<AdminKeyboardManager> {
    [SerializeField]
    private KeyCode _controlKeycode = KeyCode.LeftAlt;

    [SerializeField]
    private KeyCode _fullReloadGame, _reloadCurrentScene;

    protected Dictionary<KeyCode, Action> _keyboardCommands = new Dictionary<KeyCode, Action>();

    protected override void OnFirstInited() {
        base.OnFirstInited();
        _keyboardCommands = new Dictionary<KeyCode, Action>() {
            { _fullReloadGame, FullReloadGame },
            { _reloadCurrentScene, ReloadCurrentScene },
        };
    }

    private void FullReloadGame() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    private void ReloadCurrentScene() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update() {
        CheckKeyboardCommands();
    }

    private void CheckKeyboardCommands() {
        foreach (KeyValuePair<KeyCode, Action> kvp in _keyboardCommands) {
            if (Input.GetKey(_controlKeycode) && Input.GetKeyDown(kvp.Key)) {
                kvp.Value.Invoke();
            }
        }
    }
}