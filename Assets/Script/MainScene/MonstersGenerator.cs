using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersGenerator : MonoBehaviour
{
    public GameObject[] Monsters;
    public GameObject Parent;

    private int MonstersGenerateCount = 0;

    public void MakeMobs(Vector3 Position)
    {
        GameObject obj = Instantiate(Monsters[MonstersGenerateCount], Position, Quaternion.identity,GameObject.Find("Monsters").transform);

        MonstersGenerateCount++;

        if (MonstersGenerateCount == 9)
        {
            MonstersGenerateCount = 0;
        }
    }

    private void Start()
    {
        MakeMobs(new Vector3(600, 443, 0));
        MakeMobs(new Vector3(700, 443, 0));
        MakeMobs(new Vector3(800, 443, 0));
        MakeMobs(new Vector3(900, 443, 0));
        MakeMobs(new Vector3(1000, 443, 0));
        MakeMobs(new Vector3(1100, 443, 0));
        MakeMobs(new Vector3(1200, 443, 0));
    }
}
