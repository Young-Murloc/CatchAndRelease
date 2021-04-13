using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    private static string nextScene;

    [SerializeField]
    Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("loadingScene");
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;        // 로딩을 잠시 멈추기 위해 설정

        float timer = 0.0f;

        while (!op.isDone)
        {
            yield return null;          // 유니티에게 제어권 전달

            timer += Time.unscaledDeltaTime;
            progressBar.fillAmount = Mathf.Lerp(0.0f, 1f, timer);

            if (progressBar.fillAmount >= 1f)
            {
                op.allowSceneActivation = true;
                yield break;
            }

            /*
            if(op.progress < 0.1f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);

                if(progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
            */
        }
    }
}
