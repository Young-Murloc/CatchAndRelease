using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatScript : MonoBehaviour
{
    public GameObject[] hpBar;

    private float[] hp = new float[5];
    private float dmgPerTile = 5;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<5; i++)
        {
            hp[i] = 100f;
        }
    }

    public void getDmg(List<int> dmgCount)
    {
        for(int i=0; i<dmgCount.Count; i++)
        {
            hp[i] -= (dmgCount[i] * dmgPerTile);
        }

        showHp();
    }

    private void showHp()
    {
        for(int i=0; i<hpBar.Length; i++)
        {
            hpBar[i].GetComponent<Image>().fillAmount = hp[i] / 100f;
        }
    }
}
