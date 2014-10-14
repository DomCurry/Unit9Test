using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private Vector3 cameraOffset;
	[SerializeField]
	private Transform playerTransform;
	private Vector3 pos;
	// Update is called once per frame
	void FixedUpdate () {
		pos.x = Mathf.Lerp(transform.position.x, playerTransform.position.x + cameraOffset.x, speed);
		pos.y = Mathf.Lerp(transform.position.y, playerTransform.position.y + cameraOffset.y, speed);
		pos.z = Mathf.Lerp(transform.position.z, playerTransform.position.z + cameraOffset.z, speed);

		transform.position = pos;
	}
}
