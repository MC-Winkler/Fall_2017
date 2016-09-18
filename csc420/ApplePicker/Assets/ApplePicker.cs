using UnityEngine;
using System.Collections;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
    [SerializeField] private AppleTree appleTree;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
    private float screenBottom = -20f;
    private ArrayList baskets;

    // Use this for initialization
    void Start () {
        baskets = new ArrayList();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
            baskets.Add(tBasketGO);
		}
	}
	
	// Update is called once per frame
	void Update () {
        AppleDropped();
	}

    public void AppleDropped()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples)
        {
            if (apple.gameObject.transform.position.y <= screenBottom)
            {
                Destroy(apple);
                Destroy((GameObject) baskets[0]);
                baskets.RemoveAt(0);
            }
            if (baskets.Count == 0)
            {
                GameObject gameOverMessage = GameObject.Find("GameOverMessage");
                GUIText gameOverGT = gameOverMessage.GetComponent<GUIText>();
                gameOverGT.text = "Game Over";
                appleTree.EndGame();
            }
        }
    }
}
