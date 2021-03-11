using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDmg : MonoBehaviour
{
    public int hp = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            hp--;
            Debug.Log(hp);
            if(hp == 0)
            {
                Destroy(this);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            hp--;
            Debug.Log(hp);
            if (hp == 0)
            {
                Destroy(this);
            }
        }
    }
}
