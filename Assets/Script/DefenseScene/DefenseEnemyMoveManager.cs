using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseEnemyMoveManager : MonoBehaviour
{
    private DefenseLifeCountManager DLCM;

    private Vector2 start;
    private Vector2 wayPoint1;
    private Vector2 wayPoint2;
    private Vector2 finish;

    private int checkWayPoint = 0;

    private float speed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        DLCM = GameObject.Find("DefenseLifeCountManager").GetComponent<DefenseLifeCountManager>();

        start = new Vector2(52.5f, 655f);
        wayPoint1 = new Vector2(262.5f, 335f);
        wayPoint2 = new Vector2(367.5f, 335f);
        finish = new Vector2(420f, 252.5f);

        checkWayPoint = 0;
    }

    public void setSpeed(float tempSpeed)
    {
        speed = tempSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkWayPoint == 0)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, wayPoint1, speed * Time.deltaTime);

            if(transform.position.x == wayPoint1.x && transform.position.y == wayPoint1.y)
            {
                checkWayPoint++;
            }
        }
        else if(checkWayPoint == 1)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, wayPoint2, speed * Time.deltaTime);

            if (transform.position.x == wayPoint2.x && transform.position.y == wayPoint2.y)
            {
                checkWayPoint++;
            }
        }
        else if(checkWayPoint == 2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, finish, speed * Time.deltaTime);

            if (transform.position.x == finish.x && transform.position.y == finish.y)
            {
                checkWayPoint++;
            }
        }
        else
        {
            DLCM.setLifeCountMinus();
            Destroy(this.gameObject);
        }
    }
}
