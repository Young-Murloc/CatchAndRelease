using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseFriendlyDB : MonoBehaviour
{
    // attack
    private GameObject bat;         // 단일, 공속 빠름
    private float batCost;
    private float batAtk;
    private float batAtkSpeed;

    private GameObject monolith;    // 광역, 공속 느림
    private float monolithCost;
    private float monolithAtk;
    private float monolithAtkSpeed;

    private GameObject zombie;      // 단일, 공속 중간
    private float zombieCost;
    private float zombieAtk;
    private float zombieAtkSpeed;

    // support
    private GameObject dwarf;       // 코스트 증가
    private float dwarfCost;
    private float dwarfRegenUp;

    private GameObject slime;       // 광역 이동속도 감소
    private float slimeCost;
    private float slimeSlow;

    // Start is called before the first frame update
    void Start()
    {
        batCost = 10;
        monolithCost = 25;
        zombieCost = 15;

        dwarfCost = 15;
        slimeCost = 10;
    }

    public float getUnitCost(string name)       // 유닛 코스트 전달
    {
        if(name == "Bat")
        {
            return batCost;
        }
        else if(name == "Monolith")
        {
            return monolithCost;
        }
        else if(name == "Zombie")
        {
            return zombieCost;
        }
        else if(name == "Dwarf")
        {
            return dwarfCost;
        }
        else
        {
            return slimeCost;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
