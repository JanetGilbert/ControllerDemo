using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller based on rigidbody (either kinematic or non-kinematic)
// Kinematic version goes through walls!
public class PlayerRigidBodyMover : MonoBehaviour
{
    //Cache
    private Rigidbody rb;

    // Set in editor
    [SerializeField] private float turnSpeed = 20.0f;
    [SerializeField] private float speed = 20.0f;

    // Controls
    private float rotate;
    private float forward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Physics goes in FixedUpdate
    private void FixedUpdate()
    {
        if (rb.isKinematic)
        {
            rb.MovePosition(rb.position + (transform.forward * speed * forward * Time.fixedDeltaTime));
            rb.MoveRotation(Quaternion.AngleAxis(rotate * turnSpeed, Vector3.up) * rb.rotation);
        }
    }

    // Normally physics goes in FixedUpdate, but it's OK to put single applications of force in Update
    void Update()
    {
        rotate = Input.GetAxis("Horizontal");
        forward = Input.GetAxis("Vertical");

        if (!rb.isKinematic)
        {
            rb.AddTorque(Vector3.up * turnSpeed * rotate); // Add rotation.
            rb.AddRelativeForce(new Vector3(0.0f, 0.0f, speed * forward)); // Add force in direction of movement.
        }
    }
}
