/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] private AudioClip hit;
	[SerializeField] private int maxHp = 1;
	private static int blockCount;
	// todo count only breakable blocks
	private int currentHp;

	private void OnLevelWasLoaded(int level)
	{
		blockCount = 0;
	}

	private void Start()
	{
		blockCount++;
		print(blockCount);
		currentHp = maxHp;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		currentHp--;
		if (currentHp <= 0)
		{
			blockCount--;
			if (blockCount <= 0)
			{
				print("YOU WIN");
			}

			Destroy(gameObject);
			//todo whena  block is destroyed add a rigidbody for block deactivate collision and slowly increase opacity and let block fall
		}
		//todo add points
		//todo feedback player when hit
		//todo maybe add a logfile that records velocity of ball id of block hit id of block destroyed
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		AudioSource.PlayClipAtPoint(hit, transform.position, 1f);
	}
}