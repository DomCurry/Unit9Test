//(C) copyright Dominic Curry 15/10/2014
using UnityEngine;
using System.Collections;

public class DestroyOnTouch : MonoBehaviour {

	void OnTriggerEnter(Collider other){//destroys anyting it touches after 2 seconds
		if(other.gameObject.tag == "Base"){
			Destroy (other.gameObject.transform.parent.gameObject,2f);
		}
		else if (other.gameObject.tag == "Bullet"){
			Destroy (other.gameObject,2f);
		}
	}
}
