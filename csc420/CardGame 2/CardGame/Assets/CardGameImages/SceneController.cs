﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	//Using constants instead of magic strings :D
	private const int EASY = 0;
	private const int MEDIUM = 1;
	private const int HARD = 2;
	private static int difficulty;

	public static int gridrows = 2;
	public static int gridcols = 4;
	public static float offsetX = 2f;
	public static float offsetY = 2.5f;

	[SerializeField] private Card originalCard;
	[SerializeField] private Sprite[] images;
	[SerializeField] private string[] ids;

	private Card firstRevealed;
	private Card secondRevealed;
	private bool needToReset = false; 

	private int tries = 0;
	private int score = 0;
	private int pairsFound = 0;

	private static string highScoreText;
	[SerializeField] private TextMesh scoreLabel;
	[SerializeField] private TextMesh highScores;

	private static bool inMainScene = true;
	private static bool inHighScores = false;

	Vector3 startPosition;

	public void EasyRestart(){
		difficulty = EASY;
		inHighScores = false;
		inMainScene = true;
		SceneManager.LoadScene ("Scene");
	}

	public void MediumRestart(){
		difficulty = MEDIUM;
		SceneManager.LoadScene ("Scene");
	}

	public void HardRestart(){
		difficulty = HARD;
		SceneManager.LoadScene ("Scene");
	}

	public void HardRestart1(){
		SceneManager.LoadScene ("RuleBook");
	}

	public void ShowRules() {
		SceneManager.LoadScene ("RuleBook");
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
		/** Idea behind the scoring:
		 * Higher numbered cards are worth more than lower numbered cards, and face cards are worth
		 * more than numbered cards. Also, each time a player makes match, they earn points equal to
		 * the value of the cards they matched times a multiplier that decreases with each match attempt.
		 * The idea is that this motivates players to try and find and match higher-numbered cards first,
		 * but if they spend too many turns trying to find high-numbered/face cards, their multiplier will 
		 * decrease. Hopefully this creates an interesting choice for the player: make the match I know,
		 * or try and find a better one while possibly losing more points than I gain because I'll be
		 * reducing my multiplier?
		 */
		if (tries < 49) {
			tries++;
		}
		if (firstRevealed.Id == secondRevealed.Id) {
			/** If you match a pair on your first turn, its value is multiplied by 50,
			 * if you match one on your second turn by 49, third turn by 48, etc.
			 * Also, I found the Int32.Parse method at msdn.microsoft.com 
			 */
			int pointsEarned = Int32.Parse(firstRevealed.Id) * (50 - tries);
			score += pointsEarned;
			scoreLabel.text = "Score: " + score;
			pairsFound += 1;
			if (pairsFound == (gridcols * gridrows) / 2) {
				FinishGame ();
			}

			firstRevealed = null;
			secondRevealed = null;
		} else {
			needToReset = true;
		}

	}

	public void FinishGame() {

		if (score>= PlayerPrefs.GetInt("MichaelWinklerHighScore5",0)){
			int j = 5;
			//The second value passed to GetInt is the default value, looked it up in the Unity API
			while (score >= PlayerPrefs.GetInt("MichaelWinklerHighScore" + j, 0) && j > 1){
				PlayerPrefs.SetInt ("MichaelWinklerHighScore" + j, PlayerPrefs.GetInt ("MichaelWinklerHighScore" + (j - 1)));
				j--;
			}

			PlayerPrefs.SetInt ("MichaelWinklerHighScore" + j, score);
		}
			
		highScoreText = "High Scores: \n";
		for (int i = 1; i < 6; i++) {
			highScoreText += i + ": " + PlayerPrefs.GetInt ("MichaelWinklerHighScore" + i) + "\n";
		}

		inHighScores = true;
		inMainScene = false;
		SceneManager.LoadScene ("HighScores");
	}



	private void CreateCardPair(int i, int j, List<int[]> spacesStillFree, List<int> idsNotYetUsed, Card originalCard){

		/* I found the UnityEngine.Random method in the Unity API */
		int[] firstCardPos = spacesStillFree [UnityEngine.Random.Range (0, spacesStillFree.Count)];
		spacesStillFree.Remove (firstCardPos);
		int[] secondCardPos = spacesStillFree [UnityEngine.Random.Range (0, spacesStillFree.Count)];
		spacesStillFree.Remove (secondCardPos);

		int idAndImage = idsNotYetUsed[UnityEngine.Random.Range (0, idsNotYetUsed.Count)];
		idsNotYetUsed.Remove (idAndImage);

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


		if (inHighScores) {
			highScores.text = highScoreText;
		} else {
			highScores.text = "";
		}

		if (inMainScene) {
			scoreLabel.text = "Score: " + score;
		} else {
			scoreLabel.text = "";
		}

		if (difficulty == EASY) {
			gridrows = 2;
			gridcols = 4;
			offsetX = 2f;
			offsetY = 2.5f;
			originalCard.transform.localScale = new Vector3 (.275F, .275F, 1);
		} else if (difficulty == MEDIUM) {
			gridrows = 4;
			gridcols = 4;
			offsetX = 2f;
			offsetY = 1.25f;
			originalCard.transform.localScale = new Vector3 (.15F, .15F, 1);
		} else {
			gridrows = 4;
			gridcols = 7;
			offsetX = 1.25f;
			offsetY = 1.25f;
			originalCard.transform.localScale = new Vector3 (.1375F, .1375F, 1);
		}

		startPosition = originalCard.transform.position;
		List<int[]> spacesStillFree = new List<int[]> ();
		for (int i = 0; i < gridcols; i++) {
			for (int j = 0; j < gridrows; j++) {
				int[] currentSlot = new int[] { i, j };
				spacesStillFree.Add (currentSlot);
			}
		}

		/*Use this array to make sure that we don't get, for example, 3 pairs of twos on our board.
		That would make the game too easy.*/
		List<int> idsNotYetUsed = new List<int> ();
		for (int i = 0; i < ids.Length; i++) {
			idsNotYetUsed.Add(i);
		}

		for (int i = 0; i < gridcols; i++) {
			for (int j = 0; j < gridrows/2; j++) {
				CreateCardPair(i,j, spacesStillFree, idsNotYetUsed, originalCard);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
