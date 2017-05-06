using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FProjectile : MonoBehaviour {

    public float forceIncrement;
    public float projectileForce;
    public float maxForce;
    public Rigidbody2D projectile;
    public Transform firingPoint;
    public ForceMode2D forceMode;

	// Use this for initialization
	void Start () {
        projectileForce = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (Input.GetKey(KeyCode.Space))
        {
            projectileForce += forceIncrement;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (forceIncrement > maxForce)
            {
                projectileForce = maxForce;
            }
            //Vector3 relativePos = firingPoint.position - transform.position;
            //Quaternion rotation = Quaternion.LookRotation(relativePos);
            Rigidbody2D instance = Instantiate(projectile, firingPoint.position, Quaternion.identity) as Rigidbody2D;
            instance.AddForce(firingPoint.right * projectileForce, forceMode);
            projectileForce = 0f;
        }
    }
}
