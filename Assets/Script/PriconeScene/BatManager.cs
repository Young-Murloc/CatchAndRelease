using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : MonoBehaviour
{
    //private CombatManager CM;

    private float batHP;

    private Vector2 target = new Vector2(10f, 2f);

    private bool isAtk;
    private float dmg;

    private float atkSpeed;
    private float currentTime;

    private GameObject enemyObj;
    private string allyName;
    private string enemyName;

    // Start is called before the first frame update
    void Start()
    {
        //CM = GameObject.Find("CombatManager").GetComponent<CombatManager>();

        batHP = 100f;

        isAtk = false;
        dmg = 5f;

        atkSpeed = 3f;
        currentTime = atkSpeed;

        //allyName = this.gameObject.name;
        //enemyName = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            isAtk = true;
            enemyObj = collision.gameObject;
            //enemyName = collision.gameObject.name;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isAtk = false;
    }

    public void getDmg(float dmg)
    {
        batHP -= dmg;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAtk)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 1f * Time.deltaTime);
        }
        else
        {
            currentTime += Time.deltaTime * 1f;

            if(currentTime >= atkSpeed)
            {
                currentTime = 0f;

                if (enemyObj.name == "Ghast")
                {
                    enemyObj.GetComponent<GhastManager>().getDmg(dmg);

                    Debug.Log("Bat" + batHP);
                }

                //CM.getDmgInfo(this.gameObject, enemyObj, dmg, allyName, enemyName);
            }
        }
    }
}
