using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseLifeCountManager : MonoBehaviour
{
    public Text lifeCountText;
    private int lifeCountNumber;

    // Start is called before the first frame update
    void Start()
    {
        lifeCountNumber = 5;
        lifeCountText.text = lifeCountNumber.ToString();
    }

    public void setLifeCountMinus()
    {
        lifeCountNumber--;
        lifeCountText.text = lifeCountNumber.ToString();
    }
}
