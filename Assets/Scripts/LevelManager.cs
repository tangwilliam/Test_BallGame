using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject pauseMenu;

	private void Start()
	{
		pauseMenu.SetActive (false);
	}

	public void ToMenu()
	{
		Debug.Log ("Go To Main Menu");

        UnityEngine.SceneManagement.SceneManager.LoadScene("InitScene");
	}

	public void TogglePauseMenu()
	{
		pauseMenu.SetActive (!pauseMenu.activeSelf);
	}
		

}
