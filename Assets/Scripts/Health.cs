using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public GameObject HPBar;
    public GameObject TurnManager;
    Animator anim;

    /// <summary>
    /// Set the current health to max health when initializing. Gets animator component.
    /// </summary>
    void Start ()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }
	
	/// <summary>
    /// If health hits 0, call the GameOver function to terminate the game session.
    /// </summary>
	void Update ()
    {
        if (currentHealth <=0)
        {
            TurnManager.GetComponent<TurnManager>().GameOver();
        }
	}

    /// <summary>
    /// This way of writing allows the damage inflicted to be called from other scripts, and allows the damage value to be passed through the call.
    /// </summary>
    /// <param name="dmg"></param>
    public void takeDamage(float dmg)
    {
        currentHealth -= dmg;
        updateHPbar();
        anim.Play("Death");
        anim.SetInteger("State", 3);
        Invoke("resetAnim", 0.4f);
    }

    /// <summary>
    /// This updates the HP bar to match the current HP.
    /// </summary>
    void updateHPbar()
    {
        float hp = currentHealth / maxHealth;
        if (hp >= 0)
            HPBar.transform.localScale = new Vector3(hp, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
    }

    /// <summary>
    /// This allows the invoke function to reset the animation on the player so it does not loop.
    /// </summary>
    public void resetAnim()
    {
        anim.SetInteger("State", 0);
    } 
}