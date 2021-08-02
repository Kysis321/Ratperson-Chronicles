using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBoltSpawner : MonoBehaviour
{
    public GameObject BoltPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(boltWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(BoltPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.y * 1, Random.Range(-screenBounds.y, screenBounds.x));
    }

    IEnumerator boltWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
