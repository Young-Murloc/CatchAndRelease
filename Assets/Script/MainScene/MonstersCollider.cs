using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);

        GameObject.Find("MonstersGenerator").GetComponent<MonstersGenerator>().MakeMobs(new Vector3(549, 443, 0));
    }
}
