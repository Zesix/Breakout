/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class CameraController : MonoBehaviour
{
	private Vector3 defaultPos;
	private bool shakeScreen;
	[SerializeField] private float shakeDuration;
	[SerializeField] private float shakeAmount;
	private float currentDuration;

	private void Start()
	{
		defaultPos = transform.position;
	}

	private void Update()
	{
		if (shakeScreen)
		{
			currentDuration -= Time.deltaTime;

			transform.position = new Vector3(Random.Range(-shakeAmount, shakeAmount), Random.Range(-shakeAmount, shakeAmount), defaultPos.z);
			if (currentDuration <= 0f)
			{
				shakeScreen = false;
				transform.position = defaultPos;
			}
		}
	}

	public void ShakeScreen(float shakeForce)
	{
		if (shakeScreen == true && shakeAmount < shakeForce)
			shakeAmount = shakeForce;
		else if (shakeScreen == false)
			shakeAmount = shakeForce;

		shakeScreen = true;
		currentDuration = shakeDuration;
	}
}