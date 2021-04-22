using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaceManager : MonoBehaviour
{
    private GwentSoundManager GSM;
    private ActiveManager AM;
    private CardManager CM;

    private GameObject pickObj;     // 선택된 오브젝트
    private bool isContinuePlace;
    private GameObject moveObj;
    private bool isMoveObj;

    public GameObject[] parents = new GameObject[2];
    private int setParent = 0;

    public Image token;
    private Image tokenTemp;

    private GameObject touchedObject;

    public Canvas m_canvas;
    GraphicRaycaster m_gr;
    PointerEventData m_ped;

    private int posX = -200;
    private int movePosX = -200;

    private void Start()
    {
        GSM = GameObject.Find("SoundManager").GetComponent<GwentSoundManager>();
        AM = GameObject.Find("ActiveManager").GetComponent<ActiveManager>();
        CM = GameObject.Find("CardManager").GetComponent<CardManager>();

        m_gr = m_canvas.GetComponent<GraphicRaycaster>();
        m_ped = new PointerEventData(null);
    }

    public void setPickObj(GameObject tempObj)
    {
        pickObj = tempObj;
        isContinuePlace = true;
    }

    public void setMoveObj(GameObject tempObj)
    {
        moveObj = tempObj;
        isMoveObj = true;
    }

    public void setTouchedUI()
    {
        if (isContinuePlace == true && isMoveObj == false)
        {
            if (touchedObject.name == "BlueFront") setParent = 0;
            else setParent = 1;

            GSM.playAudioSource(pickObj);

            // 이동한 패널에 값이 있는지 확인 -> 없다면 밑에 라인, 있다면 위치 조정
            if (parents[setParent].transform.childCount == 0)
            {
                pickObj.transform.SetParent(parents[setParent].transform);
                pickObj.transform.localPosition = new Vector2(posX, 0);        // 위치
                pickObj.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 147.1815f);  // 크기
            }
            else                    // 하위 다른 자식 존재시
            {
                posX += 100;
                pickObj.transform.SetParent(parents[setParent].transform);
                pickObj.transform.localPosition = new Vector2(posX, 0);        // 위치
                pickObj.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 147.1815f);  // 크기
            }

            AM.getPlace(pickObj.name);
            CM.activePlace(pickObj.name, pickObj);

            isContinuePlace = false;

            if(pickObj.name == "Geralt")
            {
                CM.geraltPlace(parents[setParent]);
            }
        }
        else
        {
            if (moveObj.name == "Token" && CM.getTokenActive())      // 토큰 이동만 고려
            {
                Debug.Log("1111");

                if (moveObj.transform.parent.name == "BlueFront")
                {
                    moveObj.transform.SetParent(parents[1].transform);
                }
                else
                {
                    moveObj.transform.SetParent(parents[0].transform);
                }

                movePosX = -300;

                for (int i = 0; i < parents[1].transform.childCount; i++)
                {
                    movePosX += 100;
                }

                moveObj.transform.localPosition = new Vector2(movePosX, 0);        // 위치
                moveObj.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 147.1815f);  // 크기

                setPos(parents[0].gameObject, parents[1].gameObject);       //
                CM.activePlace(pickObj.name, pickObj);
            }

            isMoveObj = false;
        }
    }

    public void spawnToken()
    {
        for(int i=0; i<2; i++)
        {
            posX += 100;
            tokenTemp = Instantiate(token, new Vector3(0f, 0f, 0f), Quaternion.identity);
            tokenTemp.transform.SetParent(parents[setParent].transform);
            tokenTemp.transform.localPosition = new Vector2(posX, 0);
            tokenTemp.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 147.1815f);
            tokenTemp.name = "Token";
            CM.activePlace(pickObj.name, pickObj);
        }
    }

    public void setPos(GameObject tempObj1, GameObject tempObj2)
    {
        posX = -200;

        for (int i=0; i<tempObj1.transform.childCount; i++)
        {
            if (tempObj1.transform.GetChild(i).transform.localPosition.x != posX){
                tempObj1.transform.GetChild(i).transform.localPosition = new Vector3(posX, 0, 0);
            }

            posX += 100;
        }

        posX = -200;

        for (int i = 0; i < tempObj2.transform.childCount; i++)
        {
            if (tempObj2.transform.GetChild(i).transform.localPosition.x != posX)
            {
                tempObj2.transform.GetChild(i).transform.localPosition = new Vector3(posX, 0, 0);
            }

            posX += 100;
        }
    }

    private void Update()
    {
        if (isContinuePlace)
        {
            m_ped.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_gr.Raycast(m_ped, results);
            if (results.Count != 0)
            {
                touchedObject = results[0].gameObject;
            }
        }

        setPos(parents[0], parents[1]);
    }
}
