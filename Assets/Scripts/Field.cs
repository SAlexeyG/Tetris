using System;
using UnityEngine;

[Serializable]
public struct FieldSize
{
	public int height;
	public int width;
}

public class Field : IField
{
	private FieldSize fieldSize;
	private ITetrominoSpawner spawner;
	private Transform[,] grid;

	public Field(ITetrominoSpawner _spawner, FieldSize _fieldSize)
	{
		spawner = _spawner;
		fieldSize = _fieldSize;
		grid = new Transform[fieldSize.width, fieldSize.height];
		spawner.CreateTetrominoForField(this);
	}

	public void AddToGrid(Tetromino tetromino)
	{
		foreach (Transform children in tetromino.Transform)
		{
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			grid[roundedX, roundedY] = children;
		}

		spawner.DisableTetromino(tetromino);
		CheckForLines();
		spawner.CreateTetrominoForField(this);
	}

	public bool ValidatePosition(Tetromino tetromino)
	{
		foreach (Transform children in tetromino.Transform)
		{
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			if (roundedX < 0 || roundedX >= fieldSize.width || roundedY < 0 || roundedY >= fieldSize.height)
				return false;

			if (grid[roundedX, roundedY] != null)
				return false;
		}

		return true;
	}

	private void CheckForLines()
	{
		for (int i = fieldSize.height - 1; i >= 0; i--)
		{
			if (HasLine(i))
			{
				DeleteLine(i);
				RowDown(i);
			}
		}
	}

	private void RowDown(int lineIndex)
	{
		for (int i = lineIndex; i < fieldSize.height; i++)
		{
			for (int j = 0; j < fieldSize.width; j++)
			{
				if (grid[j, i] != null)
				{
					grid[j, i - 1] = grid[j, i];
					grid[j, i] = null;
					grid[j, i - 1].transform.position -= Vector3.up;
				}
			}
		}
	}

	private void DeleteLine(int lineIndex)
	{
		for (int i = 0; i < fieldSize.width; i++)
		{
			spawner.Delete(grid[i, lineIndex].gameObject);
			grid[i, lineIndex] = null;
		}
	}

	private bool HasLine(int lineIndex)
	{
		for (int i = 0; i < fieldSize.width; i++)
			if (grid[i, lineIndex] == null)
				return false;

		return true;
	}
}
