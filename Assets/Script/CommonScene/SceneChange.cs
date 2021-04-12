using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void monsterListSceneChange()
    {
        SceneManager.LoadScene("monsterListScene");
    }

    public void mainSceneChange()
    {
        SceneManager.LoadScene("mainScene");
    }
}
