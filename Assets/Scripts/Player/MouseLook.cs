using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxis {
        MouseX = 0,
        MouseY = 1,
        MouseXandY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;
    public float mouseSensitivity = 3.0f;

    void Update()
    {
        transform.Rotate(
            0, // Input.GetAxis("Mouse Y") * -1 * mouseSensitivity,
            Input.GetAxis("Mouse X") * mouseSensitivity,
            0);
    }
}
