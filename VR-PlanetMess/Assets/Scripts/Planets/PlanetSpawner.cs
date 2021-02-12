using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public PlanetData planetData;

    public GameObject planetPrefab;

    // Update is called once per frame
    void Update()
    {
        //apuyer sur espace fait spawner des planètes randomisées
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject planetClone = Instantiate(planetPrefab);

            //taille random
            planetClone.GetComponent<PlanetScript>().size = planetData.size[Random.Range(0, 3)];
            Debug.Log(planetClone.GetComponent<PlanetScript>().size);

            //température random
            planetClone.GetComponent<PlanetScript>().temperature = planetData.temperature[Random.Range(0, 3)];
            Debug.Log(planetClone.GetComponent<PlanetScript>().temperature);


            //compsition random
            planetClone.GetComponent<PlanetScript>().composition = planetData.composition[Random.Range(0, 3)];
            Debug.Log(planetClone.GetComponent<PlanetScript>().composition);
        }
    }
}
