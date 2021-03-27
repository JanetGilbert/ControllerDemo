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

    [SerializeField] private GameObject frontRightWheelV;
    [SerializeField] private GameObject frontLeftWheelV;
    [SerializeField] private GameObject backRightWheelV;
    [SerializeField] private GameObject backLeftWheelV;


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

        frontRightWheel.motorTorque = motor;
        frontLeftWheel.motorTorque = motor;
    }

    private void Update()
    {
        rotate = Input.GetAxis("Horizontal");
        forward = Input.GetAxis("Vertical");

        RotateVisibleWheel(frontRightWheelV, frontRightWheel);
        RotateVisibleWheel(frontLeftWheelV, frontLeftWheel);
        RotateVisibleWheel(backRightWheelV, backRightWheel);
        RotateVisibleWheel(backLeftWheelV, backLeftWheel);
    }


    public void RotateVisibleWheel(GameObject wheel, WheelCollider collider)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        wheel.transform.position = position;
        wheel.transform.rotation = rotation;

        wheel.transform.rotation *= Quaternion.Euler(0.0f, 0.0f, 90.0f); // Cylider is wrong way round.
    }
}
