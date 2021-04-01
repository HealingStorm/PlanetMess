using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDmg : MonoBehaviour
{
    public int hp = 3;

    public GameObject playerDeath;

    public GameObject deathVfx;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            hp--;
            Debug.Log(hp);
            if(hp == 0)
            {

                FindObjectOfType<AudioManager>().Play("Game Over");
                GameObject playerMort = Instantiate(playerDeath, GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("Player").transform.rotation);
                playerMort.transform.parent = null;
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                GameObject explosion = Instantiate(deathVfx, transform.position, transform.rotation);
                Destroy(explosion, 7f);
                explosion.transform.parent = null;
                Destroy(this.gameObject);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Meteor Hit");
            }
        }
    }
}

