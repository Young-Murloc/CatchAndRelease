using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);

        GameObject.Find("MobsGenerator").GetComponent<MobsGenerator>().MakeMobs(new Vector3(549, 443, 0));
    }
}
