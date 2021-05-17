using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllySkillScript : MonoBehaviour
{
    public GameObject[] allySkillBar;

    private float[] allySkill = new float[5];
    private float chargePerTile = 5f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<5; i++)
        {
            allySkill[i] = 0f;
        }
    }

    public void chargeSkill(List<int> chargeCount)
    {
        for (int i = 0; i < chargeCount.Count; i++)
        {
            allySkill[i] += (chargeCount[i] * chargePerTile);
        }

        showSkillCharge();
    }

    private void showSkillCharge()
    {
        for(int i=0; i<allySkillBar.Length; i++)
        {
            allySkillBar[i].GetComponent<Image>().fillAmount = (allySkill[i] / 100f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // allySkill 요소가 100f 도달 체크
    }
}
