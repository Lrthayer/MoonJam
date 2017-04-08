using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ToggleSprite : MonoBehaviour 
{
	public Sprite onSprite;
	public Sprite offSprite;
	public bool isOn = false;

	public void ToggleSpriteVisuals()
	{
		GetComponent<Image>().sprite = (isOn) ? offSprite : onSprite;
		isOn = !isOn;
	}
}
