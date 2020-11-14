using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic.BoardLogic;
using TMPro;
using UnityEngine;

public class GUI_Ammo : GUI_PlayerBhvr
{
	[SerializeField]
	private TextMeshProUGUI _curentAmmoText = default;

	public override void Init(Player player)
	{
		base.Init(player);

		player.PlayerStats.PlayerAmmoChangedEvent += AmmoChangedListener;
		_curentAmmoText.SetText(player.PlayerStats.Ammo.ToString());
	}

	private void AmmoChangedListener(int oldammo, int newammo)
	{
		_curentAmmoText.SetText(newammo.ToString());
	}
}
