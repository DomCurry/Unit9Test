using UnityEngine;
using System.Collections;

public class BoundaryGenerator : MonoBehaviour {

	[SerializeField]
	private Vector3 ceilingOffset;
	[SerializeField]
	private Vector3 floorOffset;
	[SerializeField]
	private Transform ceiling;
	[SerializeField]
	private Transform floor;
	[SerializeField]
	private Transform turret;

	[SerializeField]
	private PlayerFire aimScript;
	private int turretCooldown;
	void OnTriggerExit(Collider other){ //determine when and which prefab to spawn
		if(other.gameObject.tag == "Base"){
			turretCooldown--;
			if(other.gameObject.transform.parent.gameObject.tag == "CeilingSegment"){
				SpawnCeiling(transform.position + ceilingOffset);
			}
			else if(other.gameObject.transform.parent.gameObject.tag == "FloorSegment"){
				SpawnFloor(transform.position + floorOffset);
			}

			if(Random.Range(0,10) == 0 && turretCooldown < 0){
				SpawnTurret (transform.position + new Vector3(0,Random.Range(-3,3),0));
			}
		}
	}
	void SpawnCeiling(Vector3 pos){
		Instantiate(ceiling, pos, Quaternion.identity);
	}
	void SpawnFloor(Vector3 pos){
		Instantiate(floor, pos, Quaternion.identity);
	}
	void SpawnTurret(Vector3 pos){
		turretCooldown += 4;
		Transform target = Instantiate(turret,pos,Quaternion.identity) as Transform;
		aimScript.AddTarget(target.FindChild("Turret").transform.position);
	}
}
