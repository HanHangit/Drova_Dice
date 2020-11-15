using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoundContainer : ScriptableObject
{
	[SerializeField]
	private List<AudioClip> _clips = default;
	public List<AudioClip> GetAudioClips => _clips;

	public AudioClip GetAudioClipRandom()
	{
		var audio = UnityEngine.Random.Range(0, _clips.Count - 1);
		return GetAudioClips[audio];
	}
}
