using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float smoothspeed;
    [SerializeField] private Vector3 offset;
    public Transform Target;

    private void LateUpdate() //ensure smooth transition of camera from object to object
    {
        Vector3 desiredPosition = Target.position + offset;
        Vector3 smoothenedposition = Vector3.Lerp(cam.transform.position, desiredPosition, smoothspeed);
        cam.transform.position = smoothenedposition;
    }
}
