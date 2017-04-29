using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour {

    Transform gun;
    public float rotationSpeed = 50f;
    public float minAngle = 90f;
    public float maxAngle = 220f;

	// Use this for initialization
	void Start () {
        gun = transform.Find("RocketLauncher");
	}
	
	// Update is called once per frame
	void Update () {
        RotateWeapon(Input.GetAxis("Vertical"));
    }

    void RotateWeapon(float axis)
    {
        float rotation = gun.rotation.eulerAngles.z;

        var rotationTarget = Mathf.Clamp(rotation - axis, minAngle, maxAngle);

        rotation = Mathf.MoveTowardsAngle(rotation, rotationTarget, Time.deltaTime * rotationSpeed);

        gun.rotation = Quaternion.Euler(0f, 0f, rotation);

	}
}
