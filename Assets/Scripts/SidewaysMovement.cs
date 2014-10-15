//(C) copyright Dominic Curry 15/10/2014
using UnityEngine;
using System.Collections;

public class SidewaysMovement : MonoBehaviour {
	[SerializeField]
	private float speed;
	// Update is called once per frame
	void Start () {
		rigidbody.velocity = Vector3.right * speed;

	}
	public void PlayerDeath(){
		rigidbody.velocity = Vector3.zero;
	}
}