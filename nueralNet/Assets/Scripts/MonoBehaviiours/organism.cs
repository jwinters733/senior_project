using UnityEngine;

public class organism : Creature
{
    public FoxBehavior myFox;


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        AdjustWealth(1);
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

    public void AdjustWealth(int amount)
    {
        wealth = wealth + amount;
    }
}
