using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	[SerializeField] private GameObject cardBack;
	[SerializeField] private string id;
	[SerializeField] private SceneController controller;

	public string Id{
		get{ return id; } 
	}

	public void SetCard (string id, Sprite image) {
		this.id = id;
		GetComponent<SpriteRenderer>().sprite = image;
	}

	public void OnMouseDown(){
		controller.CardClicked (this);
	}

	public void Reveal(){
		Vector3 position = cardBack.transform.position;
		position.z = 1;
		cardBack.transform.position = position;
	}

	public void UnReveal() {
		Vector3 position = cardBack.transform.position;
		position.z = -1;
		cardBack.transform.position = position;
	}

	public bool IsFaceDown() {
		return (this.transform.position.z > cardBack.transform.position.z);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
