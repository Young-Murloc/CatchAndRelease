/*
 * 자식 pos를 변경시 localPosition을 사용
 * transform.SetParent를 이용하여 부모 오브젝트 이동 가능
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateMonsterList : MonoBehaviour
{
    public GameObject[] Monsters;                           // 몬스터 프리팹
    public GameObject Missing;                              // 미싱 프리팹
    public GameObject Describe;                             // 묘사 프리팹

    public GameObject[] Parents;
    private Text describeText;

    public MonsterDB MonsterDB;                             // 몬스터 정보 가져오기
    private bool[] isContactInfo = new bool[10];                // 몬스터 10마리
    private string[] monstersDescribeInfo = new string[10];

    private GameObject tempGameObj;

    // Start is called before the first frame update
    void Start()
    {
        isContactInfo = MonsterDB.GetContactInfo();             // 몬스터 만난적 있는지 정보 가져오기
        monstersDescribeInfo = MonsterDB.GetDescribeInfo();     // 몬스터 묘사 정보 가져오기

        for(int i=0; i<10; i++)
        {
            tempGameObj = Instantiate(Describe, new Vector3(0f, 0f, 0f), Quaternion.identity);                 // 묘사 오브젝트 생성
            tempGameObj.transform.SetParent(Parents[i].transform);
            tempGameObj.transform.localPosition = new Vector3(56f, 30f, 0f);

            if (isContactInfo[i])       // 몬스터 생성
            {
                tempGameObj.GetComponent<Text>().text = monstersDescribeInfo[i];                // 묘사 글 저장

                tempGameObj = Instantiate(Monsters[i], new Vector3(0f, 0f, 0f), Quaternion.identity);
                tempGameObj.transform.SetParent(Parents[i].transform);
                tempGameObj.transform.localPosition = new Vector3(-170f, 40f, 0f);

            }
            else                    // 미싱 생성
            {
                tempGameObj = Instantiate(Missing, new Vector3(0f, 0f, 0f), Quaternion.identity);
                tempGameObj.transform.SetParent(Parents[i].transform);
                tempGameObj.transform.localPosition = new Vector3(-155f, 21.5f, 0f);
            }
        }
    }
}
