using UnityEngine;
using System.Collections;

public class SidewaysMovement : MonoBehaviour {
	[SerializeField]
	private float speed;
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody.velocity = Vector3.right * speed;
	}
}
