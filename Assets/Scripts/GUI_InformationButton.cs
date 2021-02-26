using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_InformationButton : MonoBehaviour
{
	[SerializeField]
	private GameObject _obj = default;

	[SerializeField]
	private Button _button = default;

	private void Awake()
	{
		if(_button == null)
			_button = GetComponent<Button>();

		_button.onClick.AddListener(ButtonClickedListener);

	}

	private void ButtonClickedListener()
	{
		Debug.Log("ASD");
		_obj.gameObject.SetActive(true);
	}
}
