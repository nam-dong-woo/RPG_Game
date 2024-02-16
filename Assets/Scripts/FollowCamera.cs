using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
   public Transform playerTransform;
   public Transform cameraTransform;
   public Vector3 offset;

    private void Start()
    {
        offset = playerTransform.position - cameraTransform.position;
    }

    private void LateUpdate()
    {
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, playerTransform.position - offset, Time.deltaTime);
    }
}