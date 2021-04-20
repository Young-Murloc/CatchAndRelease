using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour
{
    private UiManager UM;

    public Text Timer;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        UM = GameObject.Find("UiManager").GetComponent<UiManager>();

        Time.timeScale = 1;

        time = 60f;
        Timer.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0f)
        {
            time -= Time.deltaTime;
            Timer.text = Mathf.Ceil(time).ToString();
        }
        else
        {
            Time.timeScale = 0;     // 시간 정지
            UM.setPanelActiveTrue();
        }
    }
}
