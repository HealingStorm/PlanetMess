using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject RuleMenuUI;
    
    [HideInInspector]
    public GameObject MainMenuUI;
    private GameObject LevelSelectMenuUI;
    private GameObject PauseMenuUI;
    private GameObject controlsMenuUI;
    [HideInInspector]
    public GameObject LevelCompleteMenuUI;
    #region Singlton:Profile

    public static UIManager Instance;
    void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
    #endregion
    private void Start() 
    {
        gameManager = FindObjectOfType<GameManager>();
        RuleMenuUI = GameObject.FindGameObjectWithTag("OptionMenuUI");
        MainMenuUI = GameObject.FindGameObjectWithTag("MainMenuUI");
        LevelSelectMenuUI = GameObject.FindGameObjectWithTag("LevelSelectMenuUI");
        PauseMenuUI = GameObject.FindGameObjectWithTag("PauseMenu");
        LevelCompleteMenuUI = GameObject.FindGameObjectWithTag("LevelComplete");
        controlsMenuUI = GameObject.FindGameObjectWithTag("ControlsMenuUI");

        MainMenuUI.SetActive(true);
        RuleMenuUI.SetActive(false);
        LevelSelectMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        LevelCompleteMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);


    }

    public void Play()
    {
        MainMenuUI.SetActive(false);
        LevelSelectMenuUI.SetActive(true);
    }

    public void OptionsMenu()
    {
        RuleMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
        //OptionsScreen actif
    }

    public void QuitGame()
    {
        Application.Quit();    
    }
    public void BackToMainMenu()
    {
        LevelSelectMenuUI.SetActive(false);
        RuleMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
        controlsMenuUI.SetActive(false);
    }

    public void LoadTuto()
    {
        LevelSelectMenuUI.SetActive(false);
        SceneManager.LoadScene("Jaipeteletuto");
        gameManager.tutoLevelLoaded = true;
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ReturnToMainMenu()
    {
        gameManager.isPaused = false;
        LevelCompleteMenuUI.SetActive(false);
        LevelSelectMenuUI.SetActive(false);
        RuleMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
    }

    public void PlaySoundEffect()
    {
        FindObjectOfType<AudioManager>().Play("UI Select");
    }

    public void ControlsMenuButton()
    {
        controlsMenuUI.SetActive(true);
        RuleMenuUI.SetActive(false);
    }
}
