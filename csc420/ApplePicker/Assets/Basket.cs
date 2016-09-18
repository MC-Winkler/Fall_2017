using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	private int score = 0;
	// Use this for initialization
	void Start () {
        GameObject scoreObject = GameObject.Find("Score");
        GUIText scoreGT = scoreObject.GetComponent<GUIText>();
        scoreGT.text = "Score: " + score;
    }
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}
		score++;
		GameObject scoreObject = GameObject.Find ("Score");
		GUIText scoreGT = scoreObject.GetComponent<GUIText> ();
		scoreGT.text = "Score: " + score; 
	}
}
