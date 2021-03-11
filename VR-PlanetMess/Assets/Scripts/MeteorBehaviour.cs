using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    public GameObject sunPosition;

    public float followSpeed = 10;

    private void Update()
    {
        this.transform.position = Vector3.Lerp(sunPosition.transform.position, this.transform.position, followSpeed * Time.deltaTime);
    }
}
