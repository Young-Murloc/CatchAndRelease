using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentManager : MonoBehaviour
{
    public GameObject[] parents = new GameObject[2];


    private void Update()
    {
        for(int i=0; i<parents[0].transform.childCount; i++)
        {
            Debug.Log(parents[0].transform.GetChild(i).name);
        }
    }

}
