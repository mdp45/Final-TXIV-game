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
        InvokeRepeating("takeDamage", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void takeDamage()
    {
        currentHealth -= 4f;
        updateHPbar();
    }

    void updateHPbar()
    {
        float hp = currentHealth / maxHealth;
        if (hp >= 0)
            HPBar.transform.localScale = new Vector3(hp, HPBar.transform.localScale.y, HPBar.transform.localScale.z);
    }
}