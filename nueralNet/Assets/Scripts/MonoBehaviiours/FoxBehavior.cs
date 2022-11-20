using UnityEngine;

public class FoxBehavior : MonoBehaviour
{
    private float movementSpeed;
    private float maxSpeed;
    public GameObject self;
    public organism myFox;
    Vector2 movement = new Vector2();
    Rigidbody2D rb2D;

    private void Awake()
    {
        myFox.setDNA();
        rb2D = GetComponent<Rigidbody2D>();
        movementSpeed = myFox.movementSpeed;
        maxSpeed = myFox.maxSpeed;
    }

    void FixedUpdate()
    {
        changeMovement();
        if(myFox.hunger >= myFox.maxHunger)
        {
            Destroy(self);
        }
        if(myFox.wealth >= myFox.wealthToReproduce)
        {
            reproduce();
            myFox.AdjustWealth(-1 * myFox.wealthToReproduce);
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

    void reproduce()
    {
        Instantiate(self, rb2D.position + new Vector2(1, 1), Quaternion.identity);
    }

}
