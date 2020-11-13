using System;
using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic;
using DrovaDiceLogic.DiceGameSettings;
using UnityEngine;

public class GUI_RoundManager : MonoBehaviour
{

	[SerializeField]
	private List<GUI_DiceNumber> _diceNumbers = default;
	private void Awake()
	{
		RollDices();
	}

	public void RollDices()
	{
		DiceGame game = new DiceGame(DiceGameSettings.CreateDefaultGameSettings());


	}
}
