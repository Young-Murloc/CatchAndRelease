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
        MakeMobs(new Vector3(49, 443, 0));
        MakeMobs(new Vector3(149, 443, 0));
        MakeMobs(new Vector3(249, 443, 0));
        MakeMobs(new Vector3(349, 443, 0));
        MakeMobs(new Vector3(449, 443, 0));
        MakeMobs(new Vector3(549, 443, 0));
        MakeMobs(new Vector3(649, 443, 0));
    }
}
