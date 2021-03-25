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
        float hRot = Input.GetAxis("Horizontal"); // AD
        float vRot = Input.GetAxis("Vertical"); // SW
        float otherRot = Input.GetAxis("Other"); // OP

        transform.rotation *= Quaternion.Euler(hRot, vRot, otherRot); // Multiply Quaternions to apply rotation.
    }
}
