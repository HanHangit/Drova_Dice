using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUI_DiceNumber : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	[SerializeField]
	private TextMeshProUGUI _text = default;


	public void SetNumber(string numberText)
	{
		_text.SetText(numberText);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnEnter");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("OnExit");
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("OnClick");
	}
}
