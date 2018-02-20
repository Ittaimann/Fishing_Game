using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManger : MonoBehaviour {

	// Use this for initializatio
	public Canvas controls;
	public Canvas start;
	
	public void beginGame()
	{
		//SceneManager.LoadScene("Whatever The Scene will be called");
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void controlsMenu()
	{
		controls.enabled=true;
		start.enabled=false;

	}

	
}