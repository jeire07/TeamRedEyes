﻿using UnityEngine;

public class CheckMusicVolume : Singleton<CheckMusicVolume>
{
	public void  Start ()
	{
		// remember volume level from last time
		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	}

	public void UpdateVolume ()
	{
		GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
	}
}