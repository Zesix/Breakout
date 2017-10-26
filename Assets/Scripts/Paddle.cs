/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class Paddle : MonoBehaviour
{
	private void Update()
	{
		float mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

		mousePos = Mathf.Clamp(mousePos, -5.65f, 5.65f);
		transform.position = new Vector3(mousePos, transform.position.y, 0f);
	}
}