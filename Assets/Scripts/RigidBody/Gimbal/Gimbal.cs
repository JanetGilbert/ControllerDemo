using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* These controls make it easy to get into a gimbal lock state*/
public class Gimbal : MonoBehaviour
{
   
    float roll;
    float pitch;
    float yaw;

    void Start()
    {
        
    }

    void Update()
    {
        float hRot = Input.GetAxis("Horizontal"); // AD
        float vRot = Input.GetAxis("Vertical"); // SW
        float otherRot = Input.GetAxis("Other"); // OP

        pitch += hRot;
        yaw += vRot; 
        roll += otherRot;

        transform.rotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
