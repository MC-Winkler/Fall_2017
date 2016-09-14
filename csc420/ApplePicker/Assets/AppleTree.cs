using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	public GameObject applePrefab;
	public float speed = 12.4f;
	public float leftAndRightEdge = 16f;
	public float chanceToChangeDirections = .03f;
	public float secondsBetweenAppleDrops = 1.2f;

	private void DropApple() {
		GameObject appleObject = Instantiate (applePrefab) as GameObject;
		appleObject.transform.position = transform.position;
	}

	void FixedUpdate() {
		float directionCheck = Random.value;
		if (directionCheck < chanceToChangeDirections){
			speed = -speed;
		}
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("DropApple", 2f, secondsBetweenAppleDrops);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		if (pos.x >= leftAndRightEdge) {
			speed = -Mathf.Abs(speed);
		}
		if (pos.x <= -leftAndRightEdge) {
			speed = Mathf.Abs (speed);
		}
	}
}
