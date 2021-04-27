using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseTimeManager : MonoBehaviour
{
    private float time = 0f;        // 시간 관리

    private void Start()
    {
        time = 0f;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }
}
