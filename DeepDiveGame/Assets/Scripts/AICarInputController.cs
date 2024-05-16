using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICarInputController : MonoBehaviour
{
    private Car car;
    public NavMeshAgent agent;

    public Transform[] checkPoints; 
    private int currentCheckPointIndex = 0; 
    private bool isChangingGear = false;
    private float clutch = 1f;
    public AnimationCurve hpToRPMCurve;

    public float maxTorque = 1500f;
    public float maxRPM = 7000f;
    public float idleRPM = 1000f;
    public float gearChangeTime = 1f;

    private void Start()
    {
        car = GetComponent<Car>();
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing!");
            return;
        }

        
        if (!agent.enabled)
        {
            Debug.LogError("NavMeshAgent component is not enabled!");
            return;
        }

        
        GameObject[] checkpointObjects = GameObject.FindGameObjectsWithTag("Checkpoints");
        checkPoints = new Transform[checkpointObjects.Length];
        for (int i = 0; i < checkpointObjects.Length; i++)
        {
            checkPoints[i] = checkpointObjects[i].transform;
        }

        
        System.Array.Sort(checkPoints, (a, b) => a.name.CompareTo(b.name));

        if (checkPoints.Length > 0)
        {
            
            if (agent.isOnNavMesh)
            {
                agent.SetDestination(checkPoints[currentCheckPointIndex].position);
            }
            else
            {
                Debug.LogError("NavMeshAgent is not on a NavMesh! Check if the NavMesh is properly baked and covers the starting position.");
            }
        }
        else
        {
            Debug.LogError("No checkpoints found!");
        }
    }

    private void Update()
    {
        
        if (agent == null || !agent.isOnNavMesh)
        {
            Debug.LogError("NavMeshAgent is not active or not on a NavMesh!");
            return;
        }

        
        if (!agent.pathPending && agent.remainingDistance < 1f)
        {
            GoToNextCheckpoint();
        }

        
        Vector3 directionToTarget = checkPoints[currentCheckPointIndex].position - transform.position;
        float distanceToTarget = directionToTarget.magnitude;
        directionToTarget.Normalize();

        
        Vector3 localTarget = transform.InverseTransformPoint(checkPoints[currentCheckPointIndex].position);
        float forward = Mathf.Clamp(localTarget.z, 0, 1);

        float targetSpeed = distanceToTarget > 10 ? 1f : 0.5f;
        car.ChangeSpeed(CalculateTorque(targetSpeed), forward);
        car.Turn(localTarget.x / localTarget.magnitude);
    }

    private void GoToNextCheckpoint()
    {
        currentCheckPointIndex = (currentCheckPointIndex + 1) % checkPoints.Length;
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(checkPoints[currentCheckPointIndex].position);
        }
        else
        {
            Debug.LogError("NavMeshAgent is not on a NavMesh!");
        }
    }

    private float CalculateTorque(float forward)
    {
        float rpm = Mathf.Lerp(idleRPM, maxRPM, forward);
        float torque = hpToRPMCurve.Evaluate(rpm / maxRPM) * maxTorque;
        return torque * clutch;
    }
}


