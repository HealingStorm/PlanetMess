using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject OptionsMenuUI;
    public GameObject MainMenuUI;
    
    private void Start() 
    {
        OptionsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);

    }
    public void StartToPlay()
    {
        //LoadScenePlay
        Debug.Log("I play the game!");
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
        OptionsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
}
