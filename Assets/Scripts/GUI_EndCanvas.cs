using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI_EndCanvas : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _winMessageText = default;
	[SerializeField]
	private TextMeshProUGUI _loseMessageText = default;
	[SerializeField]
	private Button _restartButton = default;
	[SerializeField]
	private string _restartSceneName = "";
	private void Start()
	{
		_restartButton.onClick.AddListener(RestartButtonClickedListener);
	}

	private void RestartButtonClickedListener()
	{
		SceneManager.LoadScene(_restartSceneName);
	}
}
