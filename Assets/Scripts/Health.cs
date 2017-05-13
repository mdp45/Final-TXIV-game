using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public GameObject HPBar;
    Animator anim;

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void takeDamage(float dmg)
    {
        currentHealth -= dmg;
        updateHPbar();
        anim.SetInteger("State", 3);
        //anim.SetInteger("State", 0);
    }

    void updateHPbar()
    {
        float hp = currentHealth / maxHealth;
        if (hp >= 0)
            HPBar.transform.localScale = new Vector3(hp, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
    }
}