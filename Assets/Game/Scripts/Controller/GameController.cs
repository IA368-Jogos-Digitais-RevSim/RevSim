using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private const string INTRO_SCENE = "Intro";
    private const string GAME_SCENE = "Game";
    private const string HOME_SCENE = "Home";

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
    }

    public static void GoToIntro()
    {
        GoToScene(INTRO_SCENE);
    }

    public static void GoToGame()
    {
        GoToScene(GAME_SCENE);
    }

    public static void GoToHome()
    {
        GoToScene(HOME_SCENE);
    }

    private static void GoToScene(string sceneName)
    {
        SceneLoader.Instance.LoadScene(sceneName);
    }
}
