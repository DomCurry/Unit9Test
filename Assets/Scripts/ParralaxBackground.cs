using UnityEngine;
using System.Collections;

public class ParralaxBackground : MonoBehaviour {

	[SerializeField]
	private PlayerScript playerCheck;
	[SerializeField]
	private float backgroundSpeed = -0.0001f;
	private Material background;
	void Start(){
		background = GetComponent<MeshRenderer>().materials[0];
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(!playerCheck.isDead){// don't move the background if the player isn't moving
			Vector2 temp = background.mainTextureOffset;
			temp.x = (backgroundSpeed + temp.x)%1f;
			background.mainTextureOffset = temp;
		}
	}
}
