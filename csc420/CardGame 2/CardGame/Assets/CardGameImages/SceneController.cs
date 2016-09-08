using UnityEngine;
using System.Collections;
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

	private void CreateCardPair(int i, int j){
		Card card;
		if (i == 0 && j == 0) {
			card = originalCard;
		} else {
			card = Instantiate (originalCard) as Card;
		}
		card.SetCard (ids [pairs [counter]], images [pairs [counter]]);
		float posX = (offsetX * i) + startPosition.x;
		float posY = -(offsetY * j) + startPosition.y;
		card.transform.position = new Vector3 (posX, posY, startPosition.z);
		counter++;
	}

	// Use this for initialization
	void Start () {
		int[] pairs = { 0, 0, 1, 1, 2, 2, 3, 3 };
		int counter = 0;
		Vector3 startPosition = originalCard.transform.position;
		for (int i = 0; i < gridcols; i++) {
			for (int j = 0; j < gridrows; j++) {
				if (currentBoardLayout[i,j] = false{
					CreateCardPair(i,j);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
