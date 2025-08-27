using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class CubeAgentFinal : Agent
{
    public GameObject targetPrefab;
    private GameObject currentTarget;
    public GameObject greenZone;
    public float speedMultiplier = 2f;
    private bool targetReached = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        if (this.transform.localPosition.y < 0)
        {
            this.transform.localPosition = new Vector3(0, 0.5f, 0);
            this.transform.localRotation = Quaternion.identity;
        }

        if (currentTarget != null)
        {
            Destroy(currentTarget);
        }

        Vector3 spawnPos = new Vector3(Random.value * 8 - 4, 0.5f, Random.value * 6 - 4);
        currentTarget = Instantiate(targetPrefab, spawnPos, Quaternion.identity);
        targetReached = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        if (currentTarget != null)
            sensor.AddObservation(currentTarget.transform.localPosition);
        else
            sensor.AddObservation(Vector3.zero);
        sensor.AddObservation(this.transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        Vector3 controlSignal = new Vector3(moveX, 0, moveZ) * speedMultiplier;
        rb.MovePosition(rb.position + controlSignal);

        if (currentTarget != null) {
            float distanceToTarget = Vector3.Distance(this.transform.localPosition, currentTarget.transform.localPosition);

            if (distanceToTarget < 1.42f) {
                Debug.Log("Target reached");
                SetReward(0.5f);
                targetReached = true;
                Destroy(currentTarget);
            }
        }
        
        if (rb.position.y < 0)
        {
            Debug.Log("Agent fell of the plane.");
            SetReward(-1.0f);
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;

        continuousActionsOut[0] = Input.GetAxis("Vertical");
        continuousActionsOut[1] = Input.GetAxis("Horizontal");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == greenZone && targetReached)
        {
            Debug.Log("Ending episode");
            SetReward(1.0f);
            EndEpisode();
        }
    }
}
