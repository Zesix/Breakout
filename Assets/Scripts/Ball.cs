/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] private float randomizeForce = .2f;
	private Rigidbody2D rb2D;
	private AudioSource audioSource;
	[SerializeField] private float launchForce;
	[SerializeField] private Paddle paddle;
	private bool autoPlay;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
		transform.parent = paddle.gameObject.transform;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && transform.parent != null)
		{
			transform.parent = null;
			rb2D.velocity = new Vector2(Random.Range(-randomizeForce, randomizeForce), launchForce);
			autoPlay = true;
		}

		if (autoPlay)
		{
			paddle.autoPlay = true; ;
			paddle.gameObject.transform.position = new Vector2(transform.position.x, paddle.gameObject.transform.position.y);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// todo state game has started
		// todo autoplay to inspector
		// todo shakescreen on hit - higher shake on hit blocks

		if (autoPlay)
		{
			rb2D.velocity += Vector2.right * Random.Range(-randomizeForce, randomizeForce);
			audioSource.Play();
		}
	}
}