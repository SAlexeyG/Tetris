using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino
{
	private Transform transform;
	private IInput inputManager;
	private TetrisBlock tetrisBlock;

	public Transform Transform { get => transform; }

	public Tetromino(Transform _transform, IInput _input, TetrisBlock _tetrisBlock)
	{
		transform = _transform;
		inputManager = _input;
		tetrisBlock = _tetrisBlock;

		inputManager.OnLeft += () => Move(Vector3.left);
		inputManager.OnRight += () => Move(Vector3.right);
		inputManager.OnUp += Rotate;
		inputManager.OnDown += Fall;
	}

	private void Rotate()
	{
		transform.Rotate(Vector3.forward, -90f);
		if (!tetrisBlock.ValidateMove(this))
			transform.Rotate(Vector3.forward, 90f);
	}

	private void Fall()
	{
		transform.position += Vector3.down;
		if (!tetrisBlock.ValidateMove(this))
		{
			transform.position += Vector3.up;
			tetrisBlock.DestructTetromino(this);
		}
	}

	private void Move(Vector3 direction)
	{
		transform.position += direction;
		if (!tetrisBlock.ValidateMove(this))
			transform.position -= direction;
	}
}
