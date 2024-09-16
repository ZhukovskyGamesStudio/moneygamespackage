using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneSwitcher : MonoBehaviour {
    private static bool _isSwitched;

    private void Awake() {
        if (!_isSwitched) {
            _isSwitched = true;
            SceneManager.LoadScene(0);
        } else {
            Destroy(gameObject);
        }
    }
}