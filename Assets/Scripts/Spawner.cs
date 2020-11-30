using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner
{
	private Vector3 spawnPoint;
	private GameObject[] tetrominoVariants;
	private IInput inputManager;
	private List<Tetromino> tetrominos = new List<Tetromino>();

	public Spawner(Vector3 _spawnPoint, GameObject[] _tetrominoVariants, IInput _inputManager)
	{
		spawnPoint = _spawnPoint;
		tetrominoVariants = _tetrominoVariants;
		inputManager = _inputManager;
	}

	public void NewTetrominoForField(TetrisBlock tetrisBlock)
	{
		var obj = GameObject.Instantiate(tetrominoVariants[Random.Range(0, tetrominoVariants.Length)],
					spawnPoint,
					Quaternion.identity);
		tetrominos.Add(new Tetromino(obj.transform, inputManager, tetrisBlock));
	}

	public void DeleteTetromino(Tetromino tetromino)
	{
		tetrominos.Remove(tetromino);
	}
}
