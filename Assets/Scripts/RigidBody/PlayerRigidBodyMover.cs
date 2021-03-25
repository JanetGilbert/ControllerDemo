using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidBodyMover : MonoBehaviour
{
    private Rigidbody rb;


    [SerializeField] private float turnSpeed = 20.0f;
    [SerializeField] private float speed = 20.0f;

    private float horiz;
    private float vert;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Normally physics goes in FixedUpdate, but it's OK to put single applications of force in Update
    void Update()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        if (rb.isKinematic)
        {

        }
        else
        {
            rb.AddTorque(Vector3.up * turnSpeed * horiz); // Add rotation.
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, speed * vert)); // Add force in direction of movement.
        }
    }
}
