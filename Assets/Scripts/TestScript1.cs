using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript1 : MonoBehaviour {

    public GameObject TurnManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
        if (collision.gameObject.CompareTag("p1"))
        {
            TurnManager.GetComponent<TurnManager>().SwitchToPlayer2();
        }
        if (collision.gameObject.CompareTag("p2"))
        {
            TurnManager.GetComponent<TurnManager>().SwitchToPlayer1();
        }

    }
}
