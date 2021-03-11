using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    [Header("Attributes")]
    /*[HideInInspector]*/ private float size;

    private void Update()
    {
        //update de la taille
        transform.localScale = new Vector3(size, size, size);
    }
}
