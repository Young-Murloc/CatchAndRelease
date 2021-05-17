using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyManagerScript : MonoBehaviour
{
    public GameObject[] ally;

    private Vector2[] allyPos = new Vector2[] { new Vector2(0, -1f), new Vector2(1, -1f), new Vector2(2, -1f), new Vector2(3, -1f), new Vector2(4, -1f)};

    // Start is called before the first frame update
    void Start()
    {
        spawnAlly();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnAlly()
    {
        GameObject tempObj;

        for(int i=0; i<allyPos.Length; i++)
        {
            tempObj = Instantiate(ally[i], allyPos[i], Quaternion.identity);
            tempObj.transform.SetParent(transform);
        }
    }
}
