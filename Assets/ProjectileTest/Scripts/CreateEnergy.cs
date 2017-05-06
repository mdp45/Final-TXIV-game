using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnergy : MonoBehaviour {

    public GameObject ball;
    public Transform firingPoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var energy = Instantiate(ball, firingPoint.position, Quaternion.identity);
            energy.transform.parent = transform.Find("SpellRotation");
        }

    }
}
