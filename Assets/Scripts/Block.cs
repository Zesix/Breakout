/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Block : MonoBehaviour
{
	private CameraController camera;
	[SerializeField] private AudioClip audioClip = new AudioClip();
	[SerializeField] private float shrinkAmount = .5f;
	[SerializeField] private int hitResistance = 1;
	[SerializeField] private GameObject explosion;
	[SerializeField] private GameObject deathExplosion;
	[SerializeField] private float deathExploForce = 5f;
	[SerializeField] private float shakeHit = 0.5f;
	[SerializeField] private float shakeExplo = 1f;

	private enum BlockType { breakable, unbreakable }

	[SerializeField] private BlockType blockType;

	private int hitCount;

	public static int blockCount;

	private void Start()
	{
		camera = FindObjectOfType<CameraController>();
		hitCount = 0;

		if (blockType == BlockType.breakable)
		{
			blockCount++;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		Instantiate(explosion, transform.position, Quaternion.identity);
		camera.ShakeScreen(shakeHit);
		if (blockType == BlockType.breakable)
		{
			hitCount++;

			transform.localScale = transform.localScale * (1f - shrinkAmount);

			AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);

			if (hitCount >= hitResistance)
			{
				blockCount--;

				if (blockCount <= 0)
				{
					LevelManager.LoadNextLevel();
				}
				camera.ShakeScreen(shakeExplo);
				Instantiate(deathExplosion, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}
	}
}