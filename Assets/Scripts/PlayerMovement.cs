using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D playerbody;
    Animator anim;


    // Use this for initialization

    void Start()
    {
        playerbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        moveLeftRight(CrossPlatformInputManager.GetAxisRaw("Horizontal"));
        if (CrossPlatformInputManager.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            anim.SetInteger("State", 0);
        }

    }

    void moveLeftRight(float moveInput)
    {
        Vector2 moveVelocity = playerbody.velocity;
        moveVelocity.x = moveInput * speed;
        playerbody.velocity = moveVelocity;
        /*float moveX = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveX, 0);
        playerbody.AddForce(movement * speed);*/
    }
}