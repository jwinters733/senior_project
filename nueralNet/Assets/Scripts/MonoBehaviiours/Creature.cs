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

        int DNAMutation = Random.Range(-100, 101);
        DNA[0] = DNA[0] + DNAMutation;

        if (DNA[0] > 3000)
        {
            DNA[0] = 3000;
        }
        if (DNA[0] < 1500)
        {
            DNA[0] = 1500;
        }
        print("Child" + DNA[0]);

        maxHunger = DNA[0];
        movementSpeed = ((1000 - maxHunger) * -1);
        wealth = 0;
        hunger = 0;
        wealth = 0;
    }

    public int[] getDNA()
    {
        return DNA;
    }
}
