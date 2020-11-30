using System;
using UnityEngine;

public class TetrisBlock
{
	private int height = 20;
	private int width = 10;

	private Spawner spawner; 
	private Transform[,] grid;

	public TetrisBlock(Spawner _spawner)
	{
		spawner = _spawner;
		grid = new Transform[width, height];
		spawner.NewTetrominoForField(this);
	}

	private void CheckForLines()
	{
		for (int i = height - 1; i >= 0; i--)
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
		for (int i = lineIndex; i < height; i++)
		{
			for (int j = 0; j < width; j++)
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
		for (int i = 0; i < width; i++)
		{
			GameObject.Destroy(grid[i, lineIndex].gameObject);
			grid[i, lineIndex] = null;
		}
	}

	private bool HasLine(int lineIndex)
	{
		for (int i = 0; i < width; i++)
		{
			if (grid[i, lineIndex] == null)
			{
				return false;
			}
		}

		return true;
	}

	private void AddToGrid(Tetromino tetromino)
	{
		foreach (Transform children in tetromino.Transform)
		{
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			grid[roundedX, roundedY] = children;
		}
	}

	public bool ValidateMove(Tetromino tetromino)
	{
		foreach (Transform children in tetromino.Transform)
		{
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
				return false;

			if (grid[roundedX, roundedY] != null)
				return false;
		}

		return true;
	}

	public void DestructTetromino(Tetromino tetromino)
	{
		AddToGrid(tetromino);
		spawner.DeleteTetromino(tetromino);
		CheckForLines();
		spawner.NewTetrominoForField(this);
	}
}
