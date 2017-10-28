/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(collision.gameObject);
		if (collision.gameObject.tag == "Ball")
		{
			LevelManager.ReloadCurrent();
		}
	}
}