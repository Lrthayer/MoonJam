using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GazeSpriteButton : MonoBehaviour, GazeResponder 
{
	private Image image;
	
	public Sprite defaultState;
	public Color defaultColor;

	public Sprite hoverState;
	public Color hoverColor;

	public Sprite downState;
	public Color downColor;

	public UnityEvent OnGazeStart;
	public UnityEvent OnGazeEnd;
	public UnityEvent OnGazeInput;
	public UnityEvent OnGazeInputEnd;

	void Start()
	{
		image = gameObject.GetComponent<Image>();
	}

	bool isGazing = false;

	public void OnGazeEnter()
	{
		isGazing = true;

		OnGazeStart.Invoke();

		if(hoverState != null)
			image.sprite = hoverState;

		image.color = hoverColor;
	}

	public void OnGazeExit()
	{
		isGazing = false; 

		OnGazeEnd.Invoke();

		if( defaultState != null)
			image.sprite = defaultState;

		image.color = defaultColor;
	}

	public void OnGazeTrigger()
	{
		OnGazeInput.Invoke();

		if(downState != null)
			image.sprite = downState;

		image.color = downColor;


	}

	public void OnGazeTriggerEnd()
	{
		OnGazeInputEnd.Invoke();


		if (isGazing && defaultState != null)
		{
			image.sprite = hoverState;
		}
		else if( hoverState != null)
		{
			image.sprite = defaultState;
		}

		if(isGazing && defaultState != null)
		{
			image.color = hoverColor;
		}
		else if( hoverState != null)
		{
			image.color = defaultColor;
		}
	}

}
