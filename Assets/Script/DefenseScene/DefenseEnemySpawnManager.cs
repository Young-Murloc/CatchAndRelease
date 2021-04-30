using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseEnemySpawnManager : MonoBehaviour
{
    private DefenseTimeManager DTM;         // 현재 시간을 불러옴

    public GameObject[] Enemy;              // 생성할 적 프리팹 저장

    public GameObject fieldEnemy;

    private Dictionary<int, int> spawnTiming = new Dictionary<int, int>();
    private bool[] checkSpawn = new bool[60];
    private int time;
    private GameObject tempObj;

    // Start is called before the first frame update
    void Start()
    {
        DTM = GameObject.Find("DefenseTimeManager").GetComponent<DefenseTimeManager>();

        for(int i=0; i<60; i++)
        {
            spawnTiming.Add(i, 3);      // 3으로 전부 저장
            checkSpawn[i] = false;
        }

        // 몬스터 스폰 타이밍 저장
        spawnTiming[10] = 0;
        spawnTiming[11] = 1;
        spawnTiming[12] = 2;
        spawnTiming[13] = 0;
        spawnTiming[40] = 1;
        spawnTiming[45] = 2;
        spawnTiming[55] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time = DTM.getTime();
        if(spawnTiming[time] <= 2 && !checkSpawn[time] && time <= 60f)       // 소환 해야함
        {
            checkSpawn[time] = true;

            tempObj = Instantiate(Enemy[spawnTiming[time]], new Vector3(0, 0, 0), Quaternion.identity);
            tempObj.transform.SetParent(fieldEnemy.transform);
            tempObj.transform.localPosition = new Vector2(-205, 200);
        }
    }
}
