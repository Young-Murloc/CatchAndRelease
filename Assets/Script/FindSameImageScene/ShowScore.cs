using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private UiManager UM;

    public Text Score;
    private float scoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        UM = GameObject.Find("UiManager").GetComponent<UiManager>();

        scoreNumber = 0f;
        Score.text = scoreNumber.ToString();
    }

    public void setScoreNumber(float number)
    {
        scoreNumber += number;
        Score.text = scoreNumber.ToString();

        if(Score.text == "10")
        {
            Time.timeScale = 0;
            UM.setPanelActiveTrue();
        }
    }
}
