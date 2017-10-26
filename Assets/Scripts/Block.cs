/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] private AudioClip audioClip = new AudioClip();
	[SerializeField] private float shrinkAmount = .5f;
	[SerializeField] private int hitResistance = 1;
	private int hitCount;

	public static int blockCount;

	private void Start()
	{
		hitCount = 0;
		blockCount++;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		hitCount++;

		transform.localScale = Vector3.one * (1f - shrinkAmount);

		AudioSource.PlayClipAtPoint(audioClip, transform.position);

		if (hitCount >= hitResistance)
		{
			blockCount--;

			if (blockCount <= 0)
			{
				LevelManager.LoadNextLevel();
			}

			Destroy(gameObject);
		}
	}
}