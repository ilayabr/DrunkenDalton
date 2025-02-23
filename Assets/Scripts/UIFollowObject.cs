using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowObject : MonoBehaviour
{
    public Transform target3D;
    public RectTransform uiElement;
    public Camera mainCamera;
    public Vector3 offset = new Vector3(0, 200, 0);

    void LateUpdate()
    {
        if (target3D == null || uiElement == null || mainCamera == null)
            return;
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(target3D.position);
        if (!GameObject.Find(target3D.gameObject.name).GetComponent<EnemyBehavior>().GetIsHit() && screenPosition.z > 0)
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