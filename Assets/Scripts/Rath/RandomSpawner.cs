using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Radius = 1;

    public float spawnRate = 1;

    public bool spawned = true;

    // Update is called once per frame
    public void Update()
    {
        if(spawned == true)
        {
            StartCoroutine(SpawnTimer());
            spawned = false;
        }
    }

    public void SpawnEnemy()
    {
        Vector3 randomPos = Random.insideUnitCircle * Radius;
        Instantiate(EnemyPrefab, randomPos, Quaternion.identity);
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(spawnRate);
        SpawnEnemy();
        spawned = true;
    }
    /*
    private void Gizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }*/
}
