using System;
using System.Collections;
using System.Collections.Generic;
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
	            _instance = new GameManager();
            }

            return _instance;
	    }
    }
}
