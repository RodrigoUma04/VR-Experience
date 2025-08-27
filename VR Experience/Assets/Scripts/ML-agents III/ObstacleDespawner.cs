using UnityEngine;

public class ObstacleDespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Despawner"))
        {
            JumperAgent agent = FindFirstObjectByType<JumperAgent>();
            if (agent != null)
            {
                agent.OnObstacleCleared();
            }

            Destroy(gameObject);
        }
    }
}