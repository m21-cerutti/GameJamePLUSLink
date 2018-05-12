﻿using System.Collections;
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
	Win,
	Cinematique
}
public class HUDManager : SingletonBehaviour<HUDManager>
{

	public GameObject menuStart;
	public GameObject pausePanel;
	public GameObject ATHPanel;
	public GameObject TutorialPanel;
	public GameObject GameOverPanel;
	public GameObject CreditPanel;
	public GameObject LoadingObjects;
	

	public Button[] buttonMain;
	public Button[] buttonPause;

	AsyncOperation async;
	public stateMenu state = stateMenu.Main;

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	new void Awake()
	{
		base.Awake();

		state = stateMenu.Main;

		
	}

	void Update()
	{

		if (state == stateMenu.Main)
		{
			if (Input.GetButtonDown("Cancel"))
			{
				quitGame();
			}
		}
		else if (state == stateMenu.Tutorial && Input.GetButtonDown("Cancel"))
		{
			Backtutorial();
		}
		else if (state == stateMenu.Credit && Input.GetButtonDown("Cancel"))
		{
			Backcredits();
		}
		else if (state == stateMenu.Play && Input.GetButtonDown("Cancel"))
		{
			Pause();
		}
		else if (state == stateMenu.Pause)
		{
			if (Input.GetButtonDown("Cancel"))
			{
				Backpause();
			}
		}
		else if (state == stateMenu.GameOver)
		{
			if (Input.anyKeyDown)
			{
				MenuLoad();
			}
		}
		else if (state == stateMenu.Win)
		{
			if (Input.anyKeyDown)
			{
				MenuLoad();
			}
		}
		else if (state == stateMenu.Cinematique)
		{
			if (Input.anyKeyDown)
			{
				LoadingObjects.SetActive(false);
				LoadGameScene();
			}
		}
	}

	/*Scripts button*/


	public void cursorChange()
	{
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}

	public void cursorStd()
	{
		Cursor.SetCursor(null, Vector2.zero, cursorMode);
	}
	//Menu

	public void playDemo()
	{
		//LoadGameScene();
		PlayCinematique();
	}

	public void LoadGameScene()
	{
		cursorChange();
		SceneManager.LoadScene(1, LoadSceneMode.Single);
		state = stateMenu.Play;
		menuStart.SetActive(false);
		ATHPanel.SetActive(true);

	}

	public void PlayCinematique()
	{
		LoadingObjects.SetActive(true);
		state = stateMenu.Cinematique;
		buttonMain[0].GetComponent<DialogueTrigger>().dialogueTrigger();
	}

	public void MenuLoad()
	{
		cursorStd();
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

	public void Credits()
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

	public void Tutorial()
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

	public void Pause()
	{
		cursorStd();
		Time.timeScale = 0f;
		state = stateMenu.Pause;
		pausePanel.SetActive(true);
	}

	public void Backpause()
	{
		cursorChange();
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

	/*
	public void Loading()
	{
		StartCoroutine(loadingScreen());
	}
	IEnumerator loadingScreen()
	{
		LoadingObjects.SetActive(true);
		async = SceneManager.LoadSceneAsync(1);
		async.allowSceneActivation = false;
		while (async.isDone == false)
		{
			// [0, 0.9] > [0, 1]
			float progress = Mathf.Clamp01(async.progress / 0.9f);
			Debug.Log("Loading progress: " + (progress * 100) + "%");

			LoadingObjects.GetComponent<DialogueTrigger>().dialogueTrigger();


			// Loading completed
			if (async.progress == 0.9f)
			{
				Debug.Log("Press a key to start");
				if (Input.anyKeyDown)
				{
					async.allowSceneActivation = true;
					LoadingObjects.SetActive(false);
					state = stateMenu.Play;
					menuStart.SetActive(false);
					ATHPanel.SetActive(true);
				}
			}
			yield return null;
		}
	}
	*/
}

