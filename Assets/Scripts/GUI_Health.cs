using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic.BoardLogic;
using TMPro;
using UnityEngine;

public class GUI_Health : GUI_PlayerBhvr
{
	[SerializeField]
	private TextMeshProUGUI _curentHealthText = default;
	[SerializeField]
	private TextMeshProUGUI _maxHealthText = default;

	public override void Init(Player player)
	{
		base.Init(player);

		player.PlayerStats.PlayerHealthChangedEvent += HealhtChangedListener;
		_curentHealthText.SetText(player.PlayerStats.Health.ToString());

	}

	private void HealhtChangedListener(int oldhealth, int newhealth)
	{
		//ToDo: fance stuff here
		_curentHealthText.SetText(newhealth.ToString());
	}
}
