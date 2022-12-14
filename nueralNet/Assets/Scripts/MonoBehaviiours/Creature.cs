using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    public int hunger;
    public int maxHunger;
    public int thirst;
    public int maxThirst;
    public float movementSpeed;
    public int foodP;
    public int wealth;
    public int wealthToReproduce = 2;
    public replicate replObj;

    public int[] DNA;

    public void setDNA()
    {
        DNA = new int[2];
        replObj.getParentDNA(DNA);

        int DNAMutation = Random.Range(-100, 101);
        DNA[0] = DNA[0] + DNAMutation;
        DNAMutation = Random.Range(-10, 11);
        DNA[1] = DNA[1] + DNAMutation;

        if (DNA[0] > 3000)
        {
            DNA[0] = 3000;
        }
        if (DNA[0] < 500)
        {
            DNA[0] = 500;
        }

        if (DNA[1] > 100)
        {
            DNA[1] = 100;
        }
        if (DNA[1] < 0)
        {
            DNA[1] = 0;
        }

        maxHunger = DNA[0];
        movementSpeed = (3500 - DNA[0]) / 2.5f;
        foodP = DNA[1];
        wealth = 0;
        hunger = 0;
    }

    public int[] getDNA()
    {
        return DNA;
    }
}
