using System;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
	public IInput inputManager;
	public static int height = 20;
	public static int widht = 10;

	private static Transform[,] grid = new Transform[widht, height];

	private void Start()
	{
		inputManager.OnLeft += () => Move(Vector3.left);
		inputManager.OnRight += () => Move(Vector3.right);
		inputManager.OnUp += Rotate;
		inputManager.OnDown += Fall;
	}

	private void OnDisable()
	{
		inputManager.OnLeft -= () => Move(Vector3.left);
		inputManager.OnRight -= () => Move(Vector3.right);
		inputManager.OnUp -= Rotate;
		inputManager.OnDown -= Fall;
	}

	private void Rotate()
	{
		transform.Rotate(Vector3.forward, -90f);
		if (!ValidMove())
			transform.Rotate(Vector3.forward, 90f);
	}

	private void Fall()
	{
		transform.position += Vector3.down;
		if (!ValidMove())
		{
			transform.position += Vector3.up;
			AddToGrid();
			CheckForLines();
			enabled = false;
			FindObjectOfType<Spawner>().NewTetromino();
		}
	}

	private void Move(Vector3 direction)
	{
		transform.position += direction;
		if (!ValidMove())
			transform.position -= direction;
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
			for (int j = 0; j < widht; j++)
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
		for (int i = 0; i < widht; i++)
		{
			Destroy(grid[i, lineIndex].gameObject);
			grid[i, lineIndex] = null;
		}
	}

	private bool HasLine(int lineIndex)
	{
		for (int i = 0; i < widht; i++)
		{
			if (grid[i, lineIndex] == null)
			{
				return false;
			}
		}

		return true;
	}

	private void AddToGrid()
	{
		foreach (Transform children in transform)
		{
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			grid[roundedX, roundedY] = children;
		}
	}

	private bool ValidMove()
	{
		foreach (Transform children in transform)
		{
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			if (roundedX < 0 || roundedX >= widht || roundedY < 0 || roundedY >= height)
			{
				return false;
			}

			if (grid[roundedX, roundedY] != null)
			{
				return false;
			}
		}

		return true;
	}
}
