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
	private TextMeshProUGUI _text = default;
	[SerializeField]
	private Image _image = default;

	private Dice _currentDice = default;
	public Dice CurrentDice => _currentDice;

	public void InitDice(Dice dice)
	{
		_currentDice = dice;
		_text.SetText(dice.Number.ToString());

		if(dice.HasModifier(DiceModifier.Selected))
		{
			_image.color = Color.red;
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
