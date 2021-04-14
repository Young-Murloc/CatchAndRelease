using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void gameListSceneChange()
    {
        Loading.LoadScene("gameListScene");
    }

    public void monsterListSceneChange()
    {
        Loading.LoadScene("monsterListScene");
    }

    public void mainSceneChange()
    {
        Loading.LoadScene("mainScene");
    }

    public void findSameImageSceneChange()
    {
        Loading.LoadScene("findSameImageScene");
    }
}
