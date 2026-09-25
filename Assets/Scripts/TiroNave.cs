using UnityEngine;

public class TiroNave : MonoBehaviour
{
    public float velocidadeTiro = 10f; // Speed of the projectile
    Rigidbody2D rb; // Reference to the Rigidbody2D component of the projectile


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>()
        .AddForce(transform.up * velocidadeTiro, ForceMode2D.Impulse); // Apply an impulse force to the projectile in the direction it is facing
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Freeze the projectile's rotation to prevent it from spinning
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destroy the projectile after it hits in the wallS
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject); // Destroy the projectile after it hits in the obstacles
            Destroy(gameObject); // Destroy the projectile after it hits in the obstacles
        }
    }
}
