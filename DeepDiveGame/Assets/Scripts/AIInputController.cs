using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputController : MonoBehaviour
{
    [Header("Input Variables")]
    Car car;

    Wheel wl;
    public float forwards;
    public float turn;
    public float braking;
    public float currentspeed;
    public bool canactivate;
    public float timeleft = 10f;
    public Material brakeLight;

    [Header("Level Variables")]
    private Transform targetPositionTransform;
    public GameObject[] checkPoints;
    public GameObject currentCheckPoint;
    public int checkPointCounter = 0;

    void Awake()
    {
        car = GetComponent<Car>();
        wl = GetComponent<Wheel>();
        targetPositionTransform = checkPoints[0].transform;
        car.disablebrake(0);
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = targetPositionTransform.position;
        //float forwards = forwardsinput;
        float turn = 0;

        Vector3 directionToTarget = (targetPosition - transform.position);
        float dot = Vector3.Dot(transform.forward, directionToTarget);

        float distance = Vector3.Distance(transform.position, targetPosition);
        float minDistance = 15;

        if (distance > minDistance)
        {
            if (dot > 0)
            {
                forwards = 1;
            }
            else if (dot < 0)
            {
                forwards = -1;
            }


            float angle = Vector3.SignedAngle(transform.forward, directionToTarget, Vector3.up);

            if (angle > 5)
            {
                turn = 1;
            }
            if (angle < -5)
            {
                turn = -1;
            }
        }
        else 
        { 
            targetPositionTransform = NextCheckpoint().transform;
        }

        if (car.currentspeed < 20)
        {
            car.disablebrake(0);
        }

        car.ChangeSpeed(car.motorTorque, forwards);
        car.Turn(turn);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AIBrakePoint"))
        {
            car.activatebrake(car.brakeForce);
            brakeLight.SetColor("_Color", Color.red * 10);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AIBrakePoint"))
        {
            car.disablebrake(0);
            brakeLight.SetColor("_Color", Color.red);
        }
    }

    public GameObject NextCheckpoint()

    {
        checkPointCounter++;
        if (checkPointCounter >= checkPoints.Length)
        {
            checkPointCounter = 0;
        }
        currentCheckPoint = checkPoints[checkPointCounter];
        return currentCheckPoint;
    }
}
