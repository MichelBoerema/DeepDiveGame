using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool Steer;
    public bool Invertsteer;
    public bool Power;
    public bool brake;
    public float brakeForce = 100f;
    public float Steerangle { get; set; }
    public float Torque { get; set; }

    private WheelCollider wheelCollider;
    private Transform wheelTransform;
    void Start()
    {
        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();
    }

    void Update()
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
    void FixedUpdate()
    {
        if (Steer)
        {
            wheelCollider.steerAngle = Steerangle * (Invertsteer ? 1 : -1);

        }
        if (Power)
        {
            wheelCollider.motorTorque = Torque;
        }
        if (brake)
        {
            wheelCollider.brakeTorque = brakeForce;
        }
        else
        {
            brakeForce = 0f;
        }
    }
}
