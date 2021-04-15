using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonsterManager : MonoBehaviour
{
    public ScoreManager SM;
    public UiManager UM;

    public GameObject[] monstersPrefab;
    public GameObject cardBack;

    private int[] monsterCardList = new int[20];
    private int monsterCardPos;

    public GameObject parentCard;
    public GameObject parentMonster;

    private GameObject tempObj;
    private Button btnObj;
    private string pickCardName;

    private GameObject buttonObj;
    private GameObject monsterObj;

    private bool isOpen = false;

    // x,y 주의
    private int[] cardPosX = new int[5] { 120, 50, -20, -90, -160 };
    private int[] cardPosY = new int[4] { -110, -40, 30, 100 };


    int x, y, z;

    // Start is called before the first frame update
    void Start()        // 카드에 들어갈 몬스터 배열 선언 후 카드(버튼) 생성
    {
        SM = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        UM = GameObject.Find("UiManager").GetComponent<UiManager>();

        for(int i=0; i<20; i++)         // 몬스터 카드 에 들어갈 몬스터들 저장
        {
            while (true)
            {
                monsterCardPos = Random.Range(0, 20);
                z = i / 2;

                if(monsterCardList[monsterCardPos] == 0)
                {
                    monsterCardList[monsterCardPos] = z;
                    break;
                }
            }
        }

        int count = 0;          // 이름

        for(int i=0; i<5; i++)
        {
            for(int j=0; j<4; j++)
            {
                tempObj = Instantiate(cardBack, new Vector3(0f, 0f, 0f), Quaternion.identity);
                tempObj.name = count.ToString();
                count++;
                tempObj.transform.SetParent(parentCard.transform);
                tempObj.transform.localPosition = new Vector3(cardPosY[j], cardPosX[i], 0f);
                btnObj = tempObj.GetComponent<Button>();
                btnObj.onClick.AddListener(() => sendMonsterImage());
            }
        }
    }

    private void sendMonsterImage()
    {
        if (!isOpen)
        {
            pickCardName = EventSystem.current.currentSelectedGameObject.name;
            buttonObj = GameObject.Find(pickCardName);
            UM.setActiveFalseCard(buttonObj);            // 선택된 카드 false 처리 -> 나중에 뒤집는 모션 추가하기

            Vector3 pos = buttonObj.transform.localPosition;

            monsterObj = Instantiate(monstersPrefab[monsterCardList[int.Parse(pickCardName)]], new Vector3(0f, 0f, 0f), Quaternion.identity);      //몬스터
            monsterObj.transform.SetParent(parentMonster.transform);
            monsterObj.name = "m" + pickCardName;
            monsterObj.transform.localPosition = pos;

            SM.setMonstersInfo(monsterCardList[int.Parse(pickCardName)], buttonObj, monsterObj);
        }
    }

    public void setIsOpenTrue()
    {
        isOpen = true;
    }

    public void setIsOpenFalse()
    {
        isOpen = false;
    }
}