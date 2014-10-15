using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {

	void Start(){
		Physics.IgnoreLayerCollision ( LayerMask.NameToLayer ("Bullet"),LayerMask.NameToLayer ("Bullet"));
	}

	void OnCollisionEnter(Collision collision){
		if(GetParent(collision.contacts[0].otherCollider.gameObject).tag == "Turret"){
			DestroyTurret(collision.contacts[0].otherCollider.gameObject);
		}
	}

	GameObject GetParent(GameObject child){//gets the highest parent recursively.
		if(child.transform.parent != null){
			return GetParent(child.transform.parent.gameObject); //should only be 2 or 3 iterations
		}
		else{
			return child;
		}
	}
	void DestroyTurret(GameObject turret){
		GetParent(turret).AddComponent("Gravity");
		GetParent(turret).rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
		Destroy(turret);
	}
}
