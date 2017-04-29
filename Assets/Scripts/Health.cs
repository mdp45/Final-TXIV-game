using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public GameObject HPBar;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void takeDamage(float dmg)
    {
        currentHealth -= dmg;
        updateHPbar();
    }

    void updateHPbar()
    {
        float hp = currentHealth / maxHealth;
        if (hp >= 0)
            HPBar.transform.localScale = new Vector3(hp, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
    }
}