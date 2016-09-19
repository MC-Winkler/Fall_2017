using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject scoreObject = GameObject.Find("Score");
        GUIText scoreGT = scoreObject.GetComponent<GUIText>();
        scoreGT.text = "Score: " + 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void initialize
}
