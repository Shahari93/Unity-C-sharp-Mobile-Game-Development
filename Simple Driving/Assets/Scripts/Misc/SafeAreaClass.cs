using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeAreaClass : MonoBehaviour
{
    private RectTransform safeAreaTransform;
    private Rect safeArea;
    private Vector2 minAnchor, maxAnchor;

    private void Awake() 
    {
        safeAreaTransform = GetComponent<RectTransform>();
        safeArea = Screen.safeArea;
        minAnchor = safeArea.position;
        maxAnchor = safeArea.size + minAnchor;
        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height; 
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;

        safeAreaTransform.anchorMin = minAnchor;
        safeAreaTransform.anchorMax = maxAnchor;
    }
}
