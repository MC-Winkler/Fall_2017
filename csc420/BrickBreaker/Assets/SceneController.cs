using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    public GameObject brickPrefab;
    private int numBricks;

    // Use this for initialization
    void Start () {
        GameObject scoreObject = GameObject.Find("Score");
        GUIText scoreGT = scoreObject.GetComponent<GUIText>();
        scoreGT.text = "Score: " + 0;

        GameObject livesObject = GameObject.Find("Lives");
        GUIText livesGT = livesObject.GetComponent<GUIText>();
        livesGT.text = "Lives: " + 3;

        InstantiateBricks(7, 3);
    }
	
	// Update is called once per frame
	void Update () {
	    if (numBricks == 0)
        {
            GameObject theBall = GameObject.Find("Ball");
            Destroy(theBall);
            GameObject gameOverNotification = GameObject.Find("GameOverNotification");
            GUIText goGT = gameOverNotification.GetComponent<GUIText>();
            goGT.text = "You Win!";

            GameObject livesObject = GameObject.Find("Lives");
            GUIText livesGT = livesObject.GetComponent<GUIText>();
            livesGT.text = "";
        }
	}

    public void InstantiateBricks(int cols, int rows)
    {
        numBricks = cols * rows;
        int leftbound = -cols * 2;
        int upperbound = rows * 4;
        for (int i=0; i<cols; i++)
        {
            for (int j=0; j<rows; j++)
                
            {
                GameObject brick = Instantiate(brickPrefab) as GameObject;
                Vector3 pos = Vector3.zero;
                pos.y += upperbound - j * 2;
                pos.x += leftbound + i * 4;
                brick.transform.position = pos;
            }
        }
    }

    public void BreakBrick()
    {
        Debug.Log("breaking break");
        numBricks--;
        Debug.Log("numbricks = " + numBricks);
    }
}
