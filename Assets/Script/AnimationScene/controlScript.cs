using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class controlScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    float horizontal;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Walk", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Attack", true);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", false);
        }
    }
}
