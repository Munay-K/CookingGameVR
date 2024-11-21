using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.ContentSizeFitter;

public enum GameMode { Tutorial, TimeAttack }
public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance;
    public GameMode currentMode;
    public GameObject tutorialObjects;
    public GameObject timeAttackObjects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional, for cross-scene persistence
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (SceneTransitionManager.singleton.GetMode() == SceneTransitionManager.GameMode.Tutorial)
        {
            // Enable tutorial pop-ups
            SetMode(GameMode.Tutorial);
            timeAttackObjects.SetActive(false);
            tutorialObjects.SetActive(true);
        }
        else if (SceneTransitionManager.singleton.GetMode() == SceneTransitionManager.GameMode.TimeAttack)
        {
            // Start the timer and gameplay
            SetMode(GameMode.TimeAttack);
            timeAttackObjects.SetActive(true);
            tutorialObjects.SetActive(false);
        }
    }

    public void SetMode(GameMode mode)
    {
        currentMode = mode;
    }
}

