using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
	public void LoadLevel (string name)
	{
		Debug.Log("Level load requested for " + name);
		Brick.brickCount = 0;
		SceneManager.LoadScene(name);
	}

	public void MainMenu (string start)
	{
		Debug.Log("Return to main menu requested");
		SceneManager.LoadScene(start);
	}

	public void QuitGame ()
	{
		Debug.Log("Game quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel ()
	{
		Brick.brickCount = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void BrickDestroyed ()
	{
		if(Brick.brickCount <= 0)
		{
			LoadNextLevel();
		}
	}
} 