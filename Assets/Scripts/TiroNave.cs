using UnityEngine;

public class TiroNave : MonoBehaviour
{
    public float velocidadeTiro = 10f; // Speed of the projectile

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.up * velocidadeTiro; // Set the projectile's velocity based on its speed and direction
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.SetParent(null); // Set the projectile's parent to the wall it collided with
            Destroy(gameObject); // Destroy the projectile after it hits in the wallS
        }
    }
}
