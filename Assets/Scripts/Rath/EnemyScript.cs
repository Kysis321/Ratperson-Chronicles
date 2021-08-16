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




    public void zBFIX()
    {
        var cursor = GameObject.Find("Cursorrr");
        //cursor.GetComponent<CursorController>().zDetectObject();
    }

	private void OnMouseDown()
	{
        //zBFIX(transform.tag);

        spawner.Weakpoint();
        Destroy(gameObject);
    }
}
