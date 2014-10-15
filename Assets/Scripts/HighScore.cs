//(C) copyright Dominic Curry 15/10/2014
using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<TextMesh>().text = "Your highscore is: " + PlayerPrefs.GetFloat ("PlayerScore").ToString("f1");
	}
}
