/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField] private bool _autoPlay;
	[SerializeField] private float _clampedPos = 1f;
	private Ball _ball;

	private float _xPos;
	
	private void Start()
	{
		_ball = FindObjectOfType<Ball>();
		_xPos = _ball.transform.position.x;
	}

	private void Update()
	{
		//if (Input.GetKeyDown(KeyCode.P))
		//	autoPlay = !autoPlay;

		if (!_autoPlay)
		{
			_xPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		}

		var newX = Mathf.Clamp(_xPos, -_clampedPos, _clampedPos);
		transform.position = new Vector2(newX, transform.position.y);
	}
}