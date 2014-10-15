using UnityEngine;
using System.Collections;

public class VerticalMovement: MonoBehaviour {

	[SerializeField]
	private float force = 3f;
	[SerializeField]
	private GameObject particles;

	private bool movementAllowed = true;
	// Update is called once per frame
	void FixedUpdate () {
		if(movementAllowed && Input.GetKey(KeyCode.Space)){
			particles.particleEmitter.emit = true;
			rigidbody.AddForce(Vector3.up * force);
		}
		else{
			particles.particleEmitter.emit = false;
		}
	}
	public void PlayerDeath(){
		movementAllowed = false;
	}
}
