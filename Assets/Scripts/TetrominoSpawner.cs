using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TetrominoSpawner : ITetrominoSpawner
{
	private Vector3 spawnPoint;
	private GameObject[] tetrominoVariants;
	private IInput inputManager;
	private List<Tetromino> tetrominos = new List<Tetromino>();

	public TetrominoSpawner(Vector3 _spawnPoint, GameObject[] _tetrominoVariants, IInput _inputManager)
	{
		spawnPoint = _spawnPoint;
		tetrominoVariants = _tetrominoVariants;
		inputManager = _inputManager;
	}

	public GameObject Create()
	{
		var randomTerominoVariant = tetrominoVariants[Random.Range(0, tetrominoVariants.Length)];
		return GameObject.Instantiate(randomTerominoVariant,
					spawnPoint,
					Quaternion.identity);
	}

	public void CreateTetrominoForField(IField field)
	{
		var obj = Create();
		tetrominos.Add(new Tetromino(obj.transform, inputManager, field));
	}

	public void Delete(GameObject gameObject)
	{
		GameObject.Destroy(gameObject);
	}

	public void DisableTetromino(Tetromino tetromino)
	{
		tetromino.IsMoving = false;
		tetrominos.Remove(tetromino);
	}
}
