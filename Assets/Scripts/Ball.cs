/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Ball : MonoBehaviour
{
	private AudioSource audioSource;
	private Rigidbody2D rb2D;
	[SerializeField] private float speed = 1f;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
		transform.parent = FindObjectOfType<Paddle>().transform;
		rb2D.isKinematic = true;
	}

	private void Update()
	{
		if (LevelManager.gameState == LevelManager.GameState.Ready)
		{
			if (Input.GetMouseButtonDown(0))
			{
				rb2D.isKinematic = false;
				transform.parent = null;
				rb2D.velocity = Vector2.up * speed;
				LevelManager.gameState = LevelManager.GameState.Started;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		audioSource.Play();
		rb2D.velocity = rb2D.velocity.normalized * speed;
		if (collision.gameObject.tag == "Paddle")
		{
			rb2D.velocity += Vector2.up * 4;
		}
	}
}