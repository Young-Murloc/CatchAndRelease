using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnCtrl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PanelManager PM;
    private PlaceManager PLM;
    private GwentSoundManager GSM;
    private ActiveManager AM;

    private bool isBtnDown = false;
    private float clickTime = 0f;
    private float minClickTime = 1f;

    private bool isPlace = false;

    private void Start()
    {
        PM = GameObject.Find("PanelManager").GetComponent<PanelManager>();
        PLM = GameObject.Find("PlaceManager").GetComponent<PlaceManager>();
        GSM = GameObject.Find("SoundManager").GetComponent<GwentSoundManager>();
        AM = GameObject.Find("ActiveManager").GetComponent<ActiveManager>();
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
            PM.createImagePopup(this.name);
        }
        else
        {
            if (!isPlace)
            {
                PLM.setPickObj(this.gameObject);
                isPlace = true;
            }
            else   // 명령 발동
            {
                Debug.Log("active");
                PLM.setMoveObj(this.gameObject);
                //AM.getAndSendActive(this.gameObject);
            }
        }
    }
}
