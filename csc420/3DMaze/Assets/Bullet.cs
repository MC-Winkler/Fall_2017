using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bullet : MonoBehaviour
{

    private float velocity = 5f;
    private static int lives = 3;
    // Use this for initialization
    void Start()
    {
        GameObject livesObject = GameObject.Find("Lives");
        Text lives = livesObject.GetComponent<Text>();
        lives.text = "Lives: " + Bullet.lives;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += transform.forward * velocity * Time.deltaTime;
        transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (Bullet.lives > 0)
            {
                Bullet.lives--;
                GameObject livesObject = GameObject.Find("Lives");
                Text lives = livesObject.GetComponent<Text>();
                lives.text = "Lives: " + Bullet.lives;
            }

            if (Bullet.lives == 0)
            {
                GameObject player = GameObject.Find("Player");
                player.GetComponent<FPSInput>().enabled = false;

                GameObject gameOver = GameObject.Find("GameOverText");
                Text gameOverText = gameOver.GetComponent<Text>();
                gameOverText.text = "Game Over";

                GameObject mouseCursor = GameObject.Find("MouseCursor");
                Text mouseCursorIcon = mouseCursor.GetComponent<Text>();
                mouseCursorIcon.text = "";
            }
        }
        Destroy(this.gameObject);
    }
}
