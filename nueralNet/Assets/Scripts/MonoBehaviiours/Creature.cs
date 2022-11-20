using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    public int hunger;
    public int maxHunger;
    public int thirst;
    public int maxThirst;
    public float movementSpeed;
    public float maxSpeed;
    public int wealth;
    public int wealthToReproduce = 2;

    private int[] DNA = new int[1];

    public void setDNA()
    {
        DNA[0] = Random.Range(1500, 2001);
        maxHunger = DNA[0];
        maxSpeed = ((1000 - maxHunger) * -1) / 75;
        movementSpeed = maxSpeed / 2.5f;
        wealth = 0;
        print(maxHunger);
        print(movementSpeed);
        hunger = 0;
        wealth = 0;
    }
}
