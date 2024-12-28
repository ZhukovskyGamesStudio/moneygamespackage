using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneSwitcher : MonoBehaviour {
    public static bool IsSwitched { get; private set; }

    private void Awake() {
        if (!IsSwitched) {
            IsSwitched = true;
            SceneManager.LoadScene(0);
        } else {
            Destroy(gameObject);
        }
    }
}