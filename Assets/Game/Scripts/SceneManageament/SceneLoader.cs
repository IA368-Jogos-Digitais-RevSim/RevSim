using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _loadingOverlay;
    [SerializeField]
    [Range(0.01f, 3f)]
    private float _fadeTime = 0.5f;
    public static SceneLoader Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
        _loadingOverlay.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(PerformLoadSceneAsync(sceneName));
    }

    private IEnumerator PerformLoadSceneAsync(string sceneName)
    {
        _loadingOverlay.gameObject.SetActive(true);
        yield return StartCoroutine(FadeIn());

        var operation = SceneManager.LoadSceneAsync(sceneName);
        while(operation.isDone == false)
        {
            yield return null;
        }

        yield return StartCoroutine(FadeOut());
        _loadingOverlay.gameObject.SetActive(false);
    }

    private IEnumerator FadeIn()
    {
        float start = 0;
        float end = 1;
        float speed = (end - start) / _fadeTime;
        
        _loadingOverlay.alpha = start;
        while(_loadingOverlay.alpha < end)
        {
            _loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }
        _loadingOverlay.alpha = end;
    }

    private IEnumerator FadeOut()
    {
        float start = 1;
        float end = 0;
        float speed = (end - start) / _fadeTime;
        
        _loadingOverlay.alpha = start;
        while(_loadingOverlay.alpha > end)
        {
            _loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }
        _loadingOverlay.alpha = end;
    }
}
