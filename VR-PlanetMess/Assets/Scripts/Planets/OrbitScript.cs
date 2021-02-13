using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    private GameObject[] orbits = new GameObject[3];
    public float[] orbitSpeed = new float[3] { 45f, 25f, 10f };


    private void Start()
    {
        for (int i = 0; i < orbits.Length; i++)
        {
            if(i == 0)
            {
                orbits[0] = GameObject.FindGameObjectWithTag("SmallOrbit");
            }

            if (i == 1)
            {
                orbits[1] = GameObject.FindGameObjectWithTag("MediumOrbit");
            }

            if (i == 2)
            {
                orbits[2] = GameObject.FindGameObjectWithTag("BigOrbit");
            }

            if(orbits[i] == null)
            {
                return;
            }
        }
    }
    private void Update()
    {
        //Rotate small orbit
        orbits[0].transform.RotateAround(transform.position, Vector3.up, orbitSpeed[0] * Time.deltaTime);
        //Rotate medium orbit
        orbits[1].transform.RotateAround(transform.position, Vector3.up, orbitSpeed[1] * Time.deltaTime);
        //Rotate big obit
        orbits[2].transform.RotateAround(transform.position, Vector3.up, orbitSpeed[2] * Time.deltaTime);
    }
}
