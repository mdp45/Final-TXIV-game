using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FProjectile : MonoBehaviour {

    public float forceIncrement;
    public float projectileForce;
    public float maxForce;
    public Rigidbody2D projectile;
    public Transform firingPoint;
    public ForceMode2D forceMode;
    public GameObject TurnManager;
    Animator anim;


    // Use this for initialization
    void Start () {
        projectileForce = 0f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            anim.SetInteger("State", 2);
            if (projectileForce < maxForce)
            {
                projectileForce += forceIncrement;                
            }
            else
            {
                projectileForce = maxForce;
            }            
        }
        if (CrossPlatformInputManager.GetButtonUp("Fire"))
        {
            Rigidbody2D instance = Instantiate(projectile, firingPoint.position, Quaternion.identity) as Rigidbody2D;
            instance.AddForce(firingPoint.right * projectileForce, forceMode);
            projectileForce = 0f;
            TurnManager.GetComponent<TurnManager>().SwitchPlayer();
        }
    }
}
