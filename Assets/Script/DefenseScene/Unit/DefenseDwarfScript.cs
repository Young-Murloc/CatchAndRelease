using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseDwarfScript : MonoBehaviour
{
    private DefenseCostManager DCM;

    private float costUP = 1.3f;

    // Start is called before the first frame update
    void Start()        // 후순위? 배치를 확인하고 실행하는 함수로 변경?
    {
        DCM = GameObject.Find("DefenseCostManager").GetComponent<DefenseCostManager>();

        DCM.setAdditionalCost(costUP);
    }
}
