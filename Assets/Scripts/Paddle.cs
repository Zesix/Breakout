/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField] private bool autoPlay = false;
	[SerializeField] private float clampedPos = 1f;
	private Ball ball;

	private void Start()
	{
		ball = FindObjectOfType<Ball>();
	}

	private void Update()
	{
		//if (Input.GetKeyDown(KeyCode.P))
		//	autoPlay = !autoPlay;

		float xPos = new float();

		if (autoPlay)
		{
			xPos = ball.transform.position.x;
		}
		else
		{
			xPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		}

		float newX = Mathf.Clamp(xPos, -clampedPos, clampedPos);
		transform.position = new Vector2(newX, transform.position.y);
	}
}