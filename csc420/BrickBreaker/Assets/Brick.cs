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
        Destroy(this.gameObject);
        GameObject sceneController = GameObject.Find("SceneController");
        //Looked this line up on the Unity forums
        SceneController sc = (SceneController)sceneController.GetComponent(typeof(SceneController));
        sc.BreakBrick(this);
    }

}
