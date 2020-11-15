using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Introduction : MonoBehaviour
{
	[SerializeField]
	private GUI_PlaySound _sound = default;
	[SerializeField]
	private GUI_RoundManager _roundManager = default;

	public void DestroyThisPanel()
	{
		_roundManager.Init();
		Destroy(this.gameObject);
	}

	private void Awake()
	{
		_sound.PlaySound();
	}
}
