using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsGenerator : MonoBehaviour
{
    public GameObject[] Mobs;
    public GameObject Parent;

    private int MobGenerateCount = 0;

    public void MakeMobs(Vector3 Position)
    {
        GameObject obj = Instantiate(Mobs[MobGenerateCount], Position, Quaternion.identity,GameObject.Find("Mobs").transform);

        MobGenerateCount++;

        if (MobGenerateCount == 9)
        {
            MobGenerateCount = 0;
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
