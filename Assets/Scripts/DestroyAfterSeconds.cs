/*
* Copyright (c) 2017 LoadScene
* Loadscene@gmail.com
*/

using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
	[SerializeField] private float time;
	private void Start()
	{
		Destroy(this.gameObject, time);
	}
}