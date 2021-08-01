using UnityEngine;

// Changing the canvas size acording to different phone safe area

public class SafeAreaHeandler : MonoBehaviour
{
    RectTransform rectTransform; // rect transform of the safe area game object
    Rect safeArea;

    Vector2 minAnchor, maxAnchor; // min and max size of the screen after we check the safe area

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        safeArea = Screen.safeArea; // getting the screen safe area
        minAnchor = safeArea.position;
        maxAnchor = minAnchor + safeArea.size;

        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;
        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }
}
