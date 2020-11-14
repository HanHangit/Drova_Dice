using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DrovaDiceLogic;
using DrovaDiceLogic.DiceGameSettings;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    private GameManager() { }

    public static GameManager Instance
    {
	    get
	    {
            if(_instance == null)
            {
	            _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
	    }
    }

    private DiceGame _currentGame = default;

    public DiceGame GetCurrentGame() => _currentGame;

    public void InitGame(DiceGame diceGame)
    {
	    _currentGame = diceGame;
    }
}
