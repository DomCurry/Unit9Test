//(C) copyright Dominic Curry 15/10/2014
using UnityEngine;
using System.Collections;

public class TurretFire : MonoBehaviour {

	[SerializeField]
	private Transform bullet;
	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private Transform gunPosition;
	[SerializeField]
	private float rateOfFire;
	private float currentTime;
	// Update is called once per frame
	void FixedUpdate () {
		currentTime += Time.fixedDeltaTime;
		if(currentTime >= rateOfFire){
			currentTime -= rateOfFire;
			Fire ();
		}
	}
	void Fire(){
		if(gunPosition != null){
			Transform bulletTransform = Instantiate(bullet, gunPosition.position, Quaternion.identity) as Transform;
			bulletTransform.gameObject.rigidbody.velocity = Vector3.left * bulletSpeed;
		}
	}
}
