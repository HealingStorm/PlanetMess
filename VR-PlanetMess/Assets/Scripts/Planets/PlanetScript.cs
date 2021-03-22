using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlanetScript : MonoBehaviour
{
    [HideInInspector]
    public bool interactionSecurity;
    private bool[] cantGoInSystem = new bool[3];

    [HideInInspector]
    public int planetSizeIndex;
    [HideInInspector]
    public int planetTemperatureIndex;
    [HideInInspector]
    public int planetCompositionIndex;

    public Material orbitValidMaterial;
    public Material orbitNeutralMaterial;

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
    public void OnPlanetDrop()
    {
        interactionSecurity = true;
    }

    private void OnTriggerStay(Collider other)
    {
        SystemPropreties SystemPropretiesScript = other.transform.parent.parent.parent.GetComponent<SystemPropreties>();
        #region Check si la plan�te peut aller sur l'orbite
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

        #region Snap des plan�tes sur un orbite

        //s�curit�
        if (interactionSecurity == true)
        {
                if (other.gameObject.tag == "SmallOrbit")
                {
                    Transform smallOrbitTransform = other.transform.parent.parent.Find("Small Orbit Planet").transform;
                    //Si on a aucun enfant on peut placer la plan�te qui a collid�
                    if (smallOrbitTransform.childCount == 0)
                    {
                        transform.parent = smallOrbitTransform;
                        transform.position = new Vector3(smallOrbitTransform.position.x, smallOrbitTransform.position.y, smallOrbitTransform.position.z);
                    }
                }
                if (other.gameObject.tag == "MediumOrbit")
                {
                    Transform mediumOrbitTransform = other.transform.parent.parent.Find("Medium Orbit Planet").transform;
                    //Si on a aucun enfant on peut placer la plan�te qui a collid�
                    if (mediumOrbitTransform.childCount == 0)
                    {
                        transform.parent = mediumOrbitTransform;
                        transform.position = new Vector3(mediumOrbitTransform.position.x, mediumOrbitTransform.position.y, mediumOrbitTransform.position.z);
                    }
                }
                if (other.gameObject.tag == "BigOrbit")
                {
                    Transform bigOrbitTransform = other.transform.parent.parent.Find("Big Orbit Planet").transform;
                    //Si on a aucun enfant on peut placer la plan�te qui a collid�
                    if (bigOrbitTransform.childCount == 0)
                    {
                        transform.parent = bigOrbitTransform;
                        transform.position = new Vector3(bigOrbitTransform.position.x, bigOrbitTransform.position.y, bigOrbitTransform.position.z);
                    }
                }
            interactionSecurity = false;
        }
        #endregion

    }
}
