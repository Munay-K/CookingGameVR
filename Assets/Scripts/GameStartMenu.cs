using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject newGameMenu;
    public GameObject scoreboard;
    public GameObject settings;
    public GameObject credits;

    [Header("Main Menu Buttons")]
    public Button newGameButton;
    public Button startButton;
    public Button settingsButton;
    public Button scoreboardButton;
    public Button creditsButton;
    public Button quitButton;

    [Header("Game Menu Settings")]
    public TMPro.TMP_Dropdown gameModeDropdown;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        newGameButton.onClick.AddListener(EnableNewGame);
        scoreboardButton.onClick.AddListener(EnableScoreboard);
        settingsButton.onClick.AddListener(EnableSettings);
        creditsButton.onClick.AddListener(EnableCredits);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        HideAll();
        if (gameModeDropdown.options[gameModeDropdown.value].text == "Tutorial")
        {
            SceneTransitionManager.singleton.SetMode(SceneTransitionManager.GameMode.Tutorial);
        }
        else
        {
            SceneTransitionManager.singleton.SetMode(SceneTransitionManager.GameMode.TimeAttack);
        }

        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        newGameMenu.SetActive(false);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
    public void EnableNewGame()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(true);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
    public void EnableSettings()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settings.SetActive(true);
        scoreboard.SetActive(false);
        credits.SetActive(false);
    }
    public void EnableScoreboard()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settings.SetActive(false);
        scoreboard.SetActive(true);
        credits.SetActive(false);
    }
    public void EnableCredits()
    {
        mainMenu.SetActive(false);
        newGameMenu.SetActive(false);
        settings.SetActive(false);
        scoreboard.SetActive(false);
        credits.SetActive(true);
    }
}
