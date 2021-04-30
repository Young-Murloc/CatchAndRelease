using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseMonolithScript : MonoBehaviour
{
    private float monolithAtk;
    private float monolithAtkSpeed;

    private Dictionary<string, GameObject> dic = new Dictionary<string, GameObject>();        // key : 이름 / value : 게임 오브젝트

    private float time;

    private bool isCheck;

    // Start is called before the first frame update
    void Start()
    {
        monolithAtk = 200f;
        monolithAtkSpeed = 4f;
        isCheck = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dic.Add(collision.gameObject.name, collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isCheck)
        {
            dic.Remove(collision.gameObject.name);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time >= monolithAtkSpeed)
        {
            isCheck = true;
            foreach (var tempObj in dic)
            {
                if(tempObj.Value != null)
                {
                    tempObj.Value.GetComponent<DefenseEnemyStatusManager>().getDamage(monolithAtk);
                }
            }
            isCheck = false;
            time = 0f;
        }
    }
}
