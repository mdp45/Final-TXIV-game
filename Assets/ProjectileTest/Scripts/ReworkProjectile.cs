using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReworkProjectile : MonoBehaviour {

	public GameObject RocketLauncher;

	public Collider2D DrawArea;

	public GameObject MinStr;

	public GameObject MaxStr;

	public GameObject Rocket;

	public float MaxRotationAngleRadians = 0.6f;

	public float FireSpeed = 80.0f;


	private GameObject currentArrow;
	private float startAngle;



    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

	}
}
