using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowObject : MonoBehaviour
{
    public GameObject target3D;
    public RectTransform uiElement;
    public Camera mainCamera;
    public Vector3 offset = new Vector3(0, 100, 0);

    void LateUpdate()
    {
        if (target3D == null || uiElement == null || mainCamera == null)
            return;
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(target3D.transform.position);
        if (!target3D.GetComponent<EnemyBehavior>().GetIsHit() && screenPosition.z > 0)
        {
            uiElement.position = screenPosition + offset;
            uiElement.gameObject.SetActive(true);
        }

        else
        {
            uiElement.gameObject.SetActive(false);
        }
    }
}