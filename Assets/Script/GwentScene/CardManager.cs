using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] parents = new GameObject[2];

    private int posX = -200;

    //게롤트
    private int geraltHp;
    private int geraltArmor;

    public void geraltPlace()
    {
        
    }

    public void geraltActive()
    {

    }

    public void setGeraltStat(int hp, int armor)
    {
        geraltHp += hp;
        geraltArmor += armor;
    }

    //트리스
    private int trissHp;
    private int trissArmor;

    public void TrissPlace()
    {

    }

    public void TrissActive()
    {

    }

    public void setTrissStat(int hp, int armor)
    {
        trissHp += hp;
        trissArmor += armor;
    }

    //예니퍼
    private int yenneferHp;
    private int YenneferArmor;

    public void YenneferPlace()
    {

    }

    public void YenneferActive()
    {

    }

    public void setYenneferStat(int hp, int armor)
    {
        yenneferHp += hp;
        YenneferArmor += armor;
    }

    //토큰
    private int tokenHp;
    private int tokenArmor;

    public void TokenActive(GameObject tempObj)
    {
        if(tempObj.transform.parent.name == "BlueFront")
        {
            tempObj.transform.SetParent(parents[1].transform);
        }
        else
        {
            tempObj.transform.SetParent(parents[0].transform);
        }

        for (int i = 0; i < parents[1].transform.childCount; i++)
        {
            posX += 100;
        }

        tempObj.transform.localPosition = new Vector2(posX, 0);        // 위치
        tempObj.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 147.1815f);  // 크기
    }

    public void setTokenStat(int hp, int armor)
    {
        tokenHp += hp;
        tokenArmor += armor;
    }

    private int wolfHp;
    private int wolfArmor;


    public void activePlace(string name)       // 카드 배치가 될때
    {
        if(name != "Geralt")
        {
            setGeraltStat(0, 1);        // 게롤트 방어구 1 상승
        }
    }

    private void Start()        // 기본 능력 초기화
    {
        geraltHp = 3;
        geraltArmor = 0;

        trissHp = 5;
        trissArmor = 0;

        yenneferHp = 2;
        YenneferArmor = 0;

        tokenHp = 5;
        tokenArmor = 0;

        wolfHp = 6;
        wolfArmor = 0;
    }

    private void Update()
    {

    }
}
