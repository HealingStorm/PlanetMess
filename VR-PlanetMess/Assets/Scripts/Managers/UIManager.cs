using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject OptionsMenuUI;
    public GameObject MainMenuUI;
    public GameObject LevelSelectMenuUI;
    
    private void Start() 
    {
        // MainMenuUI.SetActive(true);
        // OptionsMenuUI.SetActive(false);
        // LevelSelectMenuUI.SetActive(false);

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
}
