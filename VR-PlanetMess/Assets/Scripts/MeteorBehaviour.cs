using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    public GameObject sunPosition;

    public float followSpeed = 10;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, sunPosition.transform.position, Time.deltaTime);
    }
}
