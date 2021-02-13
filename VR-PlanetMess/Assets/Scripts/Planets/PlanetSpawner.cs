using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public PlanetData planetData;

    public GameObject planetPrefab;

    private PlanetScript planetCloneScript;

    void Update()
    {
        //apuyer sur espace fait spawner des planètes randomisées
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject planetClone = Instantiate(planetPrefab);
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
