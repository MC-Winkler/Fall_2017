using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public float xVelocityApproximation = 0;
    private float lastFrameXPosition = 0;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

        //calculate approximate x velocity - change in x over one frame
        xVelocityApproximation = pos.x - lastFrameXPosition;
        lastFrameXPosition = pos.x;
    }

    void OnCollisionEnter(Collision coll)
    {

    }

}
