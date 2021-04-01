using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dontdestroyonload : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
