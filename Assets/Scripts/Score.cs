//(C) copyright Dominic Curry 15/10/2014
using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {


	[SerializeField]
	private Transform playerTransform;
	private TextMesh text;

	private float highscore = 0f;
	void Start(){
		text = gameObject.GetComponent<TextMesh>();
	}
	void Update () {
		if(playerTransform.position.y > highscore){
			highscore = playerTransform.position.y;
		}
		if(playerTransform.GetComponent<PlayerScript>().isDead){
			if(PlayerPrefs.GetFloat("PlayerScore") < highscore){
				PlayerPrefs.SetFloat("PlayerScore",highscore);
			}
		}
		text.text = "Score: " + highscore.ToString ("f1");
	}
}
