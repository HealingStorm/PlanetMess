using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    [Header("Attributes")]
    /*[HideInInspector]*/ public float size;
    /*[HideInInspector]*/ public Material temp;
    /*[HideInInspector]*/ public string compo;

    private void Update()
    {
        //update de la taille
        transform.localScale = new Vector3(size, size, size);

        //update de la température
        transform.GetComponent<MeshRenderer>().material = temp;

        //update de la composition
        
    }

}
