using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Based on
// https://docs.unity3d.com/Manual/WheelColliderTutorial.html


public class CarController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRightWheel;
    [SerializeField] private WheelCollider frontLeftWheel;
    [SerializeField] private WheelCollider backRightWheel;
    [SerializeField] private WheelCollider backLeftWheel;

    // Controls
    private float rotate;
    private float forward;

    // Steering feel
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        float motor = maxMotorTorque * forward;
        float steering = maxSteeringAngle * rotate;

        frontRightWheel.steerAngle = steering;
        frontLeftWheel.steerAngle = steering;
        backRightWheel.steerAngle = steering;
        backLeftWheel.steerAngle = steering;


        frontRightWheel.motorTorque = motor;
        frontLeftWheel.motorTorque = motor;
    }

    private void Update()
    {
        rotate = Input.GetAxis("Horizontal");
        forward = Input.GetAxis("Vertical");
    }
}
