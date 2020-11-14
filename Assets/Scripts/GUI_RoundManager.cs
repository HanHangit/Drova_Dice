using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DrovaDiceLogic;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.DiceGameSettings;
using DrovaDiceLogic.Moves;
using UnityEngine;

public class GUI_RoundManager : MonoBehaviour
{
	[SerializeField]
	private GUI_DiceNumber _diceNumberPrefab = default;
	[SerializeField]
	private Transform _anchor = default;
	[SerializeField]
	private List<GUI_DiceNumber> _diceNumbers = new List<GUI_DiceNumber>();
	private DiceGame _game = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());


	private void Awake()
	{
		_game = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());
		_game.ActionEndedEvent += ActionEndedListener;
		RollDices();
	}

	private void ActionEndedListener(DiceGame.ActionEndedEventArgs args)
	{
		CleanBoard();
		RollDices();
	}

	private void CleanBoard()
	{
		for (int i = _diceNumbers.Count - 1; i >= 0 ; i--)
		{
			var instance = _diceNumbers[i];
			_diceNumbers.Remove(instance);
			Destroy(instance.gameObject);
		}
	}

	public void RollDices()
	{
		Debug.Log("RollDices");
		foreach (var item in _game.CurrentBoard.Dices)
		{
			GUI_DiceNumber instance = Instantiate(_diceNumberPrefab, _anchor);
			_diceNumbers.Add(instance);
			instance.InitDice(item);
			SetEvents(instance);
		}
	}

	private void SetEvents(GUI_DiceNumber dice)
	{
		dice.ClickedDiceEvent.AddEventListener(ClickedDiceButtonListener);
		dice.HoveredStartDiceEvent.AddEventListener(HoverStartDiceButtonListener);
		dice.HoveredEndDiceEvent.AddEventListener(HoverEndDiceButtonListener);
	}

	private void HoverEndDiceButtonListener(GUI_DiceNumber arg0)
	{
	
	}

	private void HoverStartDiceButtonListener(GUI_DiceNumber arg0)
	{

	}

	private void ClickedDiceButtonListener(GUI_DiceNumber arg0)
	{
		if (arg0.CurrentDice.HasModifier(DiceModifier.Selected))
		{
			ExecuteAction(new UnselectAction(arg0.CurrentDice));
		}
		else
		{
			ExecuteAction(new SelectAction(arg0.CurrentDice));
		}
	}

	private void ExecuteAction(AAction action)
	{
		if (_game.CanBePlayed(action))
		{
			Debug.Log("Action Select");
			_game.Play(action);
		}
	}
}
