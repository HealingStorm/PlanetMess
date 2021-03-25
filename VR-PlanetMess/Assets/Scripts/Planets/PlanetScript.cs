using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlanetScript : MonoBehaviour
{
    private GameManager gameManager;
    private bool[] cantGoInSystem = new bool[3];

    [HideInInspector]
    public int planetSizeIndex;
    [HideInInspector]
    public int planetTemperatureIndex;
    [HideInInspector]
    public int planetCompositionIndex;

    public Material orbitValidMaterial;
    public Material orbitNeutralMaterial;

    private Transform lastPosition;
    private Transform lastParent;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {

        if (planetSizeIndex == 2 || planetTemperatureIndex == 2)
        {
            cantGoInSystem[0] = true;
        }
        if(planetSizeIndex == 0 || planetCompositionIndex == 0)
        {
            cantGoInSystem[1] = true;
        }
        if (planetTemperatureIndex == 0 || planetCompositionIndex == 2)
        {
            cantGoInSystem[2] = true;
        }

        lastParent = transform.parent;
        lastPosition = transform.parent;
    }

    private void Update()
    {
        //si on prend la planète
        if (gameManager.takeSecurity == true)
        {
            gameManager.takeSecurity = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        /*
        #region Check si la planète peut aller sur l'orbite
        //PETIT SOLEIL
        if (other.gameObject.tag == "SmallOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] != true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = true;
            }
            else if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = false;
            }
        }
        if (other.gameObject.tag == "MediumOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] != true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = true;
            }
            else if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = false;
            }
        }
        if (other.gameObject.tag == "BigOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] != true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = true;
            }
            else if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = false;
            }
        }
        //MOYEN SOLEIL
        if (other.gameObject.tag == "SmallOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] != true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = true;
            }
            else if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = false;
            }
        }
        if (other.gameObject.tag == "MediumOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] != true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = true;
            }
            else if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = false;
            }
        }
        if (other.gameObject.tag == "BigOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] != true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = true;
            }
            else if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = false;
            }
        }
        //GRAND SOLEIL
        if (other.gameObject.tag == "SmallOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] != true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = true;
            }
            else if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = false;
            }
        }
        if (other.gameObject.tag == "MediumOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] != true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = true;
            }
            else if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = false;
            }
        }
        if (other.gameObject.tag == "BigOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] != true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = true;
            }
            else if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = false;
            }
        }
        #endregion
        */
        #region Snap des planètes sur un orbite

        //si on drop la planète
        if (gameManager.dropSecurity == true)
        {
            if (other.gameObject.tag == "SmallOrbit")
            {
                Debug.Log("smallorbit");
                Transform smallOrbitTransform = other.transform.parent.parent.Find("Small Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (smallOrbitTransform.childCount == 0)
                {
                    transform.parent = smallOrbitTransform;
                    transform.position = smallOrbitTransform.position;
                    lastParent = smallOrbitTransform;
                    lastPosition = smallOrbitTransform;
                    gameManager.dropSecurity = false;
                }
                /*else
                {
                    Debug.Log("nope");
                    transform.parent = lastParent;
                    transform.position = lastPosition.position;
                    gameManager.dropSecurity = false;
                }*/
            }
            else if (other.gameObject.tag == "MediumOrbit")
            {
                Debug.Log("mediumorbit");
                Transform mediumOrbitTransform = other.transform.parent.parent.Find("Medium Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (mediumOrbitTransform.childCount == 0)
                {
                    transform.parent = mediumOrbitTransform;
                    transform.position = mediumOrbitTransform.position;
                    lastParent = mediumOrbitTransform;
                    lastPosition = mediumOrbitTransform;
                    gameManager.dropSecurity = false;
                }
                /*else
                {
                    Debug.Log("nope");
                    transform.parent = lastParent;
                    transform.position = lastPosition.position;
                    gameManager.dropSecurity = false;
                }*/
            }
            else if (other.gameObject.tag == "BigOrbit")
            {
                Debug.Log("bigorbit");
                Transform bigOrbitTransform = other.transform.parent.parent.Find("Big Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (bigOrbitTransform.childCount == 0)
                {
                    transform.parent = bigOrbitTransform;
                    transform.position = bigOrbitTransform.position;
                    lastParent = bigOrbitTransform;
                    lastPosition = bigOrbitTransform;
                    gameManager.dropSecurity = false;
                }
                /*else
                {
                    Debug.Log("nope");
                    transform.parent = lastParent;
                    transform.position = lastPosition.position;
                    gameManager.dropSecurity = false;
                }*/
            }
            else if (other.gameObject.tag == "PlanetStorage")
            {
                Debug.Log("storage");
                Transform planetStorerTransform = other.transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (planetStorerTransform.childCount == 0)
                {
                    transform.parent = planetStorerTransform;
                    transform.position = planetStorerTransform.position;
                    lastParent = planetStorerTransform;
                    lastPosition = planetStorerTransform;
                    gameManager.dropSecurity = false;
                }
                /*else
                {
                    Debug.Log("nope");
                    transform.parent = lastParent;
                    transform.position = lastPosition.position;
                    gameManager.dropSecurity = false;
                }*/
            }
            if (other.gameObject.tag != "SmallOrbit" && other.gameObject.tag != "MediumOrbit" && other.gameObject.tag != "BigOrbit" && other.gameObject.tag != "PlanetStorage")
            {
                Debug.Log("rien");
                transform.parent = lastParent;
                transform.position = lastPosition.position;
                gameManager.dropSecurity = false;
            }
        }
        #endregion

    }
}
