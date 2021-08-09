using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    RandomSpawner spawner;

    void Start()
    {
        spawner = GameObject.Find("WeakpointsSpawner").GetComponent<RandomSpawner>();
    }

    public void onClickEnemy()
    {
        spawner.Weakpoint();
        Destroy(gameObject);
    }
}
