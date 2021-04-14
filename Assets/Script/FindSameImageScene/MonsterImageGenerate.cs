using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterImageGenerate : MonoBehaviour
{
    public GameObject[] monstersPrefab;
    public GameObject cardBack;

    private int[,] monsterCardList = new int[5, 4];
    public GameObject Parent;
    private GameObject tempObj;

    // x,y 주의
    private int[] cardPosX = new int[5] { 120, 50, -20, -90, -160 };
    private int[] cardPosY = new int[4] { -110, -40, 30, 100 };


    int x, y, z;

    // Start is called before the first frame update
    void Start()        // 카드에 들어갈 몬스터 배열 선언 후 카드(버튼) 생성
    {
        for(int i=0; i<20; i++)         // 몬스터 카드 에 들어갈 몬스터들 저장
        {
            while (true)
            {
                x = Random.Range(0, 5);
                y = Random.Range(0, 4);
                z = i / 2;

                if(monsterCardList[x,y] == 0)
                {
                    monsterCardList[x, y] = z;
                    break;
                }
            }
        }

        for(int i=0; i<5; i++)
        {
            for(int j=0; j<4; j++)
            {
                tempObj = Instantiate(cardBack, new Vector3(0f, 0f, 0f), Quaternion.identity);
                tempObj.transform.SetParent(Parent.transform);
                tempObj.transform.localPosition = new Vector3(cardPosY[j], cardPosX[i], 0f);
            }
        }
    }
}
