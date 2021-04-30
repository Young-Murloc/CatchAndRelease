using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseEnemyStatusManager : MonoBehaviour
{
    private DefenseFieldManager DFM;

    private float hp;

    // Start is called before the first frame update
    void Start()
    {
        DFM = GameObject.Find("DefenseFieldManager").GetComponent<DefenseFieldManager>();

        if(this.name == "Brain(Clone)")
        {
            hp = 100f;
        }
        else if(this.name == "Eyeball(Clone)")
        {
            hp = 150f;
        }
        else
        {
            hp = 200f;
        }
    }

    public void getDamage(float dmg)
    {
        hp -= dmg;
        isHpZero();
    }

    public void isHpZero()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
