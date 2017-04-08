using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GazeCaster : MonoBehaviour 
{
	RaycastHit hit;
	public LayerMask lMask;

	bool currentlyGazing = false;
	GameObject gazedObject = null;
	GazeResponder gazeResponder = null;
	GazeResponder pressedObject = null;

	public delegate void GazeEvent();
	public event GazeEvent OnGaze_Start;
	public event GazeEvent OnGaze_End;
	public event GazeEvent OnGaze_InputDown;
	public event GazeEvent OnGaze_InputUp;

	public bool isMonoScreenMode = false;
	public void SwapScreenViewMode()
	{
		isMonoScreenMode = !isMonoScreenMode;
	}

	void Update ()
	{
		Ray ray = new Ray ();

		//Set up the ray to aim either at the screen position for tapping in Mono screen or for forward gaze direction for dual screen
		if (isMonoScreenMode) 
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		} 
		else 
		{
			ray.origin = this.transform.position;
			ray.direction = this.transform.forward;
		}

		if(Input.GetMouseButtonDown(0))
		{
			TriggerPressed();
		}

		if(Input.GetMouseButtonUp(0))
		{
			TriggerReleased();
		}
			
		if (Physics.Raycast (ray, out hit, 100000f, lMask)) 
		{                                  
			Debug.DrawRay(ray.origin, ray.direction);

			//The thing we are looking at isnt the same guy!!
			if (hit.transform.gameObject != gazedObject)
			{
				//Stop looking at the old guy! Tell him to go away.
				if (gazeResponder != null)
				{
					gazeResponder.OnGazeExit();

					if ( OnGaze_End != null)
					{
						OnGaze_End.Invoke();
					}
				}

				//Clean up for the new guy
				currentlyGazing = false;
				gazedObject = hit.transform.gameObject;
				gazeResponder = hit.transform.GetComponent<GazeResponder>();
			}
				
			//We were  NOT previously looking at something last tick, so lets have it do stuff
			//I must be looking at something new, look at the new thing.
			if (!currentlyGazing && gazedObject != null && gazeResponder != null )
			{
				gazeResponder.OnGazeEnter();

				if( OnGaze_Start != null )
				{
					OnGaze_Start.Invoke();
				}

				currentlyGazing = true;
			}
				
		}
		else
		{
			//We aren't looking at anything at all. Clean up and stop looking at the previous guy
			//We were previously looking at something last tick, so lets have it do stuff
			if (currentlyGazing && gazeResponder != null && gazedObject != null)
			{
				gazeResponder.OnGazeExit();

				if( OnGaze_End != null )
				{
					OnGaze_End.Invoke();
				}
			}

			currentlyGazing = false;
			gazedObject = null;
			gazeResponder = null;
		}
	}

	public void TriggerPressed()
	{
		if (!enabled)
		{
			return;
		}

		//I pushed the button, is there somebody I'm looking at who would care about this?
		if (currentlyGazing && gazedObject != null && gazeResponder != null)
		{
			gazeResponder.OnGazeTrigger();
			pressedObject = gazeResponder;
		}

		//Inform anybody else who would care about this
		if(OnGaze_InputDown != null )
		{
			OnGaze_InputDown.Invoke();
		}
	}

	public void TriggerReleased()
	{
		if (!enabled)
		{
			return;
		}

		//I stopped pushing the button, does the guy who would care about this still exist?
		if ( pressedObject != null )
		{
			pressedObject.OnGazeTriggerEnd();
			pressedObject = null;
		}

		//Inform anybody else who would care about this
		if (OnGaze_InputUp != null)
		{
			OnGaze_InputUp.Invoke();
		}
	}
}
