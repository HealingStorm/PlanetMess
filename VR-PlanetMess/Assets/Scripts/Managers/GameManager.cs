using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPlaying = true;

    public float timer = 120;

    private bool levelCompleted;

    //[HideInInspector]
    public bool tutoLevelLoaded;

    private bool inLevel;
    private GameObject[] levelSystems;
    private bool[] orbitsDone = new bool[3];

    #region Singlton:Profile
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion


    private void Update()
    {
        //On fetch les systèmes à check après
        if(tutoLevelLoaded)
        {
            levelSystems = GameObject.FindGameObjectsWithTag("System");
            inLevel = true;
            tutoLevelLoaded = false;
        }

        if(inLevel)
        {
            //check si le joueur a validé tout les orbites de chaque système
            CheckAllSystemsOrbits();
        }

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
                    inLevel = false;
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

}
