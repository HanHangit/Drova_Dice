using System;
using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic;
using DrovaDiceLogic.BoardLogic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_EndTurnButton : MonoBehaviour
{
	[SerializeField]
	private Button _turnButton = default;
	[SerializeField]
	private GUI_PlaySound _sound = default;

	private void Awake()
	{
		_turnButton.onClick.AddListener(TurnEndButtonClickedListener);
		
	}

	private void TurnEndButtonClickedListener()
	{
		GameManager.Instance.ExecuteAction(new EndRound());
		_sound.PlaySound();
	}
}
