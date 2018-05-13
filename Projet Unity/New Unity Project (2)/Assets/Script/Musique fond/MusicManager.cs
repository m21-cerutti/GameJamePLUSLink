using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MusicManager :  SingletonBehaviour<MusicManager>
{

	public GameObject audioFondPrefab;
	
	public GameObject audioNoisePrefab;
	public GameObject audioNoisePrefab_gun;
	public GameObject audioNoisePrefab_player;

	AudioSource audioFond;
	AudioSource audioNoise;
	public bool win;

	public AudioClip MainMenu;
	public AudioClip Game;

	[SerializeField]
	public Noise[] Noises;


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
		}
	}

	public void playNoise_gun(int nb)
	{
		if (audioNoise != null && (!audioNoise.isPlaying || Noises[nb].important))
		{
			audioNoise.clip = Noises[nb].clip;
			audioNoise.Play();
		}
	}

	public void playNoise_player(int nb)
	{
		if (audioNoise != null && (!audioNoise.isPlaying || Noises[nb].important))
		{
			audioNoise.clip = Noises[nb].clip;
			audioNoise.Play();
		}
	}


	void Start()
	{

		if (!GameObject.Find("AudioBackground(Clone)"))
		{
			audioFond = Instantiate(audioFondPrefab).GetComponent<AudioSource>();
			audioFond.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);
			audioFond.clip = MainMenu;
		}
		if (!GameObject.Find("AudioNoise(Clone)"))
		{
			audioNoise = Instantiate(audioNoisePrefab).GetComponent<AudioSource>();
			audioNoise.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);
		}

		if (!GameObject.Find("AudioNoise_gun(Clone)"))
		{
			audioNoise = Instantiate(audioNoisePrefab_gun).GetComponent<AudioSource>();
			audioNoise.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);
		}

		if (!GameObject.Find("AudioNoise_player(Clone)"))
		{
			audioNoise = Instantiate(audioNoisePrefab_player).GetComponent<AudioSource>();
			audioNoise.transform.SetParent(GameObject.FindGameObjectWithTag("MainCamera").transform);
		}

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

			audioFond = Instantiate(audioFondPrefab).GetComponent<AudioSource>();
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
