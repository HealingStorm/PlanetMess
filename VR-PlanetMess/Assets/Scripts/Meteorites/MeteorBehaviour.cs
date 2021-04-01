using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    public GameObject sunPosition;

    public float followSpeed = 10;

    public GameObject meteorVfx;

    private void Update()
    {
        if (GameManager.Instance.isDead == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, sunPosition.transform.position, Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sun"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("LeftHand"))
        {

            FindObjectOfType<AudioManager>().Play("Meteor Parry");
            GameObject explosion = Instantiate(meteorVfx, transform.position, transform.rotation);
            Destroy(explosion, 7f);
            explosion.transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
