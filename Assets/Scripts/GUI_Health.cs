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
	private GUI_PlaySound _soundDamagedFeedback = default;
	[SerializeField]
	private GUI_PlaySound _soundHealFeedback = default;

	[SerializeField]
	private List<SoundContainer> _soundContainer = default;
	private SoundContainer _targetSound = default;

	public override void Init(Player player)
	{
		base.Init(player);

		_targetSound = _soundContainer[UnityEngine.Random.Range(0, _soundContainer.Count - 1)];
		player.PlayerStats.PlayerHealthChangedEvent += HealhtChangedListener;
		SetText(player.PlayerStats.Health, player.PlayerStats.MaxHealth);
	}

	private void HealhtChangedListener(int oldhealth, int newhealth)
	{
		//ToDo: fancy stuff here
		if(oldhealth > newhealth)
		{
			GameManager.Instance.PlayAudioSound(_targetSound.GetAudioClipRandom());
		}
		else
		{
			_soundHealFeedback.PlaySound();
		}

		SetText(newhealth, _currentPlayer.PlayerStats.MaxHealth);
	}

	private void SetText(int currentHealth, int maxHealth)
	{
		_curentHealthText.SetText(currentHealth + "/" + maxHealth);
	}
}
