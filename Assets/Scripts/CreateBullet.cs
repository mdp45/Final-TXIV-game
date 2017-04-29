using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{

    //Used for the projectile
    public Transform firingPoint;
    public GameObject bullet;
	public float speed = 20f;
    //public Rigidbody2D projectile;
    //public float testSpeed;


    // Use this for initialization
    void Start()
    {
        //bullet = Resources.Load("Projectile") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
		Debug.DrawRay(firingPoint.position, firingPoint.up);

        if (Input.GetKeyDown(KeyCode.Space))
        {
			GameObject newBullet = Instantiate(bullet, firingPoint.position, Quaternion.identity) as GameObject;


            newBullet.transform.position = firingPoint.position;
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
	
			rb.AddRelativeForce(transform.TransformDirection (new Vector2( (Mathf.Cos (transform.rotation.z * Mathf.Deg2Rad) * speed),
				(Mathf.Sin (transform.rotation.z * Mathf.Deg2Rad) * speed) )), ForceMode2D.Impulse);
        }
			
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
