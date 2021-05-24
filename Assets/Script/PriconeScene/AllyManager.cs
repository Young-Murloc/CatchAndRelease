using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyManager : MonoBehaviour
{
    public GameObject[] ally;

    private GameObject tempObj;
    private Vector2 tempV = new Vector2(-7f, 2f);

    // Start is called before the first frame update
    void Start()
    {
        generateAlly();
    }

    private void generateAlly()
    {
        for(int i=0; i<ally.Length; i++)
        {
            tempObj = Instantiate(ally[i], new Vector2(0f, 0f), ally[i].transform.rotation);
            tempObj.transform.SetParent(this.transform);
            tempObj.transform.localPosition = tempV;
            tempObj.transform.localScale = new Vector2(5f, 5f);
        }
    }
}
