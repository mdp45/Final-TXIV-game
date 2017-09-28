using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{

    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.A)))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("State", 2);
        }

        

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetInteger("State", 3);
        }

        if ((Input.GetKeyUp(KeyCode.D)) || 
            (Input.GetKeyUp(KeyCode.A)) || 
            (Input.GetKeyUp(KeyCode.Space)) ||
            (Input.GetKeyUp(KeyCode.F)))
        {
            anim.SetInteger("State", 0);
        }

    }
}
