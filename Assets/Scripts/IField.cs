using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IField
{
	bool ValidatePosition(Tetromino tetromino);
	void AddToGrid(Tetromino tetromino);
}
