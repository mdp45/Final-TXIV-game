using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileSpeed = 15f;
    private Rigidbody2D projectileBody;


    // Use this for initialization
    void Start()
    {
        projectileBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        projectileBody.velocity = new Vector3(projectileSpeed, projectileBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
