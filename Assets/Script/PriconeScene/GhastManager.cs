using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhastManager : MonoBehaviour
{
    //private CombatManager CM;

    private float ghastHP;

    private Vector2 target;

    private bool isMove;
    private bool isAtk;
    private float dmg;

    private float atkSpeed;
    private float currentTime;

    private GameObject enemyObj;
    //private string allyName;
    //private string enemyName;

    // Start is called before the first frame update
    void Start()
    {
        //CM = GameObject.Find("CombatManager").GetComponent<CombatManager>();

        ghastHP = 100f;

        isMove = false;
        isAtk = false;
        dmg = 3f;

        atkSpeed = 5f;
        currentTime = atkSpeed;

        //allyName = this.gameObject.name;
        //enemyName = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Unit")
        {
            isMove = false;

            isAtk = true;
            enemyObj = collision.gameObject;
            target = new Vector2(enemyObj.transform.position.x + 1, enemyObj.transform.position.y);
            //enemyName = collision.gameObject.name;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isAtk = false;
    }

    public void getDmg(float dmg)
    {
        ghastHP -= dmg;
    }

    // Update is called once per frame
    void Update()
    {
        if(ghastHP != 100f)
        {
            isMove = true;
        }

        if (isMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 1f * Time.deltaTime);

            if(this.transform.position.x == target.x)
            {
                isMove = false;
            }
        }

        if (isAtk)
        {
            currentTime += Time.deltaTime * 1f;

            if (currentTime >= atkSpeed)
            {
                currentTime = 0f;

                if (enemyObj.name == "Bat")
                {
                    enemyObj.GetComponent<BatManager>().getDmg(dmg);

                    Debug.Log("Ghast" + ghastHP);
                }

                //CM.getDmgInfo(this.gameObject, enemyObj, dmg, allyName, enemyName);
            }
        }
        
    }
}
