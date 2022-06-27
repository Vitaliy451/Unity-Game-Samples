using UnityEngine;
using System.Collections;

public class StarsLocker : MonoBehaviour {

	[SerializeField]
	private PuzzleGameSaver puzzleGameSaver;
	
	[SerializeField]
	private GameObject[] level1Stars, level2Stars, level3Stars, level4Stars, level5Stars;
	
	public int[] treasurePuzzleLevelStars;
	public int[] gemstonePuzzleLevelStars;
	public int[] letterPuzzleLevelStars;

	void Awake() {

	}

	void Start () {
	
	}

	public void ActivateStars(int level, string selectedPuzzle) {
		GetStars ();

		int stars;

		switch (selectedPuzzle) {
		
		case "Treasure Puzzle":

			stars = treasurePuzzleLevelStars[level];
			ActivateLevelStars(level, stars);

			break;

		case "Gemstone Puzzle":
			
			stars = gemstonePuzzleLevelStars[level];
			ActivateLevelStars(level, stars);
			
			break;
			
		case "Letter Puzzle":
			
			stars = letterPuzzleLevelStars[level];
			ActivateLevelStars(level, stars);
			
			break;
			
		}

	}

	void ActivateLevelStars(int level, int looper) {
		switch (level) {

		case 0:

			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level1Stars[i].SetActive(true);
				}
			}

			break;

		case 1:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level2Stars[i].SetActive(true);
				}
			}
			
			break;
			
		case 2:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level3Stars[i].SetActive(true);
				}
			}
			
			break;
			
		case 3:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level4Stars[i].SetActive(true);
				}
			}
			
			break;
			
		case 4:
			
			if(looper != 0) {
				for(int i = 0; i < looper; i++) {
					level5Stars[i].SetActive(true);
				}
			}
			
			break;

		}
	}

	public void DeactivateStars() {
		for(int i = 0; i < level1Stars.Length; i++) {
			level1Stars[i].SetActive(false);
			level2Stars[i].SetActive(false);
			level3Stars[i].SetActive(false);
			level4Stars[i].SetActive(false);
			level5Stars[i].SetActive(false);
		}
	}

	void GetStars() {
		treasurePuzzleLevelStars = puzzleGameSaver.treasurePuzzleLevelStars;
		gemstonePuzzleLevelStars = puzzleGameSaver.gemstonePuzzleLevelStars;
		letterPuzzleLevelStars = puzzleGameSaver.letterPuzzleLevelStars;
	}


} // StarsLocker























































