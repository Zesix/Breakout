/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Ball : MonoBehaviour
{
	private Rigidbody2D rb2D;
	[SerializeField] private float launchForce;
	[SerializeField] private Paddle paddle;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		transform.parent = paddle.gameObject.transform;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			transform.parent = null;
			rb2D.velocity = Vector2.up * launchForce;
		}
	}
}