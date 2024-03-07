using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarController : MonoBehaviour
{
    public Slider loadingSlider;
    public float smoothSpeed = 1.0f; // Adjust this value for the sliding speed
    public string sceneToLoad = "ContinueScene";

    private void Start()
    {
        if (PlayerPrefs.GetString("LoggedUserSession") == "true")
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            StartCoroutine(LoadSceneAsync());
        }
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;

        float targetProgress = 0f;

        while (!asyncLoad.isDone)
        {
            targetProgress = asyncLoad.progress;

            while (loadingSlider.value < targetProgress)
            {
                loadingSlider.value += smoothSpeed * Time.deltaTime;
                yield return null;
            }

            if (asyncLoad.progress >= 0.9f)
            {
                while (loadingSlider.value < 1f)
                {
                    loadingSlider.value += smoothSpeed * Time.deltaTime;
                    yield return null;
                }

                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
