using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private VerticalMovement vertScript;
	private SidewaysMovement sideScript;

	[SerializeField]
	private GameObject deadText;
	[SerializeField]
	private GameObject restartText;
	[SerializeField]
	private GameObject spikeReason;
	[SerializeField]
	private GameObject bulletReason;
	[SerializeField]
	private GameObject turretReason;
	[SerializeField]
	private GameObject unknownReason;
	[SerializeField]
	private GameObject deathTextHandler;

	[SerializeField]
	private float textSpeed;

	public bool isDead = false;

	void Start(){
		vertScript = gameObject.GetComponent<VerticalMovement>();
		sideScript = gameObject.GetComponent<SidewaysMovement>();
	}
	void Update(){
		if(isDead){
			deathTextHandler.transform.localPosition = new Vector3(Mathf.Lerp(deathTextHandler.transform.localPosition.x, -7f,textSpeed),0f,0f);
			if(Input.GetKeyDown(KeyCode.Return)){
				Application.LoadLevel(0);
			}
		}
	}
	void OnCollisionEnter(Collision collision){
		DeathMessage (collision.contacts[0].otherCollider.tag);
		PlayerDeath();
	}
	void PlayerDeath(){
		vertScript.PlayerDeath();
		sideScript.PlayerDeath();
		isDead = true;

	}
	void DeathMessage(string otherTag){
		deadText.transform.parent = deathTextHandler.transform;
		restartText.transform.parent = deathTextHandler.transform;
		if(otherTag == "Spike" || otherTag == "Base"){
			spikeReason.transform.parent = deathTextHandler.transform;
		}
		else if(otherTag == "Bullet"){
			bulletReason.transform.parent = deathTextHandler.transform;
		}
		else if(otherTag == "Turret"){
			turretReason.transform.parent = deathTextHandler.transform;
		}
		else{
			unknownReason.transform.parent = deathTextHandler.transform;
		}
	}
}
