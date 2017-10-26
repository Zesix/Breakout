/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] private float launchForce = 1f;
	[SerializeField] private float randomFactor = 0.5f;

	private AudioSource audioSource;
	private Rigidbody2D rb2D;

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
				rb2D.velocity = Vector2.up * launchForce;
				LevelManager.gameState = LevelManager.GameState.Started;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		audioSource.Play();
		rb2D.velocity += Vector2.one * Random.Range(-randomFactor, randomFactor);
	}
}