using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseCostManager : MonoBehaviour
{
    public Text costText;
    private float costNumber;

    // Start is called before the first frame update
    void Start()
    {
        costNumber = 0f;
        costText.text = costNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(costNumber <= 99f)
        {
            costNumber += Time.deltaTime;
            costText.text = Mathf.Round(costNumber).ToString();
        }
    }
}
