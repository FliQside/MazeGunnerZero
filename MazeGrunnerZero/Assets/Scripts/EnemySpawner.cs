using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float waitTime = 5f;
    public float decreasePercent = 0.1f;
    public int numberToSpawn = 10;
    public Transform spawnPoint;
    public GameObject enemy;

    private float timer;
    private int totalSpawned;

    void Start()
    {
        if ( spawnPoint == null)
        {
            spawnPoint = gameObject.transform;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer = 0f;
            GameObject e = Instantiate(enemy, gameObject.transform.parent);
            e.transform.position = spawnPoint.position;
            e.transform.SetParent(gameObject.transform);

            totalSpawned += 1;

            if ( totalSpawned >= numberToSpawn)
            {
                e.GetComponent<EnemyHealth>();
                gameObject.SetActive(false);
            }

            waitTime -= (waitTime * decreasePercent);
        }
    }
}
