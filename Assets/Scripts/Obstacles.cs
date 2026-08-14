using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Obstacles : MonoBehaviour
{
    
    public float minSize = 0.5f; // Minimum size of the obstacle
    public float maxSize = 2f; // Maximum size of the obstacle
    public Rigidbody2D rb; // Reference to the Rigidbody2D component of the obstacle
    public float minSpeed = 10f;   
    public float maxSpeed = 30f; // Speed of the obstacle's movement
    public float minTorque = -40f; // Minimum torque value for the obstacle
    public float maxTorque = 40f; // Maximum torque value for the obstacle


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomSize = Random.Range(minSize, maxSize); // Generate a random size between minSize and maxSize

        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        
        float randomTorque = Random.Range(minTorque, maxTorque); // Generate a random torque value for the obstacle

        Vector2 randomDirection = Random.insideUnitCircle * 2;

        transform.localRotation = Quaternion.Euler(1, 1, randomTorque);

        transform.localScale = new Vector3(randomSize, randomSize, 1); // Set the scale of the obstacle to the random size

        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the obstacle

        rb.AddForce(randomDirection * randomSpeed);

        rb.AddTorque(randomTorque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
