using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public int initialTimer = 5;
    private int random;
    private int randomSpawnPoint;
    private int randomSun;

    public int minTimeToSpawn = 3;
    public int maxTimeToSpawn = 5;

    public GameObject[] suns;
    public GameObject[] spawnPoints;

    public GameObject meteor;


    private void Start()
    {
        StartCoroutine(initialMeteor(initialTimer));
    }

    public IEnumerator initialMeteor(int initialCountdown)
    {
        yield return new WaitForSeconds(initialTimer);

        //Debug.Log("Initial Timer = " + initialTimer);
        random = Random.Range(minTimeToSpawn, maxTimeToSpawn);

        StartCoroutine(meteorTimer(random));

        yield return 0;
    }

    public IEnumerator meteorTimer(int timer)
    {
        yield return new WaitForSeconds(timer);

        if (GameManager.Instance.isDead == false)
        {
            //Debug.Log("Timer = " + timer);
            if (GameManager.Instance.isDead == false)
            {
                spawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
            }
            if (GameManager.Instance.isDead == false)
            {
                randomSpawnPoint = Random.Range(0, 20);
            }
            if (GameManager.Instance.isDead == false)
            {
                FindObjectOfType<AudioManager>().Play("Meteor Spawn");
            }
            if (GameManager.Instance.isDead == false)
            {
                GameObject actualMeteor = Instantiate(meteor, spawnPoints[randomSpawnPoint].transform.position, spawnPoints[randomSpawnPoint].transform.rotation);

                randomSun = Random.Range(0, 4);
                suns = GameObject.FindGameObjectsWithTag("Sun");
                if (GameManager.Instance.isDead == false)
                {
                    actualMeteor.GetComponent<MeteorBehaviour>().sunPosition = suns[randomSun];
                }
                }
            if (GameManager.Instance.isDead == false)
            {
                random = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            }

            StartCoroutine(meteorTimer(random));
        }

        yield return 0;
    }
}
