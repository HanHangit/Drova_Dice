using System.Collections;
using System.Collections.Generic;
using DrovaDiceLogic.BoardLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Ammo : GUI_PlayerBhvr
{
	[SerializeField]
	private TextMeshProUGUI _curentAmmoText = default;
	[SerializeField]
	private Sprite _enougAmmo = default;
	[SerializeField]
	private Sprite _noAmmo = default;
	[SerializeField]
	private Image _image = default;

	public override void Init(Player player)
	{
		base.Init(player);

		player.PlayerStats.PlayerAmmoChangedEvent += AmmoChangedListener;
		_curentAmmoText.SetText(player.PlayerStats.Ammo.ToString());
		_image.sprite = _noAmmo;
	}

	private void AmmoChangedListener(int oldammo, int newammo)
	{
		if (newammo > 0)
		{
			_image.sprite = _enougAmmo;
		}
		else
		{
			_image.sprite = _noAmmo;
		}
		_curentAmmoText.SetText(newammo.ToString());
	}
}
