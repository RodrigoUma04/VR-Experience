using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ) * speed;

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
