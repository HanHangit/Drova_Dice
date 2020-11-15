using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI_StartMenu : MonoBehaviour
{
	[SerializeField]
	private Button _startButton = default;

	[SerializeField]
	private Button _endButton = default;

	[SerializeField]
	private string _sceneName = default;

	private void Awake()
	{
		_startButton.onClick.AddListener(StartButtonClickedListener);
		_endButton.onClick.AddListener(EndButtonClickedListener);
	}

	private void EndButtonClickedListener()
	{
		Application.Quit();
	}

	private void StartButtonClickedListener()
	{
		SceneManager.LoadScene(_sceneName);
	}
}
