using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    public GameObject target3D;
    public RectTransform uiElement;
    public Camera mainCamera;
    
    void LateUpdate()
    {
        if (target3D == null || uiElement == null || mainCamera == null)
            return;
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(target3D.transform.position);
        uiElement.position = screenPosition;
    }
}
