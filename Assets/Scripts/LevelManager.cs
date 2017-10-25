/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}