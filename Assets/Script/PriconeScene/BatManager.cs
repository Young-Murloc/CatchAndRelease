using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : MonoBehaviour
{
    private CombatManager CM;

    private float batHP;

    private Vector2 target = new Vector2(10f, 2f);

    private bool isAtk;
    private float time;

    private GameObject enemyObj;

    // Start is called before the first frame update
    void Start()
    {
        CM = GameObject.Find("CombatManager").GetComponent<CombatManager>();

        batHP = 100f;

        isAtk = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            isAtk = true;
            enemyObj = collision.gameObject;
        }
    }

    private void getDmg(float dmg)
    {
        batHP -= dmg;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAtk)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 0.02f);
        }
        else
        {

        }
    }
}
