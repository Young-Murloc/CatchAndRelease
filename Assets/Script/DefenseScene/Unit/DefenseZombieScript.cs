using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseZombieScript : MonoBehaviour
{
    private float zombieAtk;
    private float zombieAtkSpeed;

    private bool isAtk;

    private GameObject targetObj;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        zombieAtk = 50f;
        zombieAtkSpeed = 1f;
        isAtk = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isAtk && collision.tag == "Enemy")
        {
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

        if (time >= zombieAtkSpeed)
        {
            if (targetObj != null)
            {
                targetObj.GetComponent<DefenseEnemyStatusManager>().getDamage(zombieAtk);
            }

            time = 0f;
        }
    }
}
