using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float mouseSensitivity = 3.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    public float rotation = 0.0f;

    void Update()
    {
        // += if *-1, or -= if not
        // save/update rotation for "set to y degrees"
        // remove +/- from = if "adjust by y degrees"
        rotation += Input.GetAxis("Mouse Y") * -1 * mouseSensitivity;
        Debug.Log(rotation);

        rotation  = Mathf.Clamp(rotation, minimumVert, maximumVert);

        // allows infinite Y-axis movement
        // transform.Rotate(rotation, 0, 0);
        
        // restricts Y-axis to +/- 45 degrees
        float rotationY = transform.localEulerAngles.y;
        // these values are read-only, so need a new Vector3 each time
        // cannot update in-place   
        transform.localEulerAngles = new Vector3(rotation, rotationY, 0);    
    }
}
