using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    public bool isPlaying = true;

    public float timer = 120;

    private bool levelCompleted;

    [HideInInspector]
    public bool isPaused;

    private GameObject PauseMenuUI;
    private XRIDefaultInputActions playerInputs;

    //[HideInInspector]
    public bool tutoLevelLoaded;

    private bool inLevel;
    private GameObject[] levelSystems;
    private bool[] orbitsDone = new bool[3];

    //[HideInInspector]
    public bool dropSecurity;
    //[HideInInspector]
    public bool takeSecurity;

    [HideInInspector]
    public UIManager UIManager;

    #region Singlton:Profile
    void Awake()
    {
    }
    #endregion

    private void Start() 
    {
        playerInputs = new XRIDefaultInputActions();
        isPaused = false;
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void Update()
    {
        //On fetch les syst�mes � check apr�s
        if(tutoLevelLoaded)
        {
            levelSystems = GameObject.FindGameObjectsWithTag("System");
            inLevel = true;
        }

        if(inLevel)
        {
            //check si le joueur a validé tout les orbites de chaque système
            CheckAllSystemsOrbits();

        }
        playerInputs.XRILeftHand.PauseGame.started += OnPause;
    }
    public void CheckAllSystemsOrbits()
    {
        for (int i = 0; i < levelSystems.Length; i++)
        {
            //On check si tt les systèmes ont tt leurs orbites valides et ont fini la partie
            for (int j = 0; j < orbitsDone.Length; j++)
            {
                if(orbitsDone[j] == false)
                {
                    levelCompleted = false;
                    break;
                }
                else if (orbitsDone[j] == true)
                {
                    levelCompleted = true;
                    tutoLevelLoaded = false;
                    inLevel = false;
                    //SceneManager.LoadScene("MainMenu");
                    //UIManager.LevelCompleteMenuUI.SetActive(true);
                    Debug.Log("LEVEL COMPLETE !");
                    break;
                }
            }
            //On check si les 3 orbites de chaque système est valide
            for (int k = 0; k < levelSystems[i].GetComponent<SystemPropreties>().orbitDone.Length; k++)
            {
                if (levelSystems[i].GetComponent<SystemPropreties>().orbitDone[k] == false)
                {
                    orbitsDone[k] = false;
                }
                else if (levelSystems[i].GetComponent<SystemPropreties>().orbitDone[k] == true)
                {
                    orbitsDone[k] = true;
                }
            }
        }
    }

    public void OnPlanetDrop()
    {
        dropSecurity = true;
    }

    public void OnPlanetTake()
    {
        takeSecurity = true;
    }

    public void OnPause(InputAction.CallbackContext context) 
    {   
        if(isPaused == true)
        {
            Time.timeScale = 1;
            PauseMenuUI.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            PauseMenuUI.SetActive(true);
            isPaused = true;
        }
    }
    
}
