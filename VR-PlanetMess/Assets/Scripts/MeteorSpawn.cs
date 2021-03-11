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

        Debug.Log("Initial Timer = " + initialTimer);
        random = UnityEngine.Random.Range(minTimeToSpawn, maxTimeToSpawn);

        StartCoroutine(meteorTimer(random));

        yield return 0;
    }

    public IEnumerator meteorTimer(int timer)
    {
        yield return new WaitForSeconds(timer);

        Debug.Log("Timer = " + timer);
        suns = GameObject.FindGameObjectsWithTag("Sun");
        randomSpawnPoint = UnityEngine.Random.Range(0, 19);
        GameObject actualMeteor = Instantiate(meteor, spawnPoints[randomSpawnPoint].transform.position, spawnPoints[randomSpawnPoint].transform.rotation);
        randomSun = UnityEngine.Random.Range(0, 3);
        actualMeteor.GetComponent<MeteorBehaviour>().ChaseSun(suns[randomSun]);
        random = UnityEngine.Random.Range(minTimeToSpawn, maxTimeToSpawn);

        StartCoroutine(meteorTimer(random));

        yield return 0;
    }
}
