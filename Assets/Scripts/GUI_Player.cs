﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUI_Player : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
	private Player _currentPlayer = default;
	[SerializeField]
	private Image _feedbackObj = default;

	[SerializeField]
	private Transform _background = default;

	[SerializeField]
	private List<GUI_PlayerBhvr> _bhvrs = new List<GUI_PlayerBhvr>();

	public void Init(Player player)
	{
		_currentPlayer = player;

		InitBhvrs(player);
		ActivateFeedbackImage(GameManager.Instance.GetCurrentGame().CurrentBoard.CurrentPlayer);
	}

	public void SetBackground(Vector3 scale)
	{
		_background.localScale = scale;
	}

	private void Awake()
	{
		GameManager.Instance.GetCurrentGame().CurrentBoard.BoardRoundEndedEvent += BoardRoundEndedListener;
	}

	private void ActivateFeedbackImage(Player activePlayer)
	{
		if (activePlayer == _currentPlayer)
		{
			_feedbackObj.enabled = true;;
		}
		else
		{
			_feedbackObj.enabled = false;
		}

	}

	private void BoardRoundEndedListener(Board.RoundEndedEventArgs args)
	{
		Debug.Log("RoundEnd");
		ActivateFeedbackImage(args.NewPlayer);
	}

	private void InitBhvrs(Player player)
	{
		foreach (var item in _bhvrs)
		{
			item.Init(player);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		GameManager.Instance.ExecuteAction(new PlayAction(_currentPlayer.PlayerStats.ID));
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		
	}
}
