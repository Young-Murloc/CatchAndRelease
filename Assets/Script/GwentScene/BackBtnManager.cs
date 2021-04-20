using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackBtnManager : MonoBehaviour
{
    private PanelManager PM;

    private GameObject tempObj;
    Button thisBtn;

    private void Start()
    {
        PM = GameObject.Find("PanelManager").GetComponent<PanelManager>();

        thisBtn = this.transform.GetComponent<Button>();
        if(thisBtn != null)
        {
            thisBtn.onClick.AddListener(destroyObj);
        }
    }

    public void setTempObj(GameObject obj)
    {
        tempObj = obj;
    }

    public void destroyObj()
    {
        PM.destroyPanelObj();
    }
}
