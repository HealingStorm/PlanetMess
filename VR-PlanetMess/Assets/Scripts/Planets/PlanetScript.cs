using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    [Header("Attributes")]
    /*[HideInInspector]*/ public float size;
    /*[HideInInspector]*/ public Material temperature;
    /*[HideInInspector]*/ public string composition;

    private void Update()
    {
        //update de la taille
        transform.localScale = new Vector3(size, size, size);

        //update de la température
        transform.GetComponent<MeshRenderer>().material = temperature;

        //update de la composition
        
    }

}
