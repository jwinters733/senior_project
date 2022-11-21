using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replicate : MonoBehaviour
{
    private Stack<int[]> DNAList = new Stack<int[]>();

    public void storeParentDNA(int[] DNAStore)
    {
        print("Parent " + DNAStore[0]);
        DNAList.Push(DNAStore);
    }

    public void getParentDNA(int[] childDNA)
    {
        if (DNAList.Count > 0)
        {
            int[] parentDNA = DNAList.Pop();
            for(int i=0; i < (childDNA.Length); i++)
            {
                childDNA[i] = parentDNA[i];
            }
        } else
        {
            childDNA[0] = Random.Range(1500, 3001);
        }
    }
}
