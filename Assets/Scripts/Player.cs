using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb; // Reference to the Rigidbody2D component of the player
    public float thrust = 1f;
    public float maxSpeed = 5f; // Maximum speed of the player

    public float elapsedTime = 0f; // Time elapsed since the last frame
    private float score = 0f; // Player's score 
    public float scoreMultiplier = 10f; // Multiplier for the score based on elapsed time

    public UIDocument uiDocument; // Reference to the UI Document component
    private Label scoreText; // Reference to the score label in the UI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel"); // Get the score label from the UI Document
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            // Cálculo da direção do mouse em relação ao jogador
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value); 
            Vector2 direction = (mousePos - transform.position).normalized;

            // Rotaciona o jogador para olhar na direção do mouse
            transform.up = direction; // Rotate the player to face the mouse position
            rb.AddForce(direction * thrust); // Apply force to the player in the direction of the mouse position

            animator.SetBool("isMoving", true); // Set the "isMoving" parameter to true in the Animator
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            animator.SetBool("isMoving", false); // Set the "isMoving" parameter to false in the Animator
        } 

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed; // Limit the player's speed to maxSpeed

        }

        elapsedTime += Time.deltaTime; // Update the elapsed time since the last frame
        score = elapsedTime * scoreMultiplier; // Update the player's score based on elapsed time and score multiplier
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier); // Round the score down to the nearest integer
        scoreText.text = "Score: " + score;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject); // Destroy the player object when it collides with an obstacle
        }
    }
}
