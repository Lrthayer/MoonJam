using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This is the InputExampleManager script attached to the MultiTarget object in the InputExample 
 * scene we provided.
 * 
 * It handles all objects and functions called from various InputButton and InputRelativeRotation scripts.
 * 
 **/
public class InputExampleManager : MonoBehaviour 
{
	public Transform objectCube;
	public Renderer [] cubeSides;
	int cubeClickCount = 1;

	public Color [] colorPool;
	int colorIndex = 0;

	public bool alwaysReMatch = false;
	bool alreadyMatch = false;

	public InputRelativeRotation rotExample;

	void Start()
	{
		//In Start, we add our manager's tracking behaviours to our tracking event handler.

		//In situations when you need to disable or change your currently active cube, you 
		//should also remove any behaviours you added to the event handler to prevent any 
		//unwanted events from occuring.

		//Like so:
		//GetComponent<BasicTrackableEventHandler>().OnTrackingFound -= HandleTrackingFound;
		//GetComponent<BasicTrackableEventHandler>().OnTrackingLost -= HandleTrackingLost;
		rotExample.OnRotationChange += ShowCubeRelativeRotation;

		GetComponent<BasicTrackableEventHandler>().OnTrackingFound += OnTrackingFound;
		GetComponent<BasicTrackableEventHandler>().OnTrackingLost += OnTrackingLost;
	}

	void OnTrackingFound()
	{
		if (!alreadyMatch) 
		{
			Merge.CubeOrientation.OrientateToCamera (transform,objectCube);
			alreadyMatch = !alwaysReMatch;
		}
	}

	void OnTrackingLost()
	{
		
	}
		
	//Cycles through a set integer range and updates the cube's texture scale accordingly.
	public void CubeClick()
	{
		cubeClickCount++;
		if (cubeClickCount > 5) 
		{
			cubeClickCount = 1;
		}
		Vector2 sizeTp = Vector2.one * (float)cubeClickCount;
		foreach (Renderer tp in cubeSides) 
		{
			tp.material.SetTextureScale ("_decal", sizeTp);
		}
	}
		
	public void CubeDelete()
	{
		
		Destroy (GameObject.FindGameObjectWithTag("cylinder"));
	}
	//Cycles through a set integer range and updates the cube's texture color accordingly.
	public void NextClick()
	{
		colorIndex++;
		if (colorIndex >= colorPool.Length) 
		{
			colorIndex = 0;
		}
		foreach (Renderer tp in cubeSides) 
		{
			tp.material.SetColor("_basecolor", colorPool[colorIndex]);
		}
	}
		

	//Rotation Input
	public Transform xRef;
	public Transform yRef;
	public Transform zRef;

	public void ShowCubeRelativeRotation(Vector3 rotationChange)
	{
		xRef.Rotate (new Vector3 (rotationChange.x, 0, 0));
		yRef.Rotate (new Vector3 (0, rotationChange.y, 0));
		zRef.Rotate (new Vector3 (0, 0, rotationChange.z));
	}
}
