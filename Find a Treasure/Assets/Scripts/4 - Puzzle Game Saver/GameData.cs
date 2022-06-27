using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class GameData {

	private bool[] treasurePuzzleLevels;
	private bool[] gemstonePuzzleLevels;
	private bool[] letterPuzzleLevels;

	private int[] treasurePuzzleLevelStars;
	private int[] gemstonePuzzleLevelStars;
	private int[] letterPuzzleLevelStars;

	private bool isGameStartedForTheFirstTime;

	private float musicVolume;

	public void SetTreasurePuzzleLevels(bool[] treasurePuzzleLevels) {
		this.treasurePuzzleLevels = treasurePuzzleLevels;
	}
	
	public bool[] GetTreasurePuzzleLevels() {
		return this.treasurePuzzleLevels;
	}
	
	public void SetGemstonePuzzleLevels(bool[] gemstonePuzzleLevels) {
		this.gemstonePuzzleLevels = gemstonePuzzleLevels;
	}
	
	public bool[] GetGemstonePuzzleLevels() {
		return this.gemstonePuzzleLevels;
	}
	
	public void SetLetterPuzzleLevels(bool[] letterPuzzleLevels) {
		this.letterPuzzleLevels = letterPuzzleLevels;
	}
	
	public bool[] GetLetterPuzzleLevels() {
		return this.letterPuzzleLevels;
	}
	
	public void SetTreasurePuzzleLevelStars(int[] treasurePuzzleLevelStars) {
		this.treasurePuzzleLevelStars = treasurePuzzleLevelStars;
	}
	
	public int[] GetTreasurePuzzleLevelStars() {
		return this.treasurePuzzleLevelStars;
	}
	
	public void SetGemstonePuzzleLevelStars(int[] gemstonePuzzleLevelStars) {
		this.gemstonePuzzleLevelStars = gemstonePuzzleLevelStars;
	}
	
	public int[] GetGemstonePuzzleLevelStars() {
		return this.gemstonePuzzleLevelStars;
	}
	
	public void SetLetterPuzzleLevelStars(int[] letterPuzzleLevelStars) {
		this.letterPuzzleLevelStars = letterPuzzleLevelStars;
	}
	
	public int[] GetLetterPuzzleLevelStars() {
		return this.letterPuzzleLevelStars;
	}
	
	public void SetIsGameStartedForTheFirstTime(bool isGameStartedForTheFirstTime) {
		this.isGameStartedForTheFirstTime = isGameStartedForTheFirstTime;
	}
	
	public bool GetIsGameStartedForTheFirstTime() {
		return this.isGameStartedForTheFirstTime;
	}
	
	public void SetMusicVolume(float musicVolume) {
		this.musicVolume = musicVolume;
	}
	
	public float GetMusicVolume() {
		return this.musicVolume;
	}



} // GameData
