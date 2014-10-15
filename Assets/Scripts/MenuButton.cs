//(C) copyright Dominic Curry 15/10/2014
using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {
	
	private bool hovering = false;
	[SerializeField]
	private float hoverColor = 0.3f;
	[SerializeField]
	private float idleColor = 0.4f;
	[SerializeField]
	private float transferTime = 0.2f;
	private float currentTime = 0f;
	public float color;
	
	void Start(){
		currentTime = transferTime + 1f;
		gameObject.renderer.material.color = new Color(idleColor,idleColor,idleColor);
	}
	void Update(){
		if(currentTime <= transferTime){
			currentTime += Time.deltaTime;
			if(hovering){
				color = Mathf.Lerp (idleColor,hoverColor,currentTime/transferTime);
			}
			else{
				color = Mathf.Lerp (hoverColor,idleColor,currentTime/transferTime);
			}
			gameObject.renderer.material.color = new Color(color,color,color);
		}
	}
	public void IsHovering(bool state){
		if(hovering != state){
			if(state){
				Hovering();
			}
			else{
				Idling();
			}
		}
	}
	private void Hovering(){
		if(!hovering){currentTime = Mathf.Lerp(0f,transferTime,1f - Mathf.Abs(hoverColor - color)/(idleColor-hoverColor));}
		hovering = true;
	}
	
	private void Idling(){
		if(hovering){currentTime = Mathf.Lerp(0f,transferTime,1f - Mathf.Abs(idleColor - color)/(idleColor-hoverColor));}
		hovering = false;
	}
	
	public void Clicked(int buttonClicked){
		Application.LoadLevel("Game");
	}
}
