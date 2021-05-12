using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject[] enemy;      // 몬스터 프리팹

    private Vector2[] enemyPos = new Vector2[] {new Vector2(0,7f), new Vector2(1,7f), new Vector2(2, 7f), new Vector2(3, 7f), new Vector2(4, 7f) };

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnEnemy()
    {
        GameObject tempObj;

        for(int i=0; i<enemyPos.Length; i++)
        {
            tempObj = Instantiate(enemy[i], enemyPos[i], Quaternion.identity);
            tempObj.transform.SetParent(transform);
        }
    }
}