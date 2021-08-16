using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bolt : MonoBehaviour
{
    public float speed = 30f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
