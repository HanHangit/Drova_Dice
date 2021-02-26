using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Sprites")]
public class FaceContainer : ScriptableObject
{
	[SerializeField]
	private List<Sprite> _sprites = default;

	public Sprite GetRandomSprite()
	{
		if (_sprites.Count > 0)
		{
			var rnd = UnityEngine.Random.Range(0, _sprites.Count - 1);
			return _sprites[rnd];
		}
		else
		{
			return null;
		}
	}
}
