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

	private void Awake()
	{
		_rerollButton.onClick.AddListener(RerollButtonClickedListener);
	}

	private void RerollButtonClickedListener()
	{
		var game = GameManager.Instance.GetCurrentGame();
		var move = new RerollMove();
		game.Play(move);
	}
}
