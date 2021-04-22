using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    private PlaceManager PM;

    public GameObject[] parents = new GameObject[2];

    private int posX = -300;

    private int tempArmor = 0;

    public Text geraltArmorText;

    //게롤트
    public GameObject geraltParent;
    private int geraltHp;
    private int geraltArmor;
    private int canGeraltActive = 1;

    public void geraltPlace(GameObject tempObj)
    {
        geraltParent = tempObj;
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

    public void YenneferPlace()     // active 능력 횟수 증가
    {
        canGeraltActive += 1;
        canTokenActive += 2;
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
    private int canTokenActive = 2;

    /*
    public void TokenActive(GameObject tempObj)
    {
        if(canTokenActive >= 1)
        {
            if (tempObj.transform.parent.name == "BlueFront")
            {
                posX = -200;
                
                for(int i=0; i<parents[1].transform.childCount; i++)
                {
                    posX += 100;
                }

                tempObj.transform.SetParent(parents[1].transform);

            }
            else
            {
                posX = -200;

                for(int i=0; i<parents[0].transform.childCount; i++)
                {
                    posX += 100;
                }

                Debug.Log(posX);

                tempObj.transform.SetParent(parents[0].transform);

            }

            tempObj.transform.localPosition = new Vector2(posX, 0);        // 위치
            tempObj.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 147.1815f);  // 크기

            activePlace("Token");

            PM.setPos(parents[0].gameObject, parents[1].gameObject);

            canTokenActive--;
        }
    }
    */
    public void setTokenStat(int hp, int armor)
    {
        tokenHp += hp;
        tokenArmor += armor;
    }

    public bool getTokenActive()
    {
        if(canTokenActive >= 1)
        {
            canTokenActive--;
            return true;
        }
        else
        {
            return false;
        }
    }

    private int wolfHp;
    private int wolfArmor;


    public void activePlace(string name,GameObject tempObj)       // 카드 배치가 될때
    {
        //Debug.Log(geraltParent);
        //Debug.Log(tempObj.transform.parent.name);

        if(name != "Geralt" && tempObj.transform.parent.name == geraltParent.name)
        {
            setGeraltStat(0, 1);        // 게롤트 방어구 1 상승
        }
        else
        {

        }
    }

    private void Start()        // 기본 능력 초기화
    {
        PM = GameObject.Find("PlaceManager").GetComponent<PlaceManager>();

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
        if(tempArmor != geraltArmor)
        {
            geraltArmorText.text = geraltArmor.ToString();
            tempArmor = geraltArmor;
        }
    }
}
