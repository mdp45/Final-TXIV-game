using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABProjectile : MonoBehaviour {

    public float moveSpeed;
    public float xForce;
    public float yForce;
    public float dampenForce;

    public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            xForce += 6f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.gravityScale = 3;
            rb.AddForce(new Vector2(xForce - dampenForce, yForce));
            xForce = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.Rotate(new Vector3(0, 0, 45.0f) * Time.deltaTime);
            dampenForce += 6f;
            yForce += 10f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.transform.Rotate(new Vector3(0, 0, -45.0f) * Time.deltaTime);
            dampenForce -= 6f;
            yForce -= 10f;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
