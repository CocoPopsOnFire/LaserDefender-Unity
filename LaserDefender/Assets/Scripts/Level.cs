using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

	[SerializeField] float gameOverDelay = 2f;

	public void LoadStartMenu(){
		SceneManager.LoadScene("StartMenu");
	}

	public void LoadGame(){
		SceneManager.LoadScene("Game");
		FindObjectOfType<GameSession>().ResetScore();
	}

	public void LoadGameOver(){
		StartCoroutine(WaitAndLoad());
	}

	private IEnumerator WaitAndLoad(){
		yield return new WaitForSeconds(gameOverDelay);
		SceneManager.LoadScene("GameOver");
	}

	public void ExitGame(){
		Application.Quit();
	}

}
