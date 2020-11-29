using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino
{
	private Transform transform;
	private TetrominoItem[] tetrominoItems;
	private IInput inputManager;

	Tetromino(Transform _transform, IInput _input, TetrominoVariant variant)
	{
		transform = _transform;
		inputManager = _input;
		tetrominoItems = new TetrominoItem[variant.tetrominoItemPositions.Length];

		for(int i = 0; i < tetrominoItems.Length; i++)
		{
			tetrominoItems[i] = new TetrominoItem();
			tetrominoItems[i].spriteRenderer.sprite = variant.sprite;
			tetrominoItems[i].transform = new Transform();
		}
	}
}
