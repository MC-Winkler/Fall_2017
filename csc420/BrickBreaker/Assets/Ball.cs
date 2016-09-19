using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private float HorizontalEdgeDistance = 14f;
    private float VerticalEdgeDistance = 16f;
    private float[] initialx = {6f, 3f, -3f, -6f};
    private float xVelocity;
    private float yVelocity = -12f;
    [SerializeField] private Paddle thePaddle;

	// Use this for initialization
	void Start () {
        //Randomize the initial x direction
        int index = Random.Range(0, 4);
        xVelocity = initialx[index];
	}
	
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += xVelocity * Time.deltaTime;
        pos.y += yVelocity * Time.deltaTime;
        transform.position = pos;
        if (pos.x >= HorizontalEdgeDistance) {
            xVelocity = -Mathf.Abs(xVelocity);
        }
        if (pos.x <= -HorizontalEdgeDistance) {
            xVelocity = Mathf.Abs(xVelocity);    
        }
        if (pos.y <= -VerticalEdgeDistance)
        {
            yVelocity = Mathf.Abs(yVelocity);
        }
        if (pos.y >= VerticalEdgeDistance)
        {
            yVelocity = -Mathf.Abs(yVelocity);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        yVelocity = -yVelocity;
        if (collidedWith.tag == "Paddle")
        {
            xVelocity += (float) thePaddle.xVelocityApproximation*10;
        }
    }

}
