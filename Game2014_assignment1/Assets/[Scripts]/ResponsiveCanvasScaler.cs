using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponsiveCanvasScaler : MonoBehaviour
{
    [SerializeField]
   RectTransform rectTransform;

    Rect safeArea;

    private void Start()
    {
        safeArea = Screen.safeArea;
        refreshAnchors();
    }

    private void Update()
    {
        if(safeArea != Screen.safeArea)
        {
            safeArea = Screen.safeArea;
            refreshAnchors();
        }
    }

    void refreshAnchors()
    {
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        rectTransform.anchorMin = ConvertToScreenSize(anchorMin);
        rectTransform.anchorMax = ConvertToScreenSize(anchorMax);
    }

    Vector2 ConvertToScreenSize(Vector2 vec2)
    {
        vec2.x /= Screen.width;
        vec2.y /= Screen.height;
        return vec2;
    }
}
