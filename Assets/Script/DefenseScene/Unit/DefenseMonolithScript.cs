using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseMonolithScript : MonoBehaviour
{
    private float monolithAtk;
    private float monolithAtkSpeed;

    private bool canAtk;

    private GameObject[] targetObj;
    private int count;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        monolithAtk = 200f;
        monolithAtkSpeed = 5f;
        count = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(canAtk)        // 한명만 공격함
        {
            collision.GetComponent<DefenseEnemyStatusManager>().getDamage(monolithAtk);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time >= monolithAtkSpeed)
        {
            canAtk = true;
        }
    }
}
