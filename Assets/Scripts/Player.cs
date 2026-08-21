using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb; // Reference to the Rigidbody2D component of the player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Debug.Log("Mouse Position: " + mousePos);


        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); // Destroy the player object when it collides with an obstacle
        }
    }
}
