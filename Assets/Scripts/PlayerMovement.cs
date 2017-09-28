using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D playerbody;
    Animator anim;


    /// <summary>
    /// Start gets the player components needed to move the player.
    /// </summary>
    void Start()
    {
        playerbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// This checks for input and calls the neccessary animations when the player is walking.
    /// </summary>
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

    /// <summary>
    /// This funtion moves the player at a specified speed.
    /// </summary>
    /// <param name="moveInput"></param>
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