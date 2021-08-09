using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class RandomSpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Radius = 1;

    public float spawnRate = 1;

    public bool spawned = true;

    public int weakpointHit = 0;

    public bool dies = false;

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

    public void Weakpoint()
    {
        weakpointHit ++;
        if(weakpointHit >= 10)
        {
            dies = true;
            ReportMiniGameResult(dies);
        }
    }

    public void ReportMiniGameResult(bool dies)
    {
        Debug.Log("Win, send data to analytic");
        Analytics.CustomEvent("FightingMiniGameWin", new Dictionary<string, object>
        {
            {"EnemyTestObject", dies},
        });
    }
}
