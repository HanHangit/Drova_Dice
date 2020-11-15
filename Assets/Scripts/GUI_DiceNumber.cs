using System;
using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUI_DiceNumber : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField]
	private Image _feedbackImage = default;

	private Dice _currentDice = default;
	public Dice CurrentDice => _currentDice;
	[SerializeField]
	private Image _targetImage = default;

	[SerializeField]
	private List<Element> _elements = default;

	[Serializable]
	public class Element
	{
		public int Numer;
		public Sprite Sprite;
	}

	public void InitDice(Dice dice)
	{
		var sprite = _elements.Find(x => x.Numer == dice.Number).Sprite;
		_targetImage.sprite = sprite;

		_currentDice = dice;

		if(dice.HasModifier(DiceModifier.Selected))
		{
			_feedbackImage.gameObject.SetActive(true);
		}
		else
		{
			_feedbackImage.gameObject.SetActive(false);
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
		if (CurrentDice.HasModifier(DiceModifier.Selected))
		{
			GameManager.Instance.ExecuteAction(new UnselectAction(CurrentDice));
		}
		else
		{
			GameManager.Instance.ExecuteAction(new SelectAction(CurrentDice));
		}
	}
}
