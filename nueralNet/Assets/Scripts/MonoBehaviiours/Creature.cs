using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    public int hunger;
    public int maxHunger;
    public int thirst;
    public int maxThirst;
    public float movementSpeed;
    public int wealth;
    public int wealthToReproduce = 2;
    public replicate replObj;

    public int[] DNA = new int[1];

    public void setDNA()
    {
        replObj.getParentDNA(DNA);
        maxHunger = DNA[0];
        movementSpeed = ((1000 - maxHunger) * -1);
        print(movementSpeed);
        wealth = 0;
        hunger = 0;
        wealth = 0;
    }

    public int[] getDNA()
    {
        return DNA;
    }
}
