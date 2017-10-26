/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Paddle : MonoBehaviour
{
	public bool autoPlay;

	private void Update()
	{
		if (!autoPlay)
		{
			float mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

			mousePos = Mathf.Clamp(mousePos, -5.65f, 5.65f);
			//todo add math to get the correct clamp size based on the size of the paddle
			transform.position = new Vector3(mousePos, transform.position.y, 0f);
		}
	}

	//todo onball collision compare ball position to paddle position and add a force to ball
}