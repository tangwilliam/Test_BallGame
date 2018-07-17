using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float goldTime = 10.0f ;
    public float silverTime = 15.0f;

    public int goldPrize = 100;
    public int silverPrize = 50;
    public int winPrize = 10;

    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

	public GameObject pauseMenu;

    private float duration;
    private float startTime;

	private void Start()
	{
        instance = this;
		pauseMenu.SetActive (false);

        duration = 0;
        startTime = Time.time;
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

    public void Win()
    {
        Debug.Log("Win");
        
        duration = Time.time - startTime;

        if( duration < goldTime ){

            GameManager.Instance.Currency += goldPrize;
        }
        else if( duration < silverTime ){

            GameManager.Instance.Currency += silverPrize;
        }
        else{
            GameManager.Instance.Currency += winPrize;
        }

        GameManager.Instance.Save();

        Debug.Log("LevelManager Win() : Currency = " + GameManager.Instance.Currency);

        PlayerPrefs.SetString(SceneManager.GetActiveScene().name, duration + "&" + silverTime + "&" + goldTime);

        UnityEngine.SceneManagement.SceneManager.LoadScene( "InitScene" );

    }

}
