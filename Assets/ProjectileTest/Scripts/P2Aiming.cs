using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Aiming : MonoBehaviour
{

    Transform rotatePoint;
    public float rotationSpeed = 50f;
    public float minAngle = 90f;
    public float maxAngle = 220f;

    // Use this for initialization
    void Start()
    {
        rotatePoint = transform.Find("SpellRotation");
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeapon(Input.GetAxis("Vertical"));
    }

    void RotateWeapon(float axis)
    {
        float rotation = rotatePoint.rotation.eulerAngles.z;

        var rotationTarget = Mathf.Clamp(rotation - axis, minAngle, maxAngle);

        rotation = Mathf.MoveTowardsAngle(rotation, rotationTarget, Time.deltaTime * rotationSpeed);

        rotatePoint.rotation = Quaternion.Euler(-1.993f, 180.169f, rotation);

    }
}
