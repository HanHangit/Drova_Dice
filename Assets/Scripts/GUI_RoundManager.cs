using System.Collections.Generic;
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
	private Transform _diceAnchor = default;
	[SerializeField]
	private GUI_Player _playerPrefab = default;
	[SerializeField]
	private List<Transform> _playerAnchors = default;


	[SerializeField]
	private List<GUI_Player> _playersList = new List<GUI_Player>();

	[SerializeField]
	private List<GUI_DiceNumber> _diceNumbers = new List<GUI_DiceNumber>();


	private void Awake()
	{
		GameManager.Instance.InitGame(new DiceGame(DiceGameSettings.CreateDefaultGameSettings()));
		GameManager.Instance.GetCurrentGame().ActionEndedEvent += ActionEndedListener;
		CreatePlayer();
		RollDices();
	}

	private void CreatePlayer()
	{
		var players = GameManager.Instance.GetCurrentGame().CurrentBoard.Players;
		for (var i = 0; i < players.Count; i++)
		{
			var item = players[i];
			if (i <= _playerAnchors.Count - 1)
			{
				var instance = Instantiate(_playerPrefab, _playerAnchors[i]);
				instance.Init(item);
				_playersList.Add(instance);
			}
		}
	}

	private void ActionEndedListener(DiceGame.GameTurnEndedEventArgs args)
	{
		if (args.GameTurn is AAction action)
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
			if (!item.HasModifier(DiceModifier.Saved))
			{
				GUI_DiceNumber instance = Instantiate(_diceNumberPrefab, _diceAnchor);
				_diceNumbers.Add(instance);
				instance.InitDice(item);
				SetEvents(instance);
			}
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

	}


}
