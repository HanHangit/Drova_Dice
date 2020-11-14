using System;
using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic.BoardLogic;
using UnityEngine;

public class GUI_Player : MonoBehaviour
{
	public Player _currentPlayer = default;

	public Player GetCurrentPlayer() => _currentPlayer;

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
}
