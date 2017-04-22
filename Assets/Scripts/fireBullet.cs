using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour {

	public float bulletForce = 750.0f;

	void OnTriggerEnter2d (Collider2D target) {

		if (target.gameObject.tag == "FirePoint") GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);
	}
}
