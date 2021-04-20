using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PanelManager PM;

    private bool isBtnDown = false;
    private float clickTime = 0f;
    private float minClickTime = 1f;

    private void Start()
    {
        PM = GameObject.Find("PanelManager").GetComponent<PanelManager>();
    }

    private void Update()
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
        isBtnDown = false;

        if(clickTime >= minClickTime)
        {
            Debug.Log("longClick");
            PM.createImagePopup(this.name);
        }
        else
        {
            Debug.Log("shortClick");
        }
    }
}
