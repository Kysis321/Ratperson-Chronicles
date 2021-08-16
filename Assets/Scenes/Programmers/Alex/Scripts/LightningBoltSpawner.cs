using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBoltSpawner : MonoBehaviour
{
    public Transform boltFire;
    public GameObject bolt;

    public float respawnTime = 3.0f;

    void Start()
    {
        StartCoroutine(boltSpawner());
    }

    void Update()
    {

    }

    void Shoot()
    {
        Quaternion spawnrotation = Quaternion.Euler(0, 0, 0);
        Instantiate(bolt, boltFire.position, spawnrotation);
    }

    IEnumerator boltSpawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            Shoot();
        }
    }
}
