using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUI_PlaySound : MonoBehaviour
{

	[SerializeField]
	private List<AudioClip> _audioClips = default;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
			PlaySound();
	}

	public void PlaySound()
	{
		if (_audioClips.Count > 0)
		{
			var sound = UnityEngine.Random.Range(0, _audioClips.Count - 1);
			GameManager.Instance.PlayAudioSound(_audioClips[sound]);
		}
	}
}
