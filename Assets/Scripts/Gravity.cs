using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	[SerializeField]
	private float gravity = 20f;
	bool isOn = true;
	void FixedUpdate () {
		if(isOn){
			rigidbody.AddForce(gravity * Vector3.down);
		}
	}
	public float GetGravityForce(){
		return gravity;
	}
	public void Off(){
		isOn = false;
	}
	public void On(){
		isOn = true;
	}
}
