using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public PlanetData planetData;

    public GameObject planetPrefab;

    private PlanetScript planetCloneScript;
    private MeshRenderer planetCloneMeshRenderer;

    // Update is called once per frame
    void Update()
    {
        //apuyer sur espace fait spawner des planètes randomisées
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject planetClone = Instantiate(planetPrefab);
            planetCloneScript = planetClone.GetComponent<PlanetScript>();
            planetCloneMeshRenderer = planetClone.GetComponent<MeshRenderer>();

            //taille random
            planetCloneScript.size = planetData.size[Random.Range(0, 3)];
            planetClone.transform.localScale = new Vector3(planetCloneScript.size, planetCloneScript.size, planetCloneScript.size);

            //température random
            planetCloneScript.temperature = planetData.temperature[Random.Range(0, 3)];
            planetCloneMeshRenderer.material = planetCloneScript.temperature;


            //compsition random
            planetCloneScript.composition = planetData.composition[Random.Range(0, 3)];
        }
    }
}
