using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * How to use: 
 * Attach sprite renderer object to ARCamera to ensure reticle stays in place on screen.
 * Attach script to your sprite renderer reticle.
 * 
 * This script updates the scale of the object it's attached to when called.
 * 
 **/
public class PointerControl : MonoBehaviour 
{
	static PointerControl s_ins;

	void Awake()
	{
		s_ins = this;
	}

	public static PointerControl Ins
	{
		get { return s_ins; }
	}

	Vector3 defaultSize;
	float sizeFactor = 1f;
	float currSize = 1f;

	void Start () 
	{
		defaultSize = transform.localScale;
		SetToZero ();
	}

	public void SetToZero()
	{
		StopAllCoroutines ();
		transform.localScale = Vector3.zero;
		currSize = sizeFactor = 0f;
	}

	public void SetToDefault()
	{
		StopAllCoroutines ();
		transform.localScale = defaultSize;
		currSize = sizeFactor = 1f;
	}

	public void ZoomUp()
	{
		sizeFactor = 1.5f;
		StartCoroutine ("SizeToZoom");
	}

	public void ZoomToDefault()
	{
		sizeFactor = 1f;
		StartCoroutine ("SizeToDefault");
	}

	public void FadeIn()
	{

	}

	public void FadeOut()
	{

	}

	IEnumerator SizeToZoom()
	{
		while (currSize < sizeFactor) 
		{
			currSize += Time.deltaTime * 2f;
			if (currSize > sizeFactor) 
			{
				currSize = sizeFactor;
			}
			transform.localScale = defaultSize * currSize;
			yield return new WaitForFixedUpdate ();
		}
		yield return null;
	}

	IEnumerator SizeToDefault()
	{
		while (currSize > 1f) 
		{
			currSize -= Time.deltaTime * 2f;
			if (currSize < 1f) 
			{
				currSize = 1f;
			}
			transform.localScale = defaultSize * currSize;
			yield return new WaitForFixedUpdate ();
		}
		yield return null;
	}

}
