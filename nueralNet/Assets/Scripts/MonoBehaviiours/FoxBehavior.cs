using UnityEngine;

public class FoxBehavior : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float maxSpeed = 5.0f;
    public GameObject self;
    public organism myFox;
    Vector2 movement = new Vector2();
    Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {
        changeMovement();
        if(myFox.hunger >= myFox.maxHunger)
        {
            Destroy(self);
        }
    }

    void changeMovement()
    {
        movement.x = Random.Range(- 10, 10);
        movement.y = Random.Range(-10, 10);

        movement.Normalize();
        rb2D.velocity = rb2D.velocity + (movement * movementSpeed);

        rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, maxSpeed);
    }

}
