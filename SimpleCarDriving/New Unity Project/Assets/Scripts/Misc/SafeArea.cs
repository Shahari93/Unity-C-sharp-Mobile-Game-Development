using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    RectTransform rectTransform;
    Rect safeArea;
    Vector2 minAnchor, maxAnchor;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        safeArea = Screen.safeArea;

        minAnchor = safeArea.position;
        maxAnchor = safeArea.size + minAnchor;

        minAnchor.x /= Screen.width;
        maxAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        minAnchor.y /= Screen.height;

        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }
}
