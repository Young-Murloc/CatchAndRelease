using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBatScript : MonoBehaviour
{
    private float batAtk;
    private float batAtkSpeed;

    private bool isAtk;

    private GameObject targetObj;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        batAtk = 100f;
        batAtkSpeed = 2f;
        isAtk = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isAtk && collision.tag == "Enemy")
        {
            time = batAtkSpeed;
            isAtk = true;
            targetObj = collision.gameObject;
            Debug.Log(targetObj.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isAtk = false;
        targetObj = null;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= batAtkSpeed)
        {
            if(targetObj != null)
            {
                targetObj.GetComponent<DefenseEnemyStatusManager>().getDamage(batAtk);
            }

            time = 0f;
        }
    }
}
