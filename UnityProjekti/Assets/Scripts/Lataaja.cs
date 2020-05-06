using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lataaja : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;

    public void LataaRuutu(int sceneIndex)
    {
        StartCoroutine(Lataus(sceneIndex));

    }

    IEnumerator Lataus (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            //odottaa seuraavaa kuvaa
            yield return null;
        }
    }

}
