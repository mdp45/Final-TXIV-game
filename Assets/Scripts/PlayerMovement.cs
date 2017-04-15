using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D playerbody;



    // Use this for initialization

    void Start()
    {
        playerbody = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveX, 0);
        playerbody.AddForce(movement * speed);
    }
}