using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public GameObject PlayerL;
    public GameObject PlayerR;

    public enum gameStates
    {
        PLAYL,
        PLAYR
    }

    private gameStates currentTurn;

	// Use this for initialization
	void Start ()
    {
        currentTurn = gameStates.PLAYL;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(currentTurn);
        switch (currentTurn)
        {
            case (gameStates.PLAYL):
                {
                    //disable play2 movement and control scripts
                    PlayerR.GetComponent<PlayerMovement>().enabled = false;
                    PlayerL.GetComponent<PlayerMovement>().enabled = true;
                    break;
                }
            case (gameStates.PLAYR):
                {
                    //disable play1 movement and control scripts
                    PlayerL.GetComponent<PlayerMovement>().enabled = false;
                    PlayerR.GetComponent<PlayerMovement>().enabled = true;
                    break;
                }
        }
	}

    public void SwitchPlayer()
    {
        if (currentTurn == gameStates.PLAYL)
        {
            currentTurn = gameStates.PLAYR;
        } else if (currentTurn == gameStates.PLAYR)
            {
                currentTurn = gameStates.PLAYL;
            }
    }
}
