using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_SetRandomFace : MonoBehaviour
{
	[SerializeField]
	private FaceContainer _faceContainer = default;
	[SerializeField]
	private Image _image = default;

	private void Awake()
	{
		_image.sprite = _faceContainer.GetRandomSprite();
	}
}
