using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] Image progressBar;
    [SerializeField] GameObject loadingGif;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync("Game");
        while (gameLevel.progress < 1)
        {
            progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }

    private void Update()
    {
        loadingGif.GetComponent<RectTransform>().Rotate(0f, 0f, -190f * Time.deltaTime);
    }
}
