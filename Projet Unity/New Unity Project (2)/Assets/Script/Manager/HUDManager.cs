using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public enum stateMenu
{
	Main,
	Tutorial,
	Pause,
	Play,
	Credit,
	GameOver,
	Win
}
public class HUDManager : SingletonBehaviour<HUDManager>
{

	public GameObject menuStart;
	public GameObject pausePanel;
	public GameObject ATHPanel;
	public GameObject TutorialPanel;
	public GameObject GameOverPanel;
	public GameObject CreditPanel;

	public Button[] buttonMain;
	public Button[] buttonPause;
	public Button[] buttonGameOver;

	public stateMenu state = stateMenu.Main;



	new void Awake()
	{
		base.Awake();

		state = stateMenu.Main;

		
	}

	void Update()
	{

		if (state == stateMenu.Main)
		{
			if (Input.GetButtonDown("Escape"))
			{
				quitGame();
			}
		}
		else if (state == stateMenu.Tutorial && Input.GetButtonDown("Escape"))
		{
			Backtutorial();
		}
		else if (state == stateMenu.Credit && Input.GetButtonDown("Escape"))
		{
			Backcredits();
		}
		else if (state == stateMenu.Play && Input.GetButtonDown("Escape"))
		{
			pause();
		}
		else if (state == stateMenu.Pause)
		{
			if (Input.GetButtonDown("Escape"))
			{
				Backpause();
			}
		}
		else if (state == stateMenu.GameOver)
		{
			if (Input.anyKeyDown)
			{
				menuLoad();
			}
		}
		else if (state == stateMenu.Win)
		{
			if (Input.anyKeyDown)
			{
				menuLoad();
			}
		}
	}

	/*Scripts button*/

	//Menu

	public void playDemo()
	{
		LoadGameScene();
	}

	public void LoadGameScene()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		SceneManager.LoadScene(1, LoadSceneMode.Single);
		state = stateMenu.Play;
		

	}

	public void menuLoad()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		Time.timeScale = 1f;
		state = stateMenu.Main;
		SceneManager.LoadScene(0, LoadSceneMode.Single);
		menuStart.SetActive(true);
		pausePanel.SetActive(false);
		
		Time.timeScale = 1f;
		
	}

	public void quitGame()
	{
		Application.Quit();
		Debug.Log("Game closed");
	}


	//Credits

	public void credits()
	{
		state = stateMenu.Credit;
		CreditPanel.SetActive(true);
	}

	public void Backcredits()
	{
		state = stateMenu.Main;
		CreditPanel.SetActive(false);
	}

	//Tutorial

	public void tutorial()
	{
		state = stateMenu.Tutorial;
		TutorialPanel.SetActive(true);

	}

	public void Backtutorial()
	{
		state = stateMenu.Main;
		TutorialPanel.SetActive(false);
	}

	//Pause

	public void pause()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		Time.timeScale = 0f;
		state = stateMenu.Pause;
		pausePanel.SetActive(true);
	}

	public void Backpause()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		Time.timeScale = 1f;
		state = stateMenu.Play;
		pausePanel.SetActive(false);
	}


	public void GameOver()
	{
		HUDManager.Instance.GameOverPanel.SetActive(true);
		state = stateMenu.GameOver;
	}

	public void BackGameOver()
	{
		HUDManager.Instance.GameOverPanel.SetActive(false);
		state = stateMenu.Play;
	}

}

