using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Obstacles : MonoBehaviour
{
    
    public float minSize = 0.5f; // Minimum size of the obstacle
    public float maxSize = 2f; // Maximum size of the obstacle
    public Rigidbody2D rb; // Reference to the Rigidbody2D component of the obstacle
    public float minSpeed = 1f;   
    public float maxSpeed = 4f; // Speed of the obstacle's movement
    public float maxSpinSpeed = 40f; // Maximum spin speed of the obstacle

    private float currentSpeed;

    public GameObject bounceEffectPrefab; // Prefab of the bounce effect to be instantiated


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize); // Generate a random size between minSize and maxSize
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed); // Generate a random torque value for the obstacle
        Vector2 randomDirection = Random.insideUnitCircle;

        transform.localScale = new Vector3(randomSize, randomSize, 1); // Set the scale of the obstacle to the random size

        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the obstacle

        rb.AddForce(randomDirection * randomSpeed);
        rb.AddTorque(randomTorque);

        rb.linearVelocity = randomDirection * randomSpeed; // Set the linear velocity of the obstacle to the random speed in the random direction

        currentSpeed = randomSpeed; // Store the current speed of the obstacle for later use
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed; // Limit the obstacle's speed to maxSpeed
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = rb.linearVelocity.normalized * currentSpeed; // Maintain the current speed of the obstacle after collision

        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            GameObject bounceEffect = Instantiate(bounceEffectPrefab, contactPoint, Quaternion.identity);

            // Destroy the effect after 1 second
            Destroy(bounceEffect, 1f);
        }
    }
}
