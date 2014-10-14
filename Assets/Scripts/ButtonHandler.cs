using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonHandler : MonoBehaviour {
	
	[SerializeField]
	private List<GameObject> buttons = new List<GameObject>();
	[SerializeField]
	private int hoveredButton = 0;
	private int temp = 0;
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		temp = 0;
		if(Physics.Raycast(Camera.main.ScreenPointToRay (Input.mousePosition),out hit)){
			foreach(GameObject button in buttons){
				temp++;
				if(button == hit.collider.gameObject){
					hoveredButton = temp;
					button.GetComponent<MenuButton>().IsHovering(true);
				}
				else{
					button.GetComponent<MenuButton>().IsHovering(false);
				}
			}
		}
		else{
			hoveredButton = temp;
			foreach(GameObject button in buttons){
				button.GetComponent<MenuButton>().IsHovering(false);
			}
		}
		if(Input.GetMouseButtonDown (0)){
			buttons[hoveredButton-1].GetComponent<MenuButton>().Clicked(hoveredButton);
		}
	}
}
