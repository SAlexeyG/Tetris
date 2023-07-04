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
	private List<GameObject> tetrominoObjects = new List<GameObject>();

	public TetrominoSpawner(Vector3 _spawnPoint, GameObject[] _tetrominoVariants, IInput _inputManager)
	{
		spawnPoint = _spawnPoint;
		tetrominoVariants = _tetrominoVariants;
		inputManager = _inputManager;
	}

	public GameObject Create()
	{
		var randomTerominoVariant = tetrominoVariants[Random.Range(0, tetrominoVariants.Length)];
		var obj = GameObject.Instantiate(randomTerominoVariant,
					spawnPoint,
					Quaternion.identity);
		tetrominoObjects.Add(obj);
		return obj;
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

		var objectsToRemove = tetrominoObjects.Where(o => o.transform.childCount == 0);

		foreach (var obj in objectsToRemove)
			Delete(obj);

		tetrominoObjects.RemoveAll(o => o.transform.childCount == 0);
	}
}
