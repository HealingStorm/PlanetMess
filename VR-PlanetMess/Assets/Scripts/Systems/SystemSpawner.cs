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
        //Tant qu'on a pas de système sur tous les 4 points, on essaye d'en faire spawn un
        while (transform.GetChild(0).transform.childCount < 1 ||
               transform.GetChild(1).transform.childCount < 1 ||
               transform.GetChild(2).transform.childCount < 1 ||
               transform.GetChild(3).transform.childCount < 1)
        {
            GameObject systemClone = Instantiate(systemPrefab, systemSpawnPointTransform[Random.Range(0, 4)]);
            //Check si ya déjà un système sur le parent
            if (systemClone.transform.parent.childCount == 2)
            {
                Debug.Log("Déjà un système ici");
                Destroy(systemClone);
                return;
            }
            //si il n'y en a pas...
            else
            {
                Transform[] orbit = new Transform[3];
                //attribution des orbits petit, moyen et grands (0, 1 , 2)
                orbit[0] = systemClone.transform.Find("Orbits/Small Orbit");
                orbit[1] = systemClone.transform.Find("Orbits/Medium Orbit");
                orbit[2] = systemClone.transform.Find("Orbits/Big Orbit");

                //attributs de chaque planète pour un soleil :
                //-PETIT : 
                //  -orbite près : petit/tempéré/aquatique
                //  -orbite milieu : grand/froid/gazeux
                //  -orbite loin : moyen/froid/gazeux
                //-MOYEN : 
                //  -orbite près : moyen/chaud/rocheux
                //  -orbite milieu : grand/tempéré/gazeux
                //  -orbite loin : moyen/froid/aquatique
                //-GRAND : 
                //  -orbite près : grand/chaud/aquatique
                //  -orbite milieu : grand/chaud/rocheux
                //  -orbite loin : petit/tempéré/rocheux

                //on fait spawn le soleil du système
                GameObject sunClone = Instantiate(sunPrefab, systemClone.transform);
                //on lui donne sa taille
                sunCloneScript = sunClone.GetComponent<SunScript>();
                sunCloneScript.size = sunData.size[Random.Range(0, 3)];

                //pour chaque orbit on instantie une planète
                for (int i = 0; i < orbit.Length; i++)
                {
                    switch (sunCloneScript.size)
                    {
                        //petite taille
                        case 0.08f:
                            GameObject planetClone = Instantiate(planetPrefab, orbit[i].transform);
                            planetCloneScript = planetClone.GetComponent<PlanetScript>();
                            //taille random
                            planetCloneScript.size = planetData.size[Random.Range(0, 3)];
                            switch (planetCloneScript.size)
                            {
                                case 0.04f:
                                    planetCloneScript.temperature = planetData.temperature[1];
                                    break;
                                case 0.08f:
                                    planetCloneScript.temperature = planetData.temperature[0];
                                    break;
                                case 0.12f:
                                    planetCloneScript.temperature = planetData.temperature[0];
                                    break;
                            }
                            //température random
                            planetCloneScript.temperature = planetData.temperature[Random.Range(0, 3)];
                            //composition random
                            planetCloneScript.composition = planetData.composition[Random.Range(0, 3)];
                            break;
                        //moyenne taille
                        case 0.14f:

                            break;
                        //grande taille
                        case 0.18f:

                            break;
                    }
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
