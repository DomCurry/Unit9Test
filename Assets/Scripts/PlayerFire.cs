using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerFire : MonoBehaviour {

	[SerializeField]
	private Transform bullet;
	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private LayerMask targetMask;
	private bool targetAquired;
	private bool targetVisible;
	private Vector3 targetPosition;
	private List<Vector3> targetPositions = new List<Vector3>();
	[SerializeField]
	private float chargeTime;
	private float currentTime;
	[SerializeField]
	private LineRenderer laser;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(targetAquired){
			currentTime += Time.deltaTime;
			laser.SetPosition(0, transform.position);
			laser.SetPosition(1, targetPosition);
			laser.material.color = new Color(1f, Mathf.Lerp(0f,1f,currentTime/chargeTime),Mathf.Lerp(0f,1f,currentTime/chargeTime),1f);
			if(currentTime >= chargeTime){
				Fire ();
			}
		}
		else{
			laser.SetPosition(0, transform.position);
			laser.SetPosition(1, transform.position);
		}

		//find all possible targets
		targetVisible = false;
		if(targetPositions.Count > 0 && transform.position.x > targetPositions[0].x){
			targetPositions.RemoveAt(0);
		}
		foreach(Vector3 targetPos in targetPositions){
			//find nearest visible target

			RaycastHit visibilityCheck;
			if(Physics.Raycast(transform.position, targetPos - (transform.position), out visibilityCheck)){
				if(visibilityCheck.collider.gameObject.tag == "Turret" || visibilityCheck.collider.gameObject.tag == "Bullet"){
					if(targetAquired){
						if(targetPosition == targetPos){ //same target
							targetVisible = true;
						}
						else if( Vector3.Distance(transform.position, targetPosition) >= Vector3.Distance (transform.position, targetPos)){ //closer target
							AimAt(targetPos);
							targetVisible = true;
						}
					}
					else{ //new target
						AimAt(targetPos);
						currentTime = 0f;

						targetVisible = true;
					}
				}
			}
		}
		targetAquired = targetVisible;
	}
	void AimAt(Vector3 target){
		targetPosition = target;
		laser.SetPosition(0, transform.position);
		laser.SetPosition(1, target);
	}
	void Fire(){
		currentTime -= chargeTime;
	}

	public void AddTarget(Vector3 inPosition){//add to the queue of targets
		targetPositions.Add(inPosition);
	}
}
