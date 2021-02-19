using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    private GameObject[] orbit = new GameObject[3];
    public int[] orbitSpeed = new int[3] { 45, 25, 10 };
    public int[] planetRotationSpeed = new int[3] { 30, 20, 10 };


    private void Start()
    {
        #region Assignation of each orbit[] GameObject
        orbit[0] = transform.Find("Small Orbit").gameObject;
        orbit[1] = transform.Find("Medium Orbit").gameObject;
        orbit[2] = transform.Find("Big Orbit").gameObject;
        #endregion
    }
    private void Update()
    {
        #region Rotation of planets in each orbit
        //Rotate small orbit
        orbit[0].transform.RotateAround(transform.position, Vector3.up, orbitSpeed[0] * Time.deltaTime);
        //Rotate medium orbit
        orbit[1].transform.RotateAround(transform.position, Vector3.up, orbitSpeed[1] * Time.deltaTime);
        //Rotate big obit
        orbit[2].transform.RotateAround(transform.position, Vector3.up, orbitSpeed[2] * Time.deltaTime);
        #endregion
        #region Rotation of planets
        //Rotate small planet
        orbit[0].transform.Rotate(Vector3.up, planetRotationSpeed[0] * Time.deltaTime);
        //Rotate medium planet
        orbit[1].transform.Rotate(Vector3.up, planetRotationSpeed[1] * Time.deltaTime);
        //Rotate big planet
        orbit[2].transform.Rotate(Vector3.up, planetRotationSpeed[2] * Time.deltaTime);
        #endregion
    }
}
