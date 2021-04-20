using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void setActiveFalseCard(GameObject tempObj)
    {
        tempObj.SetActive(false);
    }

    public void setActiveTrueCard(GameObject tempObj)
    {
        tempObj.SetActive(true);
    }

    public void setPanelActiveTrue()
    {
        panel.SetActive(true);
    }
}
