using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    public float damageAmount = 5f;
    public GameObject TurnManager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("p1") || collision.gameObject.CompareTag("p2"))
        {
            collision.gameObject.GetComponent<Health>().takeDamage(damageAmount);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 0.2f);
        }
    }
}
