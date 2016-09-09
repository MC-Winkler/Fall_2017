using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {


	public const int gridrows = 2;
	public const int gridcols = 4;
	public const float offsetX = 2f;
	public const float offsetY = 2.5f;

	[SerializeField] private Card originalCard;
	[SerializeField] private Sprite[] images;
	[SerializeField] private string[] ids;

	private Card firstRevealed;
	private Card secondRevealed;
	private bool needToReset = false; 

	private int score;
	[SerializeField] private TextMesh scoreLabel;

	Vector3 startPosition;

	public void Restart(){
		SceneManager.LoadScene ("Scene");
	}

	public void CardClicked (Card card){
		if (needToReset) {
			firstRevealed.UnReveal ();
			secondRevealed.UnReveal ();
			firstRevealed = null;
			secondRevealed = null;
			needToReset = false;
		} else if (firstRevealed == null && card.IsFaceDown ()) {
			card.Reveal ();
			firstRevealed = card;
		} else if (secondRevealed == null && card.IsFaceDown ()) {
			card.Reveal ();
			secondRevealed = card;
			CheckMatch ();
		}
	}

	public void CheckMatch(){
		if (firstRevealed.Id == secondRevealed.Id) {
			score++;
			scoreLabel.text = "Score: " + score;
			firstRevealed = null;
			secondRevealed = null;
		} else {
			needToReset = true;
		}

	}

	private void CreateCardPair(int i, int j, List<int[]> spacesStillFree, Card originalCard){
		Debug.Log ("i, j  =" + i + ", " + j);


		int[] firstCardPos = spacesStillFree [UnityEngine.Random.Range (0, spacesStillFree.Count)];
		spacesStillFree.Remove (firstCardPos);
		int[] secondCardPos = spacesStillFree [UnityEngine.Random.Range (0, spacesStillFree.Count)];
		spacesStillFree.Remove (secondCardPos);

		int idAndImage = UnityEngine.Random.Range (0, ids.Length);

		if ((firstCardPos [0] == 0 && firstCardPos [1] == 0)) {
			originalCard.SetCard(ids [idAndImage], images [idAndImage]);
		} else {
			Card card1 = Instantiate (originalCard) as Card;
			card1.SetCard (ids [idAndImage], images [idAndImage]);
			float card1X = (offsetX *firstCardPos[0]) + startPosition.x;
			float card1Y = -(offsetY * firstCardPos[1]) + startPosition.y;
			card1.transform.position = new Vector3 (card1X, card1Y, startPosition.z);
		}

		if ((secondCardPos [0] == 0 && secondCardPos [1] == 0)) {
			originalCard.SetCard (ids [idAndImage], images [idAndImage]);
		} else {
			Card card2 = Instantiate (originalCard) as Card;
			card2.SetCard (ids [idAndImage], images [idAndImage]);

			float card2X = (offsetX * secondCardPos [0]) + startPosition.x;
			float card2Y = -(offsetY * secondCardPos [1]) + startPosition.y;
			card2.transform.position = new Vector3 (card2X, card2Y, startPosition.z);
		}
	}

	// Use this for initialization
	void Start () {
		startPosition = originalCard.transform.position;
		List<int[]> spacesStillFree = new List<int[]> ();
		for (int i = 0; i < gridcols; i++) {
			for (int j = 0; j < gridrows; j++) {
				int[] currentSlot = new int[] { i, j };
				spacesStillFree.Add (currentSlot);
			}
		}
		for (int i = 0; i < gridcols/2; i++) {
			for (int j = 0; j < gridrows; j++) {
				CreateCardPair(i,j, spacesStillFree, originalCard);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
