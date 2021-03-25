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
    }

    private void Update()
    {
        //si on prend la planète
        if (gameManager.takeSecurity == true)
        {
            Debug.Log("drop");
            //transform.parent = null;
            gameManager.takeSecurity = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
        /*
        #region Check si la planète peut aller sur l'orbite
        //PETIT SOLEIL
        if (other.gameObject.tag == "SmallOrbit")
        {
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
                Transform smallOrbitTransform = other.transform.parent.parent.Find("Small Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (smallOrbitTransform.childCount == 0)
                {
                    Debug.Log("bruh");
                    transform.parent = smallOrbitTransform;
                    transform.position = new Vector3(smallOrbitTransform.position.x, smallOrbitTransform.position.y, smallOrbitTransform.position.z);
                    /*lastPosition.position = transform.position;
                    lastParent.parent = transform.parent;*/
                }
            }
            else if (other.gameObject.tag == "MediumOrbit")
            {
                Transform mediumOrbitTransform = other.transform.parent.parent.Find("Medium Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (mediumOrbitTransform.childCount == 0)
                {
                    transform.parent = mediumOrbitTransform;
                    transform.position = new Vector3(mediumOrbitTransform.position.x, mediumOrbitTransform.position.y, mediumOrbitTransform.position.z);
                    /*lastPosition.position = transform.position;
                    lastParent.parent = transform.parent;*/
                }
            }
            else if (other.gameObject.tag == "BigOrbit")
            {
                Transform bigOrbitTransform = other.transform.parent.parent.Find("Big Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (bigOrbitTransform.childCount == 0)
                {
                    transform.parent = bigOrbitTransform;
                    transform.position = new Vector3(bigOrbitTransform.position.x, bigOrbitTransform.position.y, bigOrbitTransform.position.z);
                    /*lastPosition.position = transform.position;
                    lastParent.parent = transform.parent;*/
                }
            }
            else if (other.gameObject.tag == "PlanetStorage")
            {
                Transform planetStorerTransform = other.transform;
                //Si on a aucun enfant on peut placer la planète qui a collidé
                if (planetStorerTransform.childCount == 0)
                {
                    transform.parent = planetStorerTransform;
                    transform.position = new Vector3(planetStorerTransform.position.x, planetStorerTransform.position.y, planetStorerTransform.position.z);
                    /*lastPosition.position = transform.position;
                    lastParent.parent = transform.parent;*/
                }
            }
            /*else
            {
                transform.position = lastPosition.position;
                transform.parent = lastParent.parent;
            }*/
            gameManager.dropSecurity = false;
        }
        #endregion

    }
}
