using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private VerticalMovement vertScript;
	private SidewaysMovement sideScript;

	void Start(){
		vertScript = gameObject.GetComponent<VerticalMovement>();
		sideScript = gameObject.GetComponent<SidewaysMovement>();
	}

	void OnCollisionEnter(Collision collision){
		PlayerDeath();
	}
	void PlayerDeath(){
		vertScript.PlayerDeath();
		sideScript.PlayerDeath();
	}
}
