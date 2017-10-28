/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public enum GameState { Ready, Started, Paused }

	public static GameState gameState;
	private bool paused;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			ReloadCurrent();
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (paused)
			{
				Time.timeScale = 1;
				paused = !paused;
			}
			else
			{
				Time.timeScale = 0;
				paused = !paused;
			}
		}
	}

	public static void ReloadCurrent()
	{
		int levelToLoad = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(levelToLoad);
		gameState = GameState.Ready;
		Block.blockCount = 0;
	}

	public void LoadLevel(string levelName)
	{
		//todo fix to string levelname
		SceneManager.LoadScene(1);
		gameState = GameState.Ready;
	}

	public static void LoadNextLevel()
	{
		int levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
		SceneManager.LoadScene(levelToLoad);
		gameState = GameState.Ready;
		Block.blockCount = 0;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}

//opt add a moving obsticle
//opt pause screen with options and a slider to set volume of music and SFX
//opt dont restart song on reloading same level
//opt more than one ball
//opt when a block is destroyed add a rigidbody for block deactivate collision and slowly increase opacity and let block fall
//opt add shot from the paddle
//opt Space Invaders + Breakout