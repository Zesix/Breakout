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

	public static void ReloadCurrent()
	{
		int levelToLoad = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(levelToLoad);
		gameState = GameState.Ready;
		Block.blockCount = 0;
	}

	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
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

	//!bug local scale
	//opt add a moving obsticle
	//opt add lives system
	//opt add more levels
	//opt add particle effects when hiting something
	//opt add pause screen with options and a slider to set volume of music and SFX
	//opt add reload level button
	//opt count only breakable blocks
	//opt create blocktype unbreakable/breakable
	//opt dont restart song on reloading same level
	//opt maybe add a logfile that records velocity of ball id of block hit id of block destroyed
	//opt more than one ball
	//opt particle fx equals block color
	//opt restart system
	//opt shakescreen on hit - higher shake on hit blocks
	//opt whena  block is destroyed add a rigidbody for block deactivate collision and slowly increase opacity and let block fall
	//todo when the ball collides with the paddle, check the diference pos between the center of both and add force vector
	//todo fix ball movement in pad
}