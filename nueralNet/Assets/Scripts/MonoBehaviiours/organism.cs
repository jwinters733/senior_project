using UnityEngine;

public class organism : Creature
{
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                print("hit: " + hitObject.itemType);

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        break;

                    case Item.ItemType.FOOD:
                        AdjustHunger(hitObject.value);
                        break;
                    default:
                        break;
                }
                collision.gameObject.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        AdjustHunger(1);
    }

    public void AdjustHunger(int amount)
    {
        hunger = hunger + amount;
    }
}
