using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPlaying = true;

    public float timer = 120;

    public bool levelCompleted;
    public bool tutoLevelLoaded;
    public bool inLevel;
    private GameObject[] levelSystems;
    public Material orbitNeutralMat;
    public Material orbitValidMat;

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
            CheckAllInArray(levelSystems);
        }

    }
    public void CheckAllInArray(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].transform.Find("Orbits/OrbitSmall").GetComponent<MeshRenderer>().material == orbitNeutralMat)
            {
                levelCompleted = false;
                Debug.Log("NOT COMPLETE");
                break;
            }
            else if (array[i].transform.Find("Orbits/OrbitSmall").GetComponent<MeshRenderer>().material == orbitValidMat)
            {
                levelCompleted = true;
                inLevel = false;
                Debug.Log("LEVEL COMPLETE !");
            }
        }
    }

}
