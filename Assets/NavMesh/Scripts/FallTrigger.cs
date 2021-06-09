using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    [SerializeField]
    Rigidbody fallBody;

    private void OnTriggerEnter(Collider other)
    {
        // 트리거가 충돌을 감지하면 장애물에 중력을 적용해서 떨어지게 만든다
        fallBody.useGravity = true;
    }
}
