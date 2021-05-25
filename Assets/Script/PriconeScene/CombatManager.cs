using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private GameObject allyObj;
    private GameObject enemyObj;

    private string temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getDmgInfo(GameObject Obj1, GameObject Obj2, float dmg, string name1, string name2) // ally,enemy / ally,enemy
    {
        allyObj = Obj1;
        enemyObj = Obj2;

        temp = name1 + "Manager";
        Debug.Log(temp);
    }
}
