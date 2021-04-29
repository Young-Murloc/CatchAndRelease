using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DefensePlaceManager : MonoBehaviour
{
    private DefenseCostManager DCM;
    private DefenseFriendlyDB DFDB;

    private string pickObjName;
    private GameObject pickObj;
    private bool isPickObj;

    private bool isDescribeBtnPush;

    public GameObject Bat;
    public GameObject Dwarf;
    public GameObject Monolith;
    public GameObject Slime;
    public GameObject Zombie;

    public Canvas m_canvas;
    private GraphicRaycaster m_gr;
    private PointerEventData m_ped;
    private GameObject touchedObj;

    private GameObject parent;
    private GameObject canPlace;
    private GameObject createdObj;

    // Start is called before the first frame update
    void Start()
    {
        DCM = GameObject.Find("DefenseCostManager").GetComponent<DefenseCostManager>();
        DFDB = GameObject.Find("DefenseFriendlyDB").GetComponent<DefenseFriendlyDB>();

        isPickObj = false;
        isDescribeBtnPush = false;

        canPlace = GameObject.Find("CanPlace");

        m_gr = m_canvas.GetComponent<GraphicRaycaster>();
        m_ped = new PointerEventData(null);
    }

    public void setPickObjName()        // panel 클릭시 실행
    {
        pickObjName = EventSystem.current.currentSelectedGameObject.name;        // 클릭한 오브젝트 이름 저장
        findPickObj();
        isPickObj = true;
    }

    public void setDsecribeBtnPushTrue()
    {
        isDescribeBtnPush = true;
    }

    public void setDescribeBtnPushFalse()
    {
        isDescribeBtnPush = false;
    }

    public void findPickObj()
    {
        pickObj = GameObject.Find(pickObjName).transform.GetChild(0).gameObject;             // 클릭한 오브젝트 저장

        if(pickObj.name == "Bat")
        {
            pickObj = Bat;
        }
        else if(pickObj.name == "Dwarf")
        {
            pickObj = Dwarf;
        }
        else if(pickObj.name == "Monolith")
        {
            pickObj = Monolith;
        }
        else if(pickObj.name == "Slime")
        {
            pickObj = Slime;
        }
        else
        {
            pickObj = Zombie;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickObj && !isDescribeBtnPush)
        {
            m_ped.position = Input.mousePosition;
            List<RaycastResult> result = new List<RaycastResult>();
            m_gr.Raycast(m_ped, result);

            if (result.Count != 0)
            {
                touchedObj = result[0].gameObject;

                if (Input.GetMouseButtonDown(0))        // 터치로 바꾸기
                {
                    if(canPlace.name == touchedObj.transform.parent.name && DCM.getCost() >= DFDB.getUnitCost(pickObj.name))           // 배치가 가능한 지형인지 확인
                    {
                        parent = GameObject.Find(touchedObj.name);

                        createdObj = Instantiate(pickObj, new Vector2(0, 0), Quaternion.identity);
                        createdObj.transform.SetParent(parent.transform);
                        createdObj.transform.localPosition = new Vector2(0, 0);

                        DCM.setCost(DFDB.getUnitCost(pickObj.name));
                    }
                    else
                    {
                        Debug.Log("코스트 부족");
                    }

                    isPickObj = false;
                }
            }
        }
    }
}
