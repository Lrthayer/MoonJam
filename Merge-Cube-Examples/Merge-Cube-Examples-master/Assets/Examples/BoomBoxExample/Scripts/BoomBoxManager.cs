using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This is the BoomBoxManager script attached to the BoomBox object in the BoomBoxExample 
 * scene we provided.
 * 
 * It handles the basic behaviour of our cube when it is and isn't being tracked, provides
 * simple controls with the phone and headset, and allows the user to change the music 
 * being played via BoomBox cube interactivity.
 * 
 **/
public class BoomBoxManager : MonoBehaviour 
{
	public AudioSource boomBoxAudio;
	public AudioClip[] stations;
	public AudioClip buttonSFX;

	private int stationIndex = 0;

	public Animator boomBoxAnimator;
	public Animator volumeUpAnimator;
	public Animator volumeDownAnimator;

	public Transform headTransform;
	public LayerMask lMask;

	public Transform volumeUpButton;
	public Transform volumeDownButton;

	//This is the scene's BasicTrackableEventHandler script that
	//allows us to implement behaviour for when the cube is and
	//isn't being tracked.	
	public BasicTrackableEventHandler imageTarget;

	void Start()
	{
		//In Start, we add our manager's tracking behaviours to our tracking event handler.

		//In situations when you need to disable or change your currently active cube, you 
		//should also remove any behaviours you added to the event handler to prevent any 
		//unwanted events from occuring.

		//Like so:
		//imageTarget.OnTrackingFound -= HandleTrackingFound;
		//imageTarget.OnTrackingLost -= HandleTrackingLost;

		imageTarget.OnTrackingFound += HandleTrackingFound;
		imageTarget.OnTrackingLost += HandleTrackingLost;

		if (imageTarget.isTracking)
		{
			HandleTrackingFound();
		}

		ChangeStation();
	}
		
	void Update()
	{
		//Since the phone screen is used to interface between the user and the program,
		//typical tap controls can be called.
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;

			if( Physics.Raycast( headTransform.position, headTransform.forward, out hit, 100f, lMask ))
			{
				if (hit.transform == volumeUpButton)
				{
					NextStation();
					volumeUpAnimator.Play("VolumeButtonPress");
					boomBoxAudio.PlayOneShot(buttonSFX);
				}
				else if (hit.transform == volumeDownButton)
				{
					PreviousStation();
					volumeDownAnimator.Play("VolumeButtonPress");
					boomBoxAudio.PlayOneShot(buttonSFX);
				}
			}
		}
	}

	void NextStation()
	{
		stationIndex++;

		if (stationIndex > stations.Length - 1)
		{
			stationIndex = 0;
		}

		ChangeStation();
	}

	void PreviousStation()
	{
		stationIndex--;

		if (stationIndex < 0 )
		{
			stationIndex = stations.Length - 1;
		}

		ChangeStation();
	}

	void ChangeStation()
	{
		boomBoxAudio.clip = stations[stationIndex];
		boomBoxAudio.Play();
	}
		
	void HandleTrackingFound()
	{
		boomBoxAudio.UnPause();
	}

	void HandleTrackingLost()
	{
		boomBoxAudio.Pause();
	}
}
