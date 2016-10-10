using UnityEngine;
using System.Collections;

public class CyberSolider : MonoBehaviour {

    private float secondsBetweenShots = 1.5f;
    private GameObject player;
	// Use this for initialization
	void Start () {
        InvokeRepeating("ShootBullet", 2.5f, secondsBetweenShots);
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);
	}

    void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(Resources.Load("GiantBulletPrefab")) as GameObject;
        Vector3 pos = transform.position;
        pos.y += 2;
        bullet.transform.position = pos;
        bullet.transform.LookAt(player.transform);
        Vector3 pos2 = bullet.transform.position;
        pos2 += transform.forward * 1;
        bullet.transform.position = pos2;
    }
}
