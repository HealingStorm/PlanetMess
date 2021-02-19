using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSpawner : MonoBehaviour
{
    private Transform[] systemSpawnPointTransform = new Transform[4];
    [Space(10)]
    public GameObject systemPrefab;
    [Space(10)]
    public GameObject sunPrefab;
    public SunData sunData;
    private SunScript sunCloneScript;
    [Space(10)]
    public GameObject planetPrefab;
    public PlanetData planetData;
    private PlanetScript planetCloneScript;

    private void Start()
    {
        FindSystemsTransforms();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject systemClone = Instantiate(systemPrefab, systemSpawnPointTransform[Random.Range(0, 4)]);
            //Check si ya déjà un système sur le parent
            if (systemClone.transform.parent.childCount == 2)
            {
                Debug.Log("Déjà un système ici");
                Destroy(systemClone);
                return;
            }
            else
            {
                Transform[] orbit = new Transform[3];
                //attribution des orbits petit, moyen et grands (0, 1 , 2)
                orbit[0] = systemClone.transform.Find("Orbits/Small Orbit");
                orbit[1] = systemClone.transform.Find("Orbits/Medium Orbit");
                orbit[2] = systemClone.transform.Find("Orbits/Big Orbit");

                GameObject sunClone = Instantiate(sunPrefab, systemClone.transform);
                sunCloneScript = sunClone.GetComponent<SunScript>();
                sunCloneScript.size = sunData.size[Random.Range(0, 3)];

                for (int i = 0; i < orbit.Length; i++)
                {
                    GameObject planetClone = Instantiate(planetPrefab, orbit[i].transform);
                    planetCloneScript = planetClone.GetComponent<PlanetScript>();
                    //taille random
                    planetCloneScript.size = planetData.size[Random.Range(0, 3)];
                    //température random
                    planetCloneScript.temperature = planetData.temperature[Random.Range(0, 3)];
                    //compsition random
                    planetCloneScript.composition = planetData.composition[Random.Range(0, 3)];
                }
            }
        }
    }


    private void FindSystemsTransforms()
    {
        GameObject[] systemSpawnPoints = GameObject.FindGameObjectsWithTag("SystemSpawnPoint");
        for (int i = 0; i < systemSpawnPointTransform.Length; i++)
        {
            systemSpawnPointTransform[i] = systemSpawnPoints[i].transform;
        }
    }


}
