using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeArea : MonoBehaviour {
    private RectTransform _myRectTransform;

    private void Awake() {
        _myRectTransform = GetComponent<RectTransform>();
        InvokeRepeating(nameof(UpdateSafeArea), 0, 5f);
    }

    private void UpdateSafeArea() {
        Rect safeArea = Screen.safeArea;
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position = safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        _myRectTransform.anchorMin = anchorMin;
        _myRectTransform.anchorMax = anchorMax;
    }
}