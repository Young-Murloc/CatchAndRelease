using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemy;

    private GameObject tempObj;
    private Vector2 tempV = new Vector2(7f, 2f);

    // Start is called before the first frame update
    void Start()
    {
        generateEnemy();
    }

    private void generateEnemy()
    {
        for(int i=0; i<enemy.Length; i++)
        {
            tempObj = Instantiate(enemy[i], new Vector2(0f, 0f), enemy[i].transform.rotation);
            tempObj.transform.SetParent(this.transform);
            tempObj.transform.localPosition = tempV;
            tempObj.transform.localScale = new Vector2(5f, 5f);
            tempObj.name = enemy[i].name;
        }
    }
}
