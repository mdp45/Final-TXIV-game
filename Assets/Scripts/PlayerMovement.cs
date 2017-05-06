using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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
        moveLeftRight(CrossPlatformInputManager.GetAxisRaw("Horizontal"));
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

    public void LeftTouch()
    {
        moveLeftRight(-1);
    }

    public void RightTouch()
    {
        moveLeftRight(1);
    }

    public void NoInput()
    {
        moveLeftRight(0);
    }
}