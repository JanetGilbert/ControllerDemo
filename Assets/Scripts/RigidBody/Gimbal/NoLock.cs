using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class converts the input directly into a Quaternion rather than storing it as Euler angles.
 * This avoids Gimbal lock */
public class NoLock : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        float hRot = Input.GetAxis("Horizontal"); // A-D
        float vRot = Input.GetAxis("Vertical"); // S-W
        float otherRot = Input.GetAxis("Other"); // O-P

        transform.rotation *= Quaternion.Euler(hRot, vRot, otherRot); // Multiply Quaternions to apply rotation.
    }
}
