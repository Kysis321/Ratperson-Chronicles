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

    public int dies = 0;
    public void Weakpoint()
    {
        weakpointHit ++;
        if(weakpointHit >= 10)
        {
            dies = 1;
            ReportMiniGameResult(dies);
        }
    }

    public void ReportMiniGameResult(int dies)
    {
        Debug.Log("Win, send data to analytic");
        Analytics.CustomEvent("FightingMiniGameWin", new Dictionary<string, object>
        {
            {"EnemyTestInt", dies},
        });
    }
}
