/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Ball : MonoBehaviour
{
	private AudioSource _audioSource;
	private Rigidbody2D _rb2D;
	[SerializeField] private float _speed = 1f;

	private void Start()
	{
		_rb2D = GetComponent<Rigidbody2D>();
		_audioSource = GetComponent<AudioSource>();
		transform.parent = FindObjectOfType<Paddle>().transform;
		_rb2D.isKinematic = true;
	}

	private void Update()
	{
		if (LevelManager.GameState == LevelManager.State.Ready)
		{
			if (Input.GetMouseButtonDown(0))
			{
				_rb2D.isKinematic = false;
				transform.parent = null;
				_rb2D.velocity = Vector2.up * _speed;
				LevelManager.GameState = LevelManager.State.Started;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		_audioSource.Play();
		_rb2D.velocity = _rb2D.velocity.normalized * _speed;
		if (collision.gameObject.tag == "Paddle")
		{
			_rb2D.velocity += Vector2.up * 4;
		}
	}
}