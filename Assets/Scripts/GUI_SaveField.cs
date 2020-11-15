using System;
using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUI_SaveField : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField]
	private GUI_DiceNumber _diceNumberPrefab = default;
	[SerializeField]
	private Transform _diceAnchor = default;
	[SerializeField]
	private List<GUI_DiceNumber> _diceNumbers = new List<GUI_DiceNumber>();

	private void Start()
	{
		var game = GameManager.Instance.GetCurrentGame();
		game.ActionEndedEvent += ActionChangedListener;

	}

	private void ActionChangedListener(DiceGame.GameTurnEndedEventArgs args)
	{
		for (int i = _diceNumbers.Count - 1 ; i >= 0 ; i--)
		{
			var instance = _diceNumbers[i];
			_diceNumbers.Remove(instance);
			Destroy(instance.gameObject);
		}


		var dices = GameManager.Instance.GetCurrentGame().CurrentBoard.Dices;
		for (int i = 0; i < dices.Count; i++)
		{
			var modifier = dices[i].HasModifier(DiceModifier.Saved);
			if (modifier)
			{
				GUI_DiceNumber instance = Instantiate(_diceNumberPrefab, _diceAnchor);
				_diceNumbers.Add(instance);
				instance.InitDice(dices[i]);
			}

		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{

	}

	public void OnPointerExit(PointerEventData eventData)
	{
		
	}

	public void OnPointerClick(PointerEventData eventData)
	{

		GameManager.Instance.ExecuteAction(new SaveAction());
	}
}
