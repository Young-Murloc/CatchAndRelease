using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLogManager : MonoBehaviour
{
    public Text dmgLog;

    private float temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = 0;
    }

    public void getPosAndDmg(Vector2 tempPos, float dmg)
    {
        temp += dmg;

        dmgLog.text = temp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
