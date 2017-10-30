/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Block : MonoBehaviour
{
	private CameraController _camera;
	[SerializeField] private AudioClip _audioClip = new AudioClip();
	[SerializeField] private float _shrinkAmount = .5f;
	[SerializeField] private int _hitResistance = 1;
	[SerializeField] private GameObject _explosion;
	[SerializeField] private GameObject _deathExplosion;
	[SerializeField] private float _shakeHit = 0.5f;
	[SerializeField] private float _shakeExplo = 1f;

	private enum BlockType { Breakable }

	[SerializeField] private BlockType _blockType;

	private int _hitCount;

	public static int BlockCount;

	private void Start()
	{
		_camera = FindObjectOfType<CameraController>();
		_hitCount = 0;

		if (_blockType == BlockType.Breakable)
		{
			BlockCount++;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		Instantiate(_explosion, transform.position, Quaternion.identity);
		_camera.ShakeScreen(_shakeHit);
		if (_blockType == BlockType.Breakable)
		{
			_hitCount++;

			transform.localScale = transform.localScale * (1f - _shrinkAmount);

			AudioSource.PlayClipAtPoint(_audioClip, transform.position, 1f);

			if (_hitCount >= _hitResistance)
			{
				BlockCount--;

				if (BlockCount <= 0)
				{
					LevelManager.LoadNextLevel();
				}
				_camera.ShakeScreen(_shakeExplo);
				Instantiate(_deathExplosion, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}
	}
}