using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public InputManager inputManager;
	public GameObject[] Tetrominos;

	private void Start()
	{
		NewTetromino();
	}

	public void NewTetromino()
	{
		var obj = Instantiate(Tetrominos[Random.Range(0, Tetrominos.Length)],
					transform.position,
					Quaternion.identity);
		obj.GetComponent<TetrisBlock>().inputManager = inputManager;
	}
}
