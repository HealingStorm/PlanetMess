using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject OptionsMenuUI;
    public GameObject MainMenuUI;
    public GameObject LevelSelectMenuUI;
    public GameObject PauseMenuUI;
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


        MainMenuUI.SetActive(true);
        OptionsMenuUI.SetActive(false);
        LevelSelectMenuUI.SetActive(false);

    }

    public void Play()
    {
        Debug.Log("I play the game!");
        MainMenuUI.SetActive(false);
        LevelSelectMenuUI.SetActive(true);
    }

    public void OptionsMenu()
    {
        Debug.Log("AAAAAAAAAH TURN THE VOLUME DOOOOOWN");
        OptionsMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
        //OptionsScreen actif
    }

    public void QuitGame()
    {
        Debug.Log("So long hey Bowser");
        Application.Quit();    
    }
    public void BackToMainMenu()
    {
        Debug.Log("Welcome back, ears better?");
        LevelSelectMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void LoadTuto()
    {
        Debug.Log("Tu joues mais en fait c'est le tuto");
        SceneManager.LoadScene("TutorialLevel");
        gameManager.tutoLevelLoaded = true;
    }

    public void LoadLevelOne()
    {
        Debug.Log("Tu fais le tuto mais en fait c'est le jeu");
        SceneManager.LoadScene("Level 1");
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Bah alors on ragequit?");
        gameManager.isPaused = false;
        LevelCompleteMenuUI.SetActive(false);
        LevelSelectMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {
        Debug.Log("Bon la pause est finie on reprend");
        PauseMenuUI.SetActive(false);
    }

    public void PlaySoundEffect()
    {
        FindObjectOfType<AudioManager>().Play("UI Select");
    }
}
