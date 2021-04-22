using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveManager : MonoBehaviour
{
    private CardManager CM;
    private PlaceManager PM;

    // Start is called before the first frame update
    void Start()
    {
        CM = GameObject.Find("CardManager").GetComponent<CardManager>();
        PM = GameObject.Find("PlaceManager").GetComponent<PlaceManager>();
    }

    public void getAndSendActive(GameObject tempObj)
    {
        name = tempObj.name;

        if(name == "Geralt")
        {
            CM.geraltActive();
        }
        else if(name == "Triss")
        {
            CM.TrissActive();
        }
        else if(name == "Yennefer")
        {
            CM.YenneferActive();
        }
        else if(name == "Token")
        {
            //CM.TokenActive(tempObj);
        }
        else        // wolf
        {
            
        }
    }

    public void getPlace(string name)
    {
        if(name == "Triss")
        {
            PM.spawnToken();
        }
        else if(name == "Yennefer")
        {
            CM.YenneferPlace();
        }
    }
}
