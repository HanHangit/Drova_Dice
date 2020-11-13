using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUI_DiceNumber : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
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
