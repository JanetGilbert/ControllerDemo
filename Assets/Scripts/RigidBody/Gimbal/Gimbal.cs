using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* These controls make it easy to get into a gimbal lock state
 Gimbal lock is when two axes align, resulting in a loss of one axis of movement.*/
public class Gimbal : MonoBehaviour
{
    // Rotations around axes
    private float roll;
    private float pitch;
    private float yaw;

    void Start()
    {
        
    }

    void Update()
    {
        float hRot = Input.GetAxis("Horizontal"); // A-D
        float vRot = Input.GetAxis("Vertical"); // S-W
        float otherRot = Input.GetAxis("Other"); // O-P

        // Rotates in euler angles - may result in gimbal lock.
        pitch += hRot;
        yaw += vRot; 
        roll += otherRot;

        transform.rotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
