using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	[SerializeField] private GameObject targetObject;
	[SerializeField] private string message;

	public void OnMouseDown() {
		//transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);
	}

	public void OnMouseUp () {
		//transform.localScale = Vector3.one;
		if (targetObject != null) {
			targetObject.SendMessage (message);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
