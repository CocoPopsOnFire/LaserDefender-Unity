using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

	int score = 0;

	void Awake()
	{
		SetUpSingleton();
	}

	public int GetScore(){
		return score;
	}

	public void AddToScore(int scoreValue){
		score+=scoreValue;
	}

	public void ResetScore(){
		Destroy(gameObject);
	}

	private void SetUpSingleton()
	{
		int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
		if(numberOfGameSessions>1){
			Destroy(gameObject);
		}else{
			DontDestroyOnLoad(gameObject);
		}
	}
}
