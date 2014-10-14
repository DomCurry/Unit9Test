using UnityEngine;
using System.Collections;

public class VerticalMovement: MonoBehaviour {

	[SerializeField]
	private float force = 3f;

	private bool movementAllowed = true;
	// Update is called once per frame
	void FixedUpdate () {
		if(movementAllowed && Input.GetKey(KeyCode.Space)){
			rigidbody.AddForce(Vector3.up * force);
		}
	}
	public void PlayerDeath(){
		movementAllowed = false;
	}
}
