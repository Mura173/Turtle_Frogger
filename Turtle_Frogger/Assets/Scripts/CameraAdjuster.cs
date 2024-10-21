using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Aspect Ratio
        Camera.main.aspect = (float)Screen.width / Screen.height;

        // Safe Area
        Rect safeArea = Screen.safeArea;
        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
    }
}
