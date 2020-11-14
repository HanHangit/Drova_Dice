using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic.BoardLogic;
using UnityEngine;

public class GUI_PlayerBhvr : MonoBehaviour
{
	protected Player _currentPlayer = default;
	public virtual void Init(Player player)
	{
		_currentPlayer = player;
	}
}
