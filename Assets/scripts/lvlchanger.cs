using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lvlchanger : MonoBehaviour
{
    Animator anim;
    public int loadLevel;
    public Vector3 position;
    public VectorValue storage;
    public Slider slider;
    public GameObject loadingScreen;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        anim.SetBool("fade", true);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(loadLevel);
        storage.initialValue = position;
        StartCoroutine(LoadingScreenOnFade());
    }

    IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadLevel);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
