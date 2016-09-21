using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    private static int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        Destroy(this.gameObject);
        score++;
        GameObject scoreObject = GameObject.Find("Score");
        GUIText scoreGT = scoreObject.GetComponent<GUIText>();
        scoreGT.text = "Score: " + score;
    }
}
