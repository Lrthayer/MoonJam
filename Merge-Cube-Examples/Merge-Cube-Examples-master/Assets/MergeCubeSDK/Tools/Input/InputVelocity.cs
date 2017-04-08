using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * How To Use:
 * Register to the OnVelocityReached() event to receive the average direction once terminal velocity is reached.
 * 
 * This is a velocity detector that will return an event call whenever the object being tracked moves 
 * beyond a specified distance over time.
 * 
 * It handles this by keeping a short list of time samples and position samples and then comparing them after a 
 * specified number of samples are saved. Afterwards, the event can go on a cooldown so that it isn't called too often.
 * 
 **/

public class InputVelocity : MonoBehaviour 
{
	private List<float> previousDistances = new List<float>();
	private List<float> previousTimes = new List<float>();

	private Vector3 lastPos;
	private bool currentlyCoolingDown = false;


	//This is the scene's BasicTrackableEventHandler script that
	//allows us to implement behaviour for when the cube is and
	//isn't being tracked.
	public BasicTrackableEventHandler imageTarget;

	public bool shouldCooldown = false;
	public float cooldownDuration = 1f;

	public int sampleRate = 3;
	public float velocityThreshold = .2f;

	public delegate void VelocityEvent( Vector3 averageDirection, float velocity );
	public event VelocityEvent OnVelocityReached;


	void Start()
	{
		//In the case of Input Velocity, we want to know when the image target has lost tracking. 
		//This allows us to cleanly manage our motion tracking so that when they refind the 
		//image target it doesn't register a new and potentially wrong velocity event.

		imageTarget.OnTrackingFound += OnTrackingFound;
		imageTarget.OnTrackingLost += OnTrackingLost;
	}
		
	void Update () 
	{
		if (!currentlyCoolingDown) 
		{
			TrackingMotion (); 
		}
	}


	void OnTrackingFound()
	{
		lastPos = transform.position;
	}

	void OnTrackingLost()
	{
		previousDistances.Clear();
		previousTimes.Clear ();
	}
		
	void TrackingMotion()
	{
		previousDistances.Add (Vector3.Distance (transform.position, lastPos));
		previousTimes.Add (Time.deltaTime);

		if (previousDistances.Count >= sampleRate) 
		{
			ProcessMotion ();
		}

		lastPos = transform.position;
	}

	//Clean the oldest recorded distance, calculate the total distance travelled and the total time elapsed between samples,
	//then if the velocity is greater than or equal to the terminal velocity (The velocity at which we should send an event to any listeners),
	//invoke the event if anybody is listening.
	//Then clean the history list and initialize the cooldown sequence if it is enabled.
	void ProcessMotion()
	{
		while (previousDistances.Count > sampleRate) 
		{
			previousDistances.RemoveAt (0);
		}

		while (previousTimes.Count > sampleRate) 
		{
			previousTimes.RemoveAt (0);
		}

		float totalDis = 0;
		float totalTime = 0;

		foreach (float tp in previousDistances) 
		{
			totalDis += tp;
		}

		foreach (float tp in previousTimes) 
		{
			totalTime += tp;
		}

		if (totalDis / totalTime >= velocityThreshold)
		{
			if (OnVelocityReached != null)
			{
				OnVelocityReached.Invoke( (transform.position - lastPos).normalized, totalDis / totalTime );
			}

			previousDistances.Clear ();
			previousTimes.Clear ();
			currentlyCoolingDown = true;

			if (shouldCooldown)
				Invoke("Cooldown", cooldownDuration);
			else
				Cooldown();
		}
	}

	//Once called, this will record the current location and exit the cooldown phase.
	//this in turn enables Update to begin processing the motions again.
	void Cooldown()
	{
		lastPos = transform.position;
		currentlyCoolingDown = false;
	}
}