using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnPoint;
    public float minSpeed = 10f;
    public float maxSpeed = 25f;
    public float spawnInterval = 4f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab, new Vector3(spawnPoint.position.x, 0.5f, spawnPoint.position.z), Quaternion.identity);
        Rigidbody rb = obstacle.GetComponent<Rigidbody>();

        Vector3 direction = Vector3.right;
        float speed = Random.Range(minSpeed, maxSpeed);
        rb.linearVelocity = direction * speed;
    }
}
