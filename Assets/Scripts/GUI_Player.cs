using System;
using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUI_Player : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
	public Player _currentPlayer = default;

	[SerializeField]
	private List<GUI_PlayerBhvr> _bhvrs = new List<GUI_PlayerBhvr>();

	public void Init(Player player)
	{
		_currentPlayer = player;
		InitBhvrs(player);
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
		var game = GameManager.Instance.GetCurrentGame();
		var action = new PlayAction();
		if(game.CanBePlayed(action))
		{
			game.Play(action);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		
	}
}
