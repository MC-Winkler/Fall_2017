using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire3"))
        {
            SceneManager.LoadScene("scene1");
        }
        if (GameObject.FindGameObjectsWithTag("CyberSoldier").Length == 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        GameObject gameOver = GameObject.Find("GameOverText");
        Text gameOverText = gameOver.GetComponent<Text>();
        gameOverText.text = "You Win!";
    }
}
