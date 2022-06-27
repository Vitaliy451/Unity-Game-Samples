using UnityEngine;
using System.Collections;

public class LevelLocker : MonoBehaviour {

	[SerializeField]
	private PuzzleGameSaver puzzleGameSaver;

	[SerializeField]
	private StarsLocker starsLocker;
	
	[SerializeField]
	private GameObject[] levelStarsHolders;
	
	[SerializeField]
	private GameObject[] levelsPadlocks;
	
	private bool[] treasurePuzzleLevels;
	private bool[] gemstonePuzzleLevels;
	private bool[] letterPuzzleLevels;

	void Awake() {
		DeactivatePadlocksAndStarHolders ();
	}
	
	void Start () {
		GetLevels ();
	}

	public void CheckWhichLevelsAreUnlocked(string selectedPuzzle) {

		DeactivatePadlocksAndStarHolders ();
		GetLevels ();

		switch (selectedPuzzle) {

		case "Treasure Puzzle":

			for(int i = 0; i < treasurePuzzleLevels.Length; i++) {
				if(treasurePuzzleLevels[i]) {
					levelStarsHolders[i].SetActive(true);
					starsLocker.ActivateStars(i, selectedPuzzle);
				} else {
					levelsPadlocks[i].SetActive(true);
				}
			}

			break;

		case "Gemstone Puzzle":
			
			for(int i = 0; i < gemstonePuzzleLevels.Length; i++) {
				if(gemstonePuzzleLevels[i]) {
					levelStarsHolders[i].SetActive(true);
					starsLocker.ActivateStars(i, selectedPuzzle);
				} else {
					levelsPadlocks[i].SetActive(true);
				}
			}
			
			break;
			
		case "Letter Puzzle":
			
			for(int i = 0; i < letterPuzzleLevels.Length; i++) {
				if(letterPuzzleLevels[i]) {
					levelStarsHolders[i].SetActive(true);
					starsLocker.ActivateStars(i, selectedPuzzle);
				} else {
					levelsPadlocks[i].SetActive(true);
				}
			}
			
			break;

		
		}

	}

	void DeactivatePadlocksAndStarHolders() {
		for(int i = 0; i < levelStarsHolders.Length; i++) {
			levelStarsHolders[i].SetActive(false);
			levelsPadlocks[i].SetActive(false);
		}
	}

	void GetLevels() {
		treasurePuzzleLevels = puzzleGameSaver.treasurePuzzleLevels;
		gemstonePuzzleLevels = puzzleGameSaver.gemstonePuzzleLevels;
		letterPuzzleLevels = puzzleGameSaver.letterPuzzleLevels;
	}

	public bool[] GetPuzzleLevels(string selectedPuzzle) {

		switch (selectedPuzzle) {

		case "Treasure Puzzle":
			return this.treasurePuzzleLevels;
			break;

		case "Gemstone Puzzle":
			return this.gemstonePuzzleLevels;
			break;

		case "Letter Puzzle":
			return this.letterPuzzleLevels;
			break;

		default:
			return null;
			break;

		}

	}

} // LevelLocker


















































