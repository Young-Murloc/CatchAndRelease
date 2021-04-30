using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseCostManager : MonoBehaviour
{
    public Text costText;
    private float costNumber;
    private float additionalCost;

    // Start is called before the first frame update
    void Start()
    {
        costNumber = 20f;
        costText.text = costNumber.ToString();

        additionalCost = 1f;
    }

    public float getCost()
    {
        return Mathf.Round(costNumber);
    }

    public void setCost(float cost)
    {
        costNumber -= cost;
    }

    public void setAdditionalCost(float tempCost)
    {
        additionalCost += tempCost;
    }

    // Update is called once per frame
    void Update()
    {
        if(costNumber <= 99f)
        {
            costNumber += Time.deltaTime * additionalCost;
            costText.text = Mathf.Round(costNumber).ToString();
        }
    }
}
