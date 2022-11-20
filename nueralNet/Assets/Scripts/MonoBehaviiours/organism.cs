using UnityEngine;

public class organism : Creature
{
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null){
                print("hit: " + hitObject.itemType);
                collision.gameObject.SetActive(false);
            }
        }
    }
}
