using UnityEngine;
using System.Collections;

namespace Tutorial {

	public class Worm : MonoBehaviour {

		Transform weapon;
		public float weaponRotationSpeed = 50f;
		public float weaponMinAngle = 90f;
		public float weaponMaxAngle = 220f;

		void Start(){
			weapon =  transform.Find ("Bazooka");
		}

		void Update(){
			RotateWeapon(Input.GetAxis("Vertical"));
		}

		void RotateWeapon(float axis){

			float rot = weapon.rotation.eulerAngles.z;

			var rotationTarget = Mathf.Clamp(rot - axis, weaponMinAngle, weaponMaxAngle);
			rot = Mathf.MoveTowardsAngle(rot, rotationTarget, Time.deltaTime * weaponRotationSpeed);

			weapon.rotation = Quaternion.Euler(0f,0f,rot);

		}
	}
}