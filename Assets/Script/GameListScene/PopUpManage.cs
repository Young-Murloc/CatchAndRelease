using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManage : MonoBehaviour
{
    public GameObject[] popUpList;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<popUpList.Length; i++)
        {
            popUpList[i].SetActive(false);
        }
    }

    public void setTrueFSMPanel()          // Find Same Image Panel -> True
    {
        popUpList[0].SetActive(true);
    }

    public void setFalseFSMPanel()         // Find Same Image Panel -> False
    {
        popUpList[0].SetActive(false);
    }

    public void setTrueGwentPanel()
    {
        popUpList[1].SetActive(true);
    }

    public void setFalseGwentPanel()
    {
        popUpList[1].SetActive(false);
    }
}
