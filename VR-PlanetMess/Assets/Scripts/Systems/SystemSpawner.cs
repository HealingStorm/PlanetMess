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
        //Tant qu'on a pas de syst�me sur tous les 4 points, on essaye d'en faire spawn un
        while (transform.GetChild(0).transform.childCount < 1 ||
               transform.GetChild(1).transform.childCount < 1 ||
               transform.GetChild(2).transform.childCount < 1 ||
               transform.GetChild(3).transform.childCount < 1)
        {
            GameObject systemClone = Instantiate(systemPrefab, systemSpawnPointTransform[Random.Range(0, 4)]);
            //Check si ya d�j� un syst�me sur le parent pour �viter les doublons
            if (systemClone.transform.parent.childCount == 2)
            {
                Debug.Log("D�j� un syst�me ici");
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

                //on fait spawn le soleil du syst�me
                GameObject sunClone = Instantiate(sunPrefab, systemClone.transform);
                //on lui donne sa taille random
                sunCloneScript = sunClone.GetComponent<SunScript>();
                sunCloneScript.size = sunData.size[Random.Range(0, 3)];

                //pour chaque orbit on instantie une plan�te
                for (int i = 0; i < orbit.Length; i++)
                {
                    GameObject planetClone = Instantiate(planetPrefab, orbit[i].transform);
                    planetCloneScript = planetClone.GetComponent<PlanetScript>();
                    //taille random
                    planetCloneScript.size = planetData.size[Random.Range(0, 3)];
                    //temp�rature random
                    planetCloneScript.temp = planetData.temp[Random.Range(0, 3)];
                    //composition random
                    planetCloneScript.compo = planetData.compo[Random.Range(0, 3)];

                    //si on a une plan�te qui a tout les attributs qui vont avec la taille du Soleil, 
                    //on la randomize une seconde fois sur le m�me orbite pour essayer d'avoir une plan�te qui n'est pas sens� �tre sur ce syst�me
                    switch (sunCloneScript.size)
                    {
                        //petite taille de Soleil
                        case 0.06f:
                            if((planetCloneScript.size == planetData.size[1] || planetCloneScript.size == planetData.size[2]) && 
                                (planetCloneScript.temp == planetData.temp[0] || planetCloneScript.temp == planetData.temp[1]) &&
                                (planetCloneScript.compo == planetData.compo[0] || planetCloneScript.compo == planetData.compo[1] || planetCloneScript.compo == planetData.compo[2]))
                            {
                                i -= 1;
                                Destroy(planetClone);
                            }
                            break;
                        //moyenne taille de Soleil
                        case 0.08f:
                            if ((planetCloneScript.size == planetData.size[0] || planetCloneScript.size == planetData.size[1]) &&
                                (planetCloneScript.temp == planetData.temp[0] || planetCloneScript.temp == planetData.temp[1] || planetCloneScript.temp == planetData.temp[2]) &&
                                (planetCloneScript.compo == planetData.compo[1] || planetCloneScript.compo == planetData.compo[2]))
                            {
                                i -= 1;
                                Destroy(planetClone);
                            }
                            break;
                        //grande taille de Soleil
                        case 0.1f:
                            if ((planetCloneScript.size == planetData.size[0] || planetCloneScript.size == planetData.size[1] || planetCloneScript.size == planetData.size[2]) &&
                                (planetCloneScript.temp == planetData.temp[1] || planetCloneScript.temp == planetData.temp[2]) &&
                                (planetCloneScript.compo == planetData.compo[0] || planetCloneScript.compo == planetData.compo[1]))
                            {
                                i -= 1;
                                Destroy(planetClone);
                            }
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
