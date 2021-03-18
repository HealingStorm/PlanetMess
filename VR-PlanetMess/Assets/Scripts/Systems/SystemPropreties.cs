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
        orbit[0] = transform.Find("Orbits/Small Orbit Planet");
        orbit[1] = transform.Find("Orbits/Medium Orbit Planet");
        orbit[2] = transform.Find("Orbits/Big Orbit Planet");

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
        
    }
}
