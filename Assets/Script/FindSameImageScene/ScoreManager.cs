using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public MonsterManager MM;
    public ShowScore SS;
    public UiManager UM;

    private int count = 0;          // 카드 픽한 갯수
    private int[] monsterNumber = new int[2];

    private GameObject btnObj1;
    private GameObject btnObj2;

    private GameObject monster1;
    private GameObject monster2;

    private float score;

    private void Start()
    {
        MM = GameObject.Find("MonsterManager").GetComponent<MonsterManager>();
        SS = GameObject.Find("UiManager").GetComponent<ShowScore>();
        UM = GameObject.Find("UiManager").GetComponent<UiManager>();
    }

    public void setMonstersInfo(int number, GameObject buttonObj, GameObject monsterObj)
    { 
        count++;

        if (count == 1)
        {
            monsterNumber[0] = number;
            btnObj1 = buttonObj;
            monster1 = monsterObj;
        }
        else
        {
            monsterNumber[1] = number;
            btnObj2 = buttonObj;
            monster2 = monsterObj;
            MM.setIsOpenTrue();                 // 2개가 보여지는 상황에서 다른 카드 뒤집지 못하기 위한 변수 설정 함수
        }

        StartCoroutine("Delay");
    }

    private void sendScore()
    {
        score = 1f;
        SS.setScoreNumber(score);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);

        if (count == 2)
        {   // 시간 지연 시키기
            count = 0;

            if (monsterNumber[0] == monsterNumber[1])        // 두 카드가 일치
            { 
                sendScore();
            }
            else
            {
                Destroy(monster1);
                Destroy(monster2);
                UM.setActiveTrueCard(btnObj1);
                UM.setActiveTrueCard(btnObj2);
            }
        }

        MM.setIsOpenFalse();
    }
}
