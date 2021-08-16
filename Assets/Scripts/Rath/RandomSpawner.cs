using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class RandomSpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Radius = 2;

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
    }

    public bool dies = false;
    public void Weakpoint()
    {
        weakpointHit ++;
        spawned = true;
        //*BB
        if(weakpointHit >= 5)
        //if(weakpointHit >= 10)
        {
            spawned = false;
            dies = true;
            ReportMiniGameResult(dies);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ReportMiniGameResult(bool dies)
    {
        //*B debug.log("Win, send data to analytic. Message: " + dies);
        Analytics.CustomEvent("fightingMiniGameWin", new Dictionary<string, object>
        {
            {"fightingMiniGameBoolTestMainBranch", dies},
        });
    }
}
