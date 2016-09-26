using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    
    private int numBricks;
    private ArrayList theBricks;
    private GameObject theBall;
    private int lives;
    private int level = 1;
    private bool movingToNewLevel = false;

    [SerializeField] private GameObject thePaddle;

    public GameObject ballPrefab;
    public GameObject brickPrefab;

    // Use this for initialization
    void Start () {
        lives = 3;

        thePaddle.transform.localScale = new Vector3(6 - (level*1.5f), 1, 1);

        theBricks = new ArrayList();
        InstantiateBricks(7, 3);
        theBall = Instantiate(ballPrefab) as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject levelObject = GameObject.Find("Level");
        GUIText levelGT = levelObject.GetComponent<GUIText>();
        levelGT.text = "Level: " + level;

        GameObject livesObject = GameObject.Find("Lives");
        GUIText livesGT = livesObject.GetComponent<GUIText>();
        livesGT.text = "Lives: " + lives;

        if (theBricks.Count == 0)
        {
            if (level < 3)
            {
                level++;
                movingToNewLevel = true;
                Restart();
            } else
            {
                Destroy(theBall);
                GameObject gameOverNotification = GameObject.Find("GameOverNotification");
                GUIText goGT = gameOverNotification.GetComponent<GUIText>();
                goGT.text = "You Win!";
                livesGT.text = "";
            }

        }
        if (theBall.transform.position.y <= -16f)
        {
            lives--;
            Destroy(theBall);
            if (lives > 0)
            {
                theBall = Instantiate(ballPrefab) as GameObject;
            }
            else
            {
                livesGT.text = "";
                GameObject gameOverNotification = GameObject.Find("GameOverNotification");
                GUIText goGT = gameOverNotification.GetComponent<GUIText>();
                goGT.text = "Game Over";
            }
        }
	}

    public void InstantiateBricks(int cols, int rows)
    {
       
        numBricks = cols * rows;
        int leftbound = -cols * 2;
        int upperbound = rows * 4;
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject brick = Instantiate(brickPrefab) as GameObject;
                Vector3 pos = Vector3.zero;
                pos.y += upperbound - j * 2;
                pos.x += leftbound + i * 4;
                brick.transform.position = pos;
                theBricks.Add(brick);
            }
        }
    }

    public void Restart()
    {
        GameObject gameOverNotification = GameObject.Find("GameOverNotification");
        GUIText goGT = gameOverNotification.GetComponent<GUIText>();
        goGT.text = "";

        while(theBricks.Count>0)
        {
            Destroy((GameObject) theBricks[0]);
            theBricks.RemoveAt(0);
        }

        Destroy(theBall);
        if (movingToNewLevel)
        {
            movingToNewLevel = false;
        } else
        {
            level = 1;
        }
        Start();
    }

    public void BreakBrick (Brick brick)
    { 
        theBricks.Remove(brick.gameObject);
    }
}
