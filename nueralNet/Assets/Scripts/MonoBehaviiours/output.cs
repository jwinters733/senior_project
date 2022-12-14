using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class output : MonoBehaviour
{
    string filename = "";

    public void Awake()
    {
        filename = Application.dataPath + "/data.csv";
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("Speed, MaxHunger, Prioritize Food");
        tw.Close();
    }

    public void newCreature(float speed, int hunger, int foodP)
    {
        int coinP = 100 - foodP;
        filename = Application.dataPath + "/data.csv";
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine(speed + "," + hunger + "," + foodP + "," + coinP);
        tw.Close();
    }
}
