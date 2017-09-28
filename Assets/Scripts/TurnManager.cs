using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

    public GameObject PlayerL;
    public GameObject PlayerR;
    public Text turnPrompt;

	[SerializeField]
	private GameObject gameOverUI;

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
                    EnableP1();
                    break;
                }
            case (gameStates.TRANSITTOR):
                {
                    DisableP1();
                    currentState = gameStates.PLAYR;
                    break;
                }
            case (gameStates.PLAYR):
                {
                    EnableP2();
                    break;
                }
            case (gameStates.TRANSITTOL):
                {
                    DisableP2();
                    currentState = gameStates.PLAYL;
                    break;
                }
            case (gameStates.GAMEOVER):
                {
                    GameOver();
                    break;
                }
        }
	}

    /// <summary>
    /// This function calls for switching player turns.
    /// </summary>
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

    /// <summary>
    /// This funtion switches only to player 1, used for testing purposes.
    /// </summary>
    public void SwitchToPlayer1()
    {
        if (currentState == gameStates.PLAYR)
        {
            turnPrompt.text = "Player 1's Turn!";
            currentState = gameStates.TRANSITTOL;
        }
    }

    /// <summary>
    /// This function switches only to player 2, used for testing purposes.
    /// </summary>
    public void SwitchToPlayer2()
    {
        if (currentState == gameStates.PLAYL)
        {
            turnPrompt.text = "Player 2's Turn!";
            currentState = gameStates.TRANSITTOR;
        }
    }

    /// <summary>
    /// This funtion enables the movement, aiming and projectile control scripts on player 1
    /// </summary>
    public void EnableP1()
    {
        //enable play1 movement and control scripts
        PlayerL.GetComponent<PlayerMovement>().enabled = true;
        PlayerL.GetComponent<FProjectile>().enabled = true;
        PlayerL.GetComponent<Aiming>().enabled = true;
    }

    /// <summary>
    /// This funtion disables the movement, aiming and projectile control scripts on player 1
    /// </summary>
    public void DisableP1()
    {
        PlayerL.GetComponent<PlayerMovement>().enabled = false;
        PlayerL.GetComponent<FProjectile>().enabled = false;
        PlayerL.GetComponent<Aiming>().enabled = false;
    }

    /// <summary>
    /// This funtion enables the movement, aiming and projectile control scripts on player 2
    /// </summary>
    public void EnableP2()
    {
        //enable play2 movement and control scripts
        PlayerR.GetComponent<PlayerMovement>().enabled = true;
        PlayerR.GetComponent<FProjectile>().enabled = true;
        PlayerR.GetComponent<P2Aiming>().enabled = true;
    }

    /// <summary>
    /// This funtion disables the movement, aiming and projectile control scripts on player 2
    /// </summary>
    public void DisableP2()
    {
        PlayerR.GetComponent<PlayerMovement>().enabled = false;
        PlayerR.GetComponent<FProjectile>().enabled = false;
        PlayerR.GetComponent<P2Aiming>().enabled = false;
    }

	public void EndGame()
	{
		Debug.Log("GAME OVER");
		gameOverUI.SetActive (true);

	}

    /// <summary>
    /// This function implements the Game Over events, it is called upon by the health script.
    /// </summary>
    public void GameOver()
    {
        DisableP1();
        DisableP2();
		EndGame ();
    }
}
