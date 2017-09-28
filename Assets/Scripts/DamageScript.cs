using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    public float damageAmount = 5f;
    public float selfDestructDelay;

    // Use this for initialization
    void Start () {
        Physics2D.IgnoreLayerCollision(8, 9);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// This function passes the value to the health script to call the takeDamage function on it. It checks if it hits the players before calling it.
    /// If it hits a player, it will inflict damage and self destruct.
    /// Otherwise, the projectile will self destruct after a delay.
    /// Ignoring layer collision 8 and 9 makes the projectile ignore the edge colliders.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("p1") || collision.gameObject.CompareTag("p2"))
        {
            collision.gameObject.GetComponent<Health>().takeDamage(damageAmount);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, selfDestructDelay);
        }
    }
}
