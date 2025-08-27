using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class JumperAgent : Agent
{
    private Rigidbody rb;

    public float jumpForce = 6f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(0,0.5f,0);
        rb.linearVelocity = Vector3.zero;

        foreach (var obj in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Destroy(obj);
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(rb.linearVelocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float jump = actions.ContinuousActions[0];
        if (jump > 0.5f && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            AddReward(-0.01f);
        }

        AddReward(0.001f);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetKey(KeyCode.Space) ? 1f : 0f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collided with obstacle");
            AddReward(-1f);
            EndEpisode();
        }
    }
    public void OnObstacleCleared()
    {
        Debug.Log("Survived an obstacle");
        AddReward(+0.5f);
    }
}
