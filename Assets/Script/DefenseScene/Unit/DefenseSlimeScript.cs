using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseSlimeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<DefenseEnemyMoveManager>().setSpeed(50f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<DefenseEnemyMoveManager>().setSpeed(100f);
        }
    }
}
