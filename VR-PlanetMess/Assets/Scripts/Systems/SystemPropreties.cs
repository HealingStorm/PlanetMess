using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPropreties : MonoBehaviour
{
    public GameObject sunPrefab;
    public SunData sunData;
    [Tooltip("0, petit, 1 moyen, 2 grand")]
    [Range(0,2)]
    public int sunSize;

    private Transform[] orbit = new Transform[3];

    [Space(30)]
    public GameObject planetPrefab;
    public PlanetData planetData;

    [Space(10)]
    [Header("Planète 1 = petit orbite, Planète 2 = moyen orbite, Planète 3 = grand orbite")]
    [Tooltip("0, petit, 1 moyen, 2 grand")]
    [Range(0, 2)]
    public int planet1Size;
    [Tooltip("0, froid, 1 tempéré, 2 chaud")]
    [Range(0, 2)]
    public int planet1Temp;
    [Tooltip("0, gazeux, 1 rocheux, 2 aquatique")]
    [Range(0, 2)]
    public int planet1Compo;
    [Tooltip("0, petit, 1 moyen, 2 grand")]

    [Space(10)]
    [Range(0, 2)]
    public int planet2Size;
    [Tooltip("0, froid, 1 tempéré, 2 chaud")]
    [Range(0, 2)]
    public int planet2Temp;
    [Tooltip("0, gazeux, 1 rocheux, 2 aquatique")]
    [Range(0, 2)]
    public int planet2Compo;
    [Tooltip("0, petit, 1 moyen, 2 grand")]

    [Space(10)]
    [Range(0, 2)]
    public int planet3Size;
    [Tooltip("0, froid, 1 tempéré, 2 chaud")]
    [Range(0, 2)]
    public int planet3Temp;
    [Tooltip("0, gazeux, 1 rocheux, 2 aquatique")]
    [Range(0, 2)]
    public int planet3Compo;

    private void Start()
    {
        //Soleil
        GameObject sun = Instantiate(sunPrefab, transform.position, Quaternion.identity, transform);
        sun.transform.localScale = new Vector3(sunData.size[sunSize], sunData.size[sunSize], sunData.size[sunSize]);

        //Orbit
        orbit[0] = transform.Find("Orbits/Small Orbit");
        orbit[1] = transform.Find("Orbits/Medium Orbit");
        orbit[2] = transform.Find("Orbits/Big Orbit");

        //Planets
        GameObject planet1 = Instantiate(planetPrefab, orbit[0].position, Quaternion.identity, orbit[0]);
        planet1.transform.localScale = new Vector3(planetData.size[planet1Size], planetData.size[planet1Size], planetData.size[planet1Size]);
        planet1.transform.GetComponent<MeshRenderer>().material = planetData.temp[planet1Temp];

        GameObject planet2 = Instantiate(planetPrefab, orbit[1].position, Quaternion.identity, orbit[1]);
        planet2.transform.localScale = new Vector3(planetData.size[planet2Size], planetData.size[planet2Size], planetData.size[planet2Size]);
        planet2.transform.GetComponent<MeshRenderer>().material = planetData.temp[planet2Temp];

        GameObject planet3 = Instantiate(planetPrefab, orbit[2].position, Quaternion.identity, orbit[2]);
        planet3.transform.localScale = new Vector3(planetData.size[planet3Size], planetData.size[planet3Size], planetData.size[planet3Size]);
        planet3.transform.GetComponent<MeshRenderer>().material = planetData.temp[planet3Temp];
    }

    private void Update()
    {

        #region Vieux Code
        /*//Tant qu'on a pas de système sur tous les 4 points, on essaye d'en faire spawn un
        while (transform.GetChild(0).transform.childCount < 1 ||
               transform.GetChild(1).transform.childCount < 1 ||
               transform.GetChild(2).transform.childCount < 1 ||
               transform.GetChild(3).transform.childCount < 1)
        {
            GameObject systemClone = Instantiate(systemPrefab, systemSpawnPointTransform[Random.Range(0, 4)]);
            //Check si ya déjà un système sur le parent pour éviter les doublons
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

                //on fait spawn le soleil du système
                GameObject sunClone = Instantiate(sunPrefab, systemClone.transform);
                //on lui donne sa taille random
                sunCloneScript = sunClone.GetComponent<SunScript>();
                sunCloneScript.size = sunData.size[Random.Range(0, 3)];

                //pour chaque orbit on instantie une planète
                for (int i = 0; i < orbit.Length; i++)
                {
                    GameObject planetClone = Instantiate(planetPrefab, orbit[i].transform);
                    planetCloneScript = planetClone.GetComponent<PlanetScript>();
                    //taille random
                    planetCloneScript.size = planetData.size[Random.Range(0, 3)];
                    //température random
                    planetCloneScript.temp = planetData.temp[Random.Range(0, 3)];
                    //composition random
                    planetCloneScript.compo = planetData.compo[Random.Range(0, 3)];

                    //si on a une planète qui a tout les attributs qui vont avec la taille du Soleil, 
                    //on la randomize une seconde fois sur le même orbite pour essayer d'avoir une planète qui n'est pas sensé être sur ce système
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
        }*/
        #endregion
    }
}
