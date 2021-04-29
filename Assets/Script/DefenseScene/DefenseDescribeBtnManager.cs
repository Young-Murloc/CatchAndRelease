using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefenseDescribeBtnManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private DefensePlaceManager DPM;

    private float clickTime;
    private float minClickTime;
    private bool isBtnDown;

    // Start is called before the first frame update
    void Start()
    {
        DPM = GameObject.Find("DefensePlaceManager").GetComponent<DefensePlaceManager>();

        clickTime = 0f;
        minClickTime = 1.5f;
        isBtnDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBtnDown)
        {
            clickTime += Time.deltaTime;
        }
        else
        {
            clickTime = 0f;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (clickTime >= minClickTime)       // 꾹 누른 경우
        {
            DPM.setDsecribeBtnPushTrue();
            Debug.Log("꾹누름");
        }
        else
        {
            DPM.setDescribeBtnPushFalse();
        }

        isBtnDown = false;
    }
}
