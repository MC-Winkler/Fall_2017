using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        //GameObject collidedWith = coll.gameObject;
        //if (collidedWith.tag == "Ball")
        //{
        //    Destroy(this);
        //}
        //score++;
        //GameObject scoreObject = GameObject.Find("Score");
        //GUIText scoreGT = scoreObject.GetComponent<GUIText>();
        //scoreGT.text = "Score: " + score;
    }
}
