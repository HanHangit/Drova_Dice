using System.Collections;
using System.Collections.Generic;
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

	public GenericEvent<GUI_DiceNumber> ClickedDiceEvent = new GenericEvent<GUI_DiceNumber>();
	public GenericEvent<GUI_DiceNumber> HoveredStartDiceEvent = new GenericEvent<GUI_DiceNumber>();
	public GenericEvent<GUI_DiceNumber> HoveredEndDiceEvent = new GenericEvent<GUI_DiceNumber>();

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
		var action = new SelectAction(_currentDice);
		HoveredStartDiceEvent.InvokeEvent(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("OnExit");
		HoveredEndDiceEvent.InvokeEvent(this);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("OnClick");
		ClickedDiceEvent.InvokeEvent(this);
	}
}
