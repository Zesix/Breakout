/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public enum State { Ready, Started, Paused }

	public static State GameState;
	private bool _paused;

	private void Update()
	{
		if (Input.GetButtonDown("Reload"))
		{
			ReloadCurrent();
		}

		if (Input.GetButtonDown("Escape"))
		{
			if (_paused)
			{
				Time.timeScale = 1;
				_paused = !_paused;
			}
			else
			{
				Time.timeScale = 0;
				_paused = !_paused;
			}
		}
	}

	public static void ReloadCurrent()
	{
		var levelToLoad = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(levelToLoad);
		GameState = State.Ready;
		Block.BlockCount = 0;
	}

	public void LoadLevel(string levelName)
	{
		//todo fix to string levelname
		SceneManager.LoadScene(1);
		GameState = State.Ready;
	}

	public static void LoadNextLevel()
	{
		var levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
		SceneManager.LoadScene(levelToLoad);
		GameState = State.Ready;
		Block.BlockCount = 0;
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