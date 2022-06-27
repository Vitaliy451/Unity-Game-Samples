using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PuzzleGameSaver : MonoBehaviour {

	private GameData gameData;
	
	public bool[] treasurePuzzleLevels;
	public bool[] gemstonePuzzleLevels;
	public bool[] letterPuzzleLevels;
	
	public int[] treasurePuzzleLevelStars;
	public int[] gemstonePuzzleLevelStars;
	public int[] letterPuzzleLevelStars;
	
	private bool isGameStartedForTheFirstTime;
	
	public float musicVolume;

	void Awake() {
		InitializeGame ();
	}

	void InitializeGame() {

		LoadGameData ();

		if (gameData != null) {
			isGameStartedForTheFirstTime = gameData.GetIsGameStartedForTheFirstTime ();
		} else {
			isGameStartedForTheFirstTime = true;
		}

		if (isGameStartedForTheFirstTime) {

			isGameStartedForTheFirstTime = false;

			musicVolume = 0;

			treasurePuzzleLevels = new bool[5];
			gemstonePuzzleLevels = new bool[5];
			letterPuzzleLevels = new bool[5];

			treasurePuzzleLevels[0] = true;
			gemstonePuzzleLevels[0] = true;
			letterPuzzleLevels[0] = true;

			for(int i = 1; i < treasurePuzzleLevels.Length; i++) {
				treasurePuzzleLevels[i] = false;
				gemstonePuzzleLevels[i] = false;
				letterPuzzleLevels[i] = false;
			}

			treasurePuzzleLevelStars = new int[5];
			gemstonePuzzleLevelStars = new int[5];
			letterPuzzleLevelStars = new int[5];

			for(int i = 0; i < treasurePuzzleLevelStars.Length; i++) {
				treasurePuzzleLevelStars[i] = 0;
				gemstonePuzzleLevelStars[i] = 0;
				letterPuzzleLevelStars[i] = 0;
			}

			gameData = new GameData();

			gameData.SetTreasurePuzzleLevels (treasurePuzzleLevels);
			gameData.SetGemstonePuzzleLevels (gemstonePuzzleLevels);
			gameData.SetLetterPuzzleLevels (letterPuzzleLevels);
			
			gameData.SetTreasurePuzzleLevelStars(treasurePuzzleLevelStars);
			gameData.SetGemstonePuzzleLevelStars(gemstonePuzzleLevelStars);
			gameData.SetLetterPuzzleLevelStars(letterPuzzleLevelStars);
			
			gameData.SetIsGameStartedForTheFirstTime (isGameStartedForTheFirstTime);
			gameData.SetMusicVolume (musicVolume);

			SaveGameData();
			LoadGameData();


		}

	}

	public void SaveGameData() {
		FileStream file = null;

		try {
				
			BinaryFormatter bf = new BinaryFormatter();

			file = File.Create(Application.persistentDataPath + "/GameData.dat");

			if(gameData != null) {

				gameData.SetTreasurePuzzleLevels (treasurePuzzleLevels);
				gameData.SetGemstonePuzzleLevels (gemstonePuzzleLevels);
				gameData.SetLetterPuzzleLevels (letterPuzzleLevels);
				
				gameData.SetTreasurePuzzleLevelStars (treasurePuzzleLevelStars);
				gameData.SetGemstonePuzzleLevelStars (gemstonePuzzleLevelStars);
				gameData.SetLetterPuzzleLevelStars (letterPuzzleLevelStars);
				
				gameData.SetIsGameStartedForTheFirstTime (isGameStartedForTheFirstTime);
				gameData.SetMusicVolume (musicVolume);

				bf.Serialize(file, gameData);

			}

		} catch(Exception e) {
		
		} finally {
			if(file != null) {
				file.Close();
			}
		}
	}

	void LoadGameData() {
		FileStream file = null;

		try {

			BinaryFormatter bf = new BinaryFormatter();

			file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);

			gameData = (GameData)bf.Deserialize(file);

			if(gameData != null) {

				treasurePuzzleLevels = gameData.GetTreasurePuzzleLevels();
				gemstonePuzzleLevels = gameData.GetGemstonePuzzleLevels();
				letterPuzzleLevels = gameData.GetLetterPuzzleLevels();
				
				treasurePuzzleLevelStars = gameData.GetTreasurePuzzleLevelStars();
				gemstonePuzzleLevelStars = gameData.GetGemstonePuzzleLevelStars();
				letterPuzzleLevelStars = gameData.GetLetterPuzzleLevelStars();
				
				musicVolume = gameData.GetMusicVolume();


			}

		} catch(Exception e) {
		
		} finally {
			if(file != null) {
				file.Close();
			}
		}

	}
	
	public void Save(int level, string selectedPuzzle, int stars) {

		int unlockNextLevel = -1;

		switch (selectedPuzzle) {
		
		case "Treasure Puzzle":

			unlockNextLevel = level + 1;

			treasurePuzzleLevelStars[level] = stars;

			if(unlockNextLevel < treasurePuzzleLevels.Length) {
					treasurePuzzleLevels[unlockNextLevel] = true;
			}

			break;

		case "Gemstone Puzzle":
			
			unlockNextLevel = level + 1;
			
			gemstonePuzzleLevelStars[level] = stars;
			
			if(unlockNextLevel < gemstonePuzzleLevels.Length) {
				gemstonePuzzleLevels[unlockNextLevel] = true;
			}
			
			break;
			
		case "Letter Puzzle":
			
			unlockNextLevel = level + 1;
			letterPuzzleLevelStars[level] = stars;
			
			if(unlockNextLevel < letterPuzzleLevels.Length) {
					letterPuzzleLevels[unlockNextLevel] = true;
			}
			
			break;

			
		}

	}




} // PuzzleGameSaver















































