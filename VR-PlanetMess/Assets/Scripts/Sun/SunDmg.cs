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
                FindObjectOfType<AudioManager>().Play("Game Over");
                Destroy(this.gameObject);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Meteor Hit");
            }
        }
    }
}

