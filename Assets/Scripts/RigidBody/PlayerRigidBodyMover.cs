using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidBodyMover : MonoBehaviour
{
    private Rigidbody rb;


    [SerializeField] private float torque = 20.0f;
    [SerializeField] private float speed = 20.0f;

    // Controls
    private float turn;
    private float move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Physics goes in FixedUpdate

    private void FixedUpdate()
    {
        // AddRelativeTorque/Force relates to the object; AddTorque/Force relates to the world.
        rb.AddTorque(Vector3.up * torque * turn);
        rb.AddRelativeForce(new Vector3(0.0f, 0.0f, move * speed));

        turn = 0.0f;
        move = 0.0f;
    }


    // Input goes in update, because FixedUpdate may not be called every frame, meaning you might miss fast keypresses.
    void Update()
    {
         float horiz = Input.GetAxis("Horizontal");
         float vert = Input.GetAxis("Vertical");

        turn = (horiz != 0.0f) ? horiz : turn;
        move = (vert != 0.0f) ? vert : move;
    }
}
