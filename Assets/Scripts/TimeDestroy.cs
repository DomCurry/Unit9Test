using UnityEngine;
using System.Collections;

public class TimeDestroy : MonoBehaviour {
	[SerializeField]
	private float timeUntilDestroy;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, timeUntilDestroy);
	}

}
