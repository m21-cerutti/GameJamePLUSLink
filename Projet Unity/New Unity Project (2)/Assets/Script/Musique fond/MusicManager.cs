using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MusicManager :  SingletonBehaviour<MusicManager>
{

	public GameObject audioFondPrefab;
	public GameObject audioNoisePrefab;
	AudioSource audioFond;
	AudioSource audioNoise;
	public bool win;

	public AudioClip MainMenu;
	public AudioClip Game;

	[SerializeField]
	public Noise[] Noises;

	bool priority = false;

	[System.Serializable]
	public struct Noise
	{
		public AudioClip clip;
		public bool important;
	};

	public void playNoise(int nb)
	{
		if (audioNoise !=null && (!audioNoise.isPlaying || Noises[nb].important))
		{
			audioNoise.clip = Noises[nb].clip;
			audioNoise.Play();
			priority = Noises[nb].important;
		}
	}

	new void Awake ()
	{
		base.Awake();
		if (!GameObject.Find ("AudioBackground(Clone)")) {
			audioFond = Instantiate(audioFondPrefab).GetComponent<AudioSource>();
			audioFond.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);
			audioFond.clip = MainMenu;
		}
		if (!GameObject.Find("AudioNoise(Clone)"))
		{
			audioNoise = Instantiate(audioNoisePrefab).GetComponent<AudioSource>();
			audioNoise.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);
		}
	}

	void Start()
	{
		audioFond.PlayDelayed(0.3f);
	}

	private void Update()
	{
		
		if (audioNoise == null)
		{
			audioNoise = Instantiate(audioNoisePrefab).GetComponent<AudioSource>();
			audioNoise.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);

		}

		if (audioFond == null)
		{

			audioFond = Instantiate(audioNoisePrefab).GetComponent<AudioSource>();
			audioFond.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);

		}
		else
		{
			if (HUDManager.Instance.state == stateMenu.Main  && audioFond.clip != MainMenu)
			{
				audioFond.Stop();
				audioFond.clip = MainMenu;
				audioFond.PlayDelayed(0.3f);

			}

			if (HUDManager.Instance.state == stateMenu.Play  && audioFond.clip != Game)
			{
				audioFond.Stop();
				audioFond.clip = Game;
				audioFond.PlayDelayed(0.3f);
			}

			if (HUDManager.Instance.state == stateMenu.Win)
			{
				audioFond.volume = Mathf.Lerp(audioFond.volume, 0f, 0.02f);
			}
		}
	}
}
