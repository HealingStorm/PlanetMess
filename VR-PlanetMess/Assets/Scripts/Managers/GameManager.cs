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
    public bool[] orbitsDone = new bool[4];


    [HideInInspector]
    public UIManager UIManager;

    public bool isDead = false;

    public static GameManager Instance;


    #region Singlton:Profile

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
        playerInputs = new XRIDefaultInputActions();
        isPaused = false;
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void Update()
    {
        //On fetch les syst�mes � check apr�s
        if (tutoLevelLoaded)
        {
            tutoLevelLoaded = false;
            StartCoroutine(WaitBeforeCheck());
        }

        if (inLevel)
        {
            levelSystems = GameObject.FindGameObjectsWithTag("System");
            for (int i = 0; i < levelSystems.Length; i++)
            {
                //On check si les 3 orbites de chaque système est valide
                for (int k = 0; k < levelSystems[i].GetComponent<SystemPropreties>().orbitDone.Length; k++)
                {
                    if (levelSystems[i].GetComponent<SystemPropreties>().orbitDone[k] == false)
                    {
                        orbitsDone[i] = false;
                        //Debug.Log("orbitsDone false");
                        break;
                    }
                    else
                    {
                        orbitsDone[i] = true;
                        //Debug.Log("orbitsDone true");
                    }
                }
            }
            //On check si tt les systèmes ont tt leurs orbites valides et ont fini la partie
            for (int j = 0; j < orbitsDone.Length; j++)
            {
                if (orbitsDone[j] == false)
                {
                    levelCompleted = false;
                    break;
                }
                else
                {
                    inLevel = false;
                    levelCompleted = true;
                }
            }
            /*//check si le joueur a validé tout les orbites de chaque système
            CheckAllSystemsOrbits();*/

        }
        playerInputs.XRILeftHand.PauseGame.started += OnPause;

        if (levelCompleted)
        {
            inLevel = false;
            tutoLevelLoaded = false;
            levelCompleted = false;
            Debug.Log("LEVEL COMPLETE !");
            tutoLevelLoaded = false;
            SceneManager.LoadScene("MainMenu");
            UIManager.Instance.LevelCompleteMenuUI.SetActive(true);
        }

    }

    IEnumerator WaitBeforeCheck()
    {
        yield return new WaitForSeconds(1f);
        inLevel = true;
    }
    /*public void CheckAllSystemsOrbits()
    {
        for (int i = 0; i < levelSystems.Length; i++)
        {
            //On check si les 3 orbites de chaque système est valide
            for (int k = 0; k < levelSystems[i].GetComponent<SystemPropreties>().orbitDone.Length; k++)
            {
                if (levelSystems[i].GetComponent<SystemPropreties>().orbitDone[k] == false)
                {
                    orbitsDone[k] = false;
                    break;
                }
                else
                {
                    orbitsDone[k] = true;
                }
            }
        }
        //On check si tt les systèmes ont tt leurs orbites valides et ont fini la partie
        for (int j = 0; j < orbitsDone.Length; j++)
        {
            if (orbitsDone[j] == false)
            {
                levelCompleted = false;
                break;
            }
            else
            {
                levelCompleted = true;
            }
        }
    }*/



    public void OnPause(InputAction.CallbackContext context)
    {
        if (isPaused == true)
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
