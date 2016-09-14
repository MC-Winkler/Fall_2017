using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	private float screenBottom = -20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y <= screenBottom) {
			Destroy (this.gameObject);
		}
	}
}
