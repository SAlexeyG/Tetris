using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour, IInput
{
	[SerializeField] private float fallTime = default;

	[HideInInspector] public event Action OnLeft;
	[HideInInspector] public event Action OnRight;
	[HideInInspector] public event Action OnUp;
	[HideInInspector] public event Action OnDown;

	private float previousTime;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow)) OnLeft?.Invoke();
		if (Input.GetKeyDown(KeyCode.RightArrow)) OnRight?.Invoke();
		if (Input.GetKeyDown(KeyCode.UpArrow)) OnUp?.Invoke();

		if (Time.time - previousTime >
			(Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
		{
			OnDown?.Invoke();
			previousTime = Time.time;
		}
	}
}
