using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseEnemyStatusManager : MonoBehaviour
{
    private DefenseEnemyMoveManager DEMM;               // 자신이 가진 컴포넌트에 접근하는 방법?

    private float hp;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        if(this.name == "Brain(Clone)")
        {
            Debug.Log("Brain");
            hp = 100f;
            speed = 100f;
            Debug.Log(hp);
        }
        else if(this.name == "Eyeball(Clone)")
        {
            Debug.Log("Eyeball");
            hp = 150f;
            speed = 50f;
            Debug.Log(hp);
        }
        else
        {
            Debug.Log("Mushroom");
            hp = 200f;
            speed = 25f;
            Debug.Log(hp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
