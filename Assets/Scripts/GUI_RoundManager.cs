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


	private void Awake()
	{
		GameManager.Instance.InitGame(new DiceGame(DiceGameSettings.CreateDefaultGameSettings()));
		GameManager.Instance.GetCurrentGame().ActionEndedEvent += ActionEndedListener;
		RollDices();
	}

	private void ActionEndedListener(DiceGame.GameMoveEndedEventArgs args)
	{
		if (args.Action is AAction action)
		{
			if (action is SelectAction)
			{

			}

		}

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
		foreach (var item in GameManager.Instance.GetCurrentGame().CurrentBoard.Dices)
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
		var game = GameManager.Instance.GetCurrentGame();
		if (game.CanBePlayed(action))
		{
			Debug.Log("Action Select");
			game.Play(action);
		}
	}
}
