using UnityEngine;
using System.Collections;

public class ExplodeOnContact : MonoBehaviour {

	[SerializeField]
	private GameObject particleSystem;

	void OnCollisionEnter(Collision collision){
		particleSystem.SetActive (true);
		particleSystem.transform.parent = null;
		Destroy (gameObject);
	}
}
