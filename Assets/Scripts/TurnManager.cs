using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

    public GameObject PlayerL;
    public GameObject PlayerR;
    public Text turnPrompt;

    private enum gameStates
    {
        PLAYL,
        TRANSITTOR,
        PLAYR,
        TRANSITTOL,
        GAMEOVER
    }

    private gameStates currentState;

    void Start()
    {
        turnPrompt.text = "Player 1 Starts!";
        currentState = gameStates.TRANSITTOL;
    }

    /*
    private gameStates currentState
    {
        get
        {
            return currentState;
        }
        set
        {
            switch (currentState)
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
    }
    */

	// Update is called once per frame
	void Update ()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case (gameStates.PLAYL):
                {
                    //enable play1 movement and control scripts
                    PlayerL.GetComponent<PlayerMovement>().enabled = true;
                    PlayerL.GetComponent<Aiming>().enabled = true;
                    break;
                }
            case (gameStates.TRANSITTOR):
                {
                    PlayerL.GetComponent<PlayerMovement>().enabled = false;
                    PlayerL.GetComponent<Aiming>().enabled = false;
                    currentState = gameStates.PLAYR;
                    break;
                }
            case (gameStates.PLAYR):
                {
                    //enable play2 movement and control scripts
                    PlayerR.GetComponent<PlayerMovement>().enabled = true;
                    PlayerR.GetComponent<P2Aiming>().enabled = true;
                    break;
                }
            case (gameStates.TRANSITTOL):
                {                    
                    PlayerR.GetComponent<PlayerMovement>().enabled = false;
                    PlayerR.GetComponent<P2Aiming>().enabled = false;
                    currentState = gameStates.PLAYL;
                    break;
                }
            case (gameStates.GAMEOVER):
                {
                    //disable play2 movement and control scripts
                    PlayerR.GetComponent<PlayerMovement>().enabled = false;
                    PlayerL.GetComponent<PlayerMovement>().enabled = false;
                    PlayerL.GetComponent<Aiming>().enabled = false;
                    PlayerR.GetComponent<P2Aiming>().enabled = false;
                    turnPrompt.text = "Game Over!";
                    break;
                }
        }
	}

    public void SwitchPlayer()
    {
        if (currentState == gameStates.PLAYL)
        {
            SwitchToPlayer2();
        } else if (currentState == gameStates.PLAYR)
            {
                SwitchToPlayer1();
            }
    }

    public void SwitchToPlayer1()
    {
        if (currentState == gameStates.PLAYR)
        {
            turnPrompt.text = "Player 1's Turn!";
            currentState = gameStates.TRANSITTOL;
        }
    }
    public void SwitchToPlayer2()
    {
        if (currentState == gameStates.PLAYL)
        {
            turnPrompt.text = "Player 2's Turn!";
            currentState = gameStates.TRANSITTOR;
        }
    }
}
