using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class SceneChanger : Singleton<SceneChanger>
{
    public Action OnLoadSceneEnd;

    [Header("LOADING SCREEN")]
    [Tooltip("If this is true, the loaded scene won't load until receiving user input")]
    public bool waitForInput = false;
    public GameObject LoadingSceneCanvas;

    [Tooltip("The loading bar Slider UI element in the Loading Screen")]
    public Slider loadingBar;
    public TMP_Text loadPromptText;
    public KeyCode userPromptKey;

    public void LoadScene(string scene)
    {
        if (scene != "")
        {
            StartCoroutine(LoadAsynchronously(scene));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadScene("MainScene");
        }
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        //mainCanvas.SetActive(false);
        //To Do : clear all opened canvas

        LoadingSceneCanvas.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .95f);
            loadingBar.value = progress;

            operation.allowSceneActivation = true;

            yield return null;
        }

        OnLoadSceneEnd?.Invoke();
    }
}
