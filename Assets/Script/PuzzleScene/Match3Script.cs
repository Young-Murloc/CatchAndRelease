using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match3Script : MonoBehaviour
{
    private EnemyStatScript ESS;

    private Sprite sprite;
    private Vector2 mainPos;

    private List<GameObject> killList = new List<GameObject>();         // 터질 타일 리스트

    private int verticalCount;      // 세로 매칭 타일 수
    private List<GameObject> verticalMatchObj = new List<GameObject>();  // 세로 매칭 오브젝트

    private int horizonCount;       // 가로 매칭 타일 수
    private List<GameObject> horizonMatchObj = new List<GameObject>();   // 가로 매칭 오브젝트

    private List<int> tileDmgCount = new List<int>() { 0, 0, 0, 0, 0 };

    private GameObject tempObj;     // 매칭 비교용 임시 오브젝트 변수

    private RaycastHit2D[] hits;    // 레이캐스트 맞는 오브젝트 전부 저장
    private Vector2[] directions1 = new Vector2[] { Vector2.up, Vector2.down };     // 위, 아래 - L자로 터지는것을 방지하기 위해
    private Vector2[] directions2 = new Vector2[] { Vector2.left, Vector2.right };  // 오른, 왼

    private Vector2[] directionsAll = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    // Start is called before the first frame update
    void Start()
    {
        ESS = GameObject.Find("EnemyManager").GetComponent<EnemyStatScript>();

        verticalCount = 1;
        horizonCount = 1;
    }

    public bool IsMatch(GameObject mainObj)       // 매치 확인 알고리즘
    {
        sprite = mainObj.GetComponent<SpriteRenderer>().sprite;     // 같은 그림인지 확인하기 위한 스프라이트
        mainPos = mainObj.transform.position;                       // 위치를 파악하여 위2,아래2,오른2,왼2 확인

        for(int i=0; i<directions1.Length; i++)      // 위,아래,세로
        {
            hits = Physics2D.RaycastAll(mainPos, directions1[i], 7f);       // 7f 길이

            for(int j=1; j<hits.Length; j++)
            {
                if (sprite == hits[j].collider.gameObject.GetComponent<SpriteRenderer>().sprite)
                {
                    verticalCount++;
                    verticalMatchObj.Add(hits[j].collider.gameObject);
                }
                else
                    break;
            }
        }

        for (int i = 0; i < directions2.Length; i++)      // 오른쪽,왼쪽,가로
        {
            hits = Physics2D.RaycastAll(mainPos, directions2[i], 5f);       // 7f 길이

            for (int j = 1; j < hits.Length; j++)
            {
                if (sprite == hits[j].collider.gameObject.GetComponent<SpriteRenderer>().sprite)
                {
                    horizonCount++;
                    horizonMatchObj.Add(hits[j].collider.gameObject);
                }
                else
                    break;
            }
        }

        // verticalCount = 세로 / horizonCount = 가로 / 카운트 기반으로 killList 삽입 + 4개 폭탄, 5개 폭탄 추가
        
        foreach(GameObject temp in verticalMatchObj)
        {
            killList.Add(temp);
        }
        
        foreach(GameObject temp in horizonMatchObj)
        {
            killList.Add(temp);
        }

        if (verticalCount == 3 || horizonCount == 3)
        {
            killList.Add(mainObj);

            killTile(killList);

            resetVar();

            return true;
        }
        else if(verticalCount > 3 || horizonCount > 3)
        {
            BoardManagerScript.instance.changeBoom(mainObj);

            killTile(killList);

            resetVar();

            return true;
        }

        resetVar();

        return false;
    }

    public void boomActive(GameObject mainObj)          // 폭탄 작동
    {
        for(int i=0; i<directionsAll.Length; i++)
        {
            hits = Physics2D.RaycastAll(mainObj.transform.position, directionsAll[i], 7f);       // 7f 길이

            for(int j=0; j<hits.Length; j++)
            {
                killList.Add(hits[j].collider.gameObject);
            }
        }

        killTile(killList);

        resetVar();
    }

    private void killTile(List<GameObject> killList)
    {
        foreach(GameObject temp in killList)
        {
            temp.GetComponent<SpriteRenderer>().sprite = null;

            tileDmgCount[(int)temp.transform.position.x]++;
        }

        ESS.getDmg(tileDmgCount);

        StopCoroutine(BoardManagerScript.instance.FindNullTiles());
        StartCoroutine(BoardManagerScript.instance.FindNullTiles());
    }

    private void resetVar()
    {
        verticalCount = 1;
        horizonCount = 1;
        verticalMatchObj = new List<GameObject>();
        horizonMatchObj = new List<GameObject>();
        killList = new List<GameObject>();
        tileDmgCount = new List<int>() { 0, 0, 0, 0, 0 };
    }
}
