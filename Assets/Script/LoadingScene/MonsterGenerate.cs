using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerate : MonoBehaviour
{
    public GameObject[] Monsters;
    public GameObject Parent;

    private GameObject tempGameObj;

    int random;

    public void Start()
    {
        random = Random.Range(0, 10);
        tempGameObj = Instantiate(Monsters[random], new Vector3(0f, 0f, 0f), Quaternion.identity);
        tempGameObj.transform.SetParent(Parent.transform);
        tempGameObj.transform.localPosition = new Vector3(0f, 55f, 0f);

        tempGameObj.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
        tempGameObj.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 175);
    }
}
