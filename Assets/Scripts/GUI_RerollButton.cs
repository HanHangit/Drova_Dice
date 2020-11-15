using System;
using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_RerollButton : MonoBehaviour
{
	[SerializeField]
	private Button _rerollButton = default;

	private void Start()
	{
		_rerollButton.onClick.AddListener(RerollButtonClickedListener);

		GameManager.Instance.GetCurrentGame().ActionEndedEvent += ActionEndedListener;

	}

	private void ActionEndedListener(DiceGame.GameTurnEndedEventArgs args)
	{
		if (!GameManager.Instance.GetCurrentGame().CurrentBoard.IsRerollPossible())
		{
			_rerollButton.interactable = false;
		}
		else
		{
			if(_rerollButton.interactable != true)
				_rerollButton.interactable = true;
		}
	}

	private void RerollButtonClickedListener()
	{
		GameManager.Instance.ExecuteAction(new RerollTurn());
	}
}
