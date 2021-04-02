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
    public int planetTempCompoIndex;

    public Material orbitValidMaterial;
    public Material orbitNeutralMaterial;

    public bool onOrbit = true;
    private GameObject lastOrbitMat;

    //[HideInInspector]
    public bool dropSecurity;
    //[HideInInspector]
    public bool takeSecurity;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (transform.parent.name == "Small Orbit Planet")
        {
            lastOrbitMat = transform.parent.parent.Find("OrbitSmall").gameObject;
        }
        if (transform.parent.name == "Medium Orbit Planet")
        {
            lastOrbitMat = transform.parent.parent.Find("OrbitMedium").gameObject;
        }
        if (transform.parent.name == "Big Orbit Planet")
        {
            lastOrbitMat = transform.parent.parent.Find("OrbitBig").gameObject;
        }
    }
    private void Start()
    {

        if (planetSizeIndex == 2 || planetTempCompoIndex == 2 || planetTempCompoIndex == 5 || planetTempCompoIndex == 8)
        {
            cantGoInSystem[0] = true;
        }
        if (planetSizeIndex == 0 || planetTempCompoIndex == 0 || planetTempCompoIndex == 1 || planetTempCompoIndex == 2)
        {
            cantGoInSystem[1] = true;
        }
        if (planetTempCompoIndex == 0 || planetTempCompoIndex == 3 || planetTempCompoIndex == 6 || planetTempCompoIndex == 7 || planetTempCompoIndex == 8)
        {
            cantGoInSystem[2] = true;
        }

    }

    private void Update()
    {
        //si on prend la plan�te
        if (takeSecurity == true)
        {
            onOrbit = false;
            lastOrbitMat.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
            takeSecurity = false;
        }

    }

    private void OntriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            takeSecurity = true;
        }
    }
    private void OntriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            dropSecurity = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {

        #region Check si la plan�te peut aller sur l'orbite
        //PETIT SOLEIL
        if (other.gameObject.tag == "SmallOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] != true && onOrbit == true)
            {
                lastOrbitMat.GetComponent<MeshRenderer>().material = other.transform.parent.GetComponent<MeshRenderer>().material;
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = true;
            }
            else if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] == true && onOrbit == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = false;
            }
        }
        if (other.gameObject.tag == "MediumOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] != true && onOrbit == true)
            {
                lastOrbitMat.GetComponent<MeshRenderer>().material = other.transform.parent.GetComponent<MeshRenderer>().material;
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = true;
            }
            else if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] == true && onOrbit == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = false;
            }
        }
        if (other.gameObject.tag == "BigOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] != true && onOrbit == true)
            {
                lastOrbitMat.GetComponent<MeshRenderer>().material = other.transform.parent.GetComponent<MeshRenderer>().material;
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = true;
            }
            else if (SystemPropretiesScript.sunSize == 0 && cantGoInSystem[0] == true && onOrbit == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = false;
            }
        }
        //MOYEN SOLEIL
        if (other.gameObject.tag == "SmallOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] != true && onOrbit == true)
            {
                lastOrbitMat.GetComponent<MeshRenderer>().material = other.transform.parent.GetComponent<MeshRenderer>().material;
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = true;
            }
            else if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] == true && onOrbit == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = false;
            }
        }
        if (other.gameObject.tag == "MediumOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] != true && onOrbit == true)
            {
                lastOrbitMat.GetComponent<MeshRenderer>().material = other.transform.parent.GetComponent<MeshRenderer>().material;
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = true;
            }
            else if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] == true && onOrbit == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = false;
            }
        }
        if (other.gameObject.tag == "BigOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] != true && onOrbit == true)
            {
                lastOrbitMat.GetComponent<MeshRenderer>().material = other.transform.parent.GetComponent<MeshRenderer>().material;
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = true;
            }
            else if (SystemPropretiesScript.sunSize == 1 && cantGoInSystem[1] == true && onOrbit == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = false;
            }
        }
        //GRAND SOLEIL
        if (other.gameObject.tag == "SmallOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] != true && onOrbit == true)
            {
                lastOrbitMat.GetComponent<MeshRenderer>().material = other.transform.parent.GetComponent<MeshRenderer>().material;
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = true;
            }
            else if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] == true && onOrbit == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[0] = false;
            }
        }
        if (other.gameObject.tag == "MediumOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] != true && onOrbit == true)
            {
                lastOrbitMat.GetComponent<MeshRenderer>().material = other.transform.parent.GetComponent<MeshRenderer>().material;
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = true;
            }
            else if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] == true && onOrbit == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[1] = false;
            }
        }
        if (other.gameObject.tag == "BigOrbit")
        {
            SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
            if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] != true && onOrbit == true)
            {
                lastOrbitMat.GetComponent<MeshRenderer>().material = other.transform.parent.GetComponent<MeshRenderer>().material;
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitValidMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = true;
            }
            else if (SystemPropretiesScript.sunSize == 2 && cantGoInSystem[2] == true && onOrbit == true)
            {
                other.transform.parent.GetComponent<MeshRenderer>().material = orbitNeutralMaterial;
                other.transform.parent.parent.parent.GetComponent<SystemPropreties>().orbitDone[2] = false;
            }
        }
        #endregion

        #region Snap des plan�tes sur un orbite

        //si on drop la plan�te
        if (dropSecurity == true)
        {
            if (other.gameObject.tag == "SmallOrbit")
            {
                Debug.Log("smallorbit");
                Transform smallOrbitTransform = other.transform.parent.parent.Find("Small Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la plan�te qui a collid�
                if (smallOrbitTransform.childCount == 0)
                {
                    onOrbit = true;
                    transform.parent = smallOrbitTransform;
                    transform.position = smallOrbitTransform.position;
                    dropSecurity = false;
                }
                else
                {
                    onOrbit = false;
                    dropSecurity = false;
                }
            }
            else if (other.gameObject.tag == "MediumOrbit")
            {
                Debug.Log("mediumorbit");
                Transform mediumOrbitTransform = other.transform.parent.parent.Find("Medium Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la plan�te qui a collid�
                if (mediumOrbitTransform.childCount == 0)
                {
                    onOrbit = true;
                    transform.parent = mediumOrbitTransform;
                    transform.position = mediumOrbitTransform.position;
                    dropSecurity = false;
                }
                else
                {
                    onOrbit = false;
                    dropSecurity = false;
                }
            }
            else if (other.gameObject.tag == "BigOrbit")
            {
                Debug.Log("bigorbit");
                Transform bigOrbitTransform = other.transform.parent.parent.Find("Big Orbit Planet").transform;
                //Si on a aucun enfant on peut placer la plan�te qui a collid�
                if (bigOrbitTransform.childCount == 0)
                {
                    onOrbit = true;
                    transform.parent = bigOrbitTransform;
                    transform.position = bigOrbitTransform.position;
                    dropSecurity = false;
                }
                else
                {
                    onOrbit = false;
                    dropSecurity = false;
                }
            }
            else
            {
                onOrbit = false;
                dropSecurity = false;
            }
        }
        #endregion

    }
}
