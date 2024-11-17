using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void openTetris()
	{
		SceneManager.LoadScene("Tetra");
	}	
	
	public void openPentis()
	{
		SceneManager.LoadScene("Penta");

	}

	public void openHexis()
	{
		SceneManager.LoadScene("Hexa");

	}

	public void openHeptis()
	{
		SceneManager.LoadScene("Hepta");

	}	
	
	public void openMenu()
	{
		SceneManager.LoadScene("Main");

	}

	public void Exit()
	{
		Application.Quit();
	}
}
