using UnityEngine;
using System.Collections;

public interface GazeResponder
{
	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer.
	void OnGazeEnter();

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	void OnGazeExit();

	/// Called when the trigger is pressed, between OnGazeEnter and OnGazeExit. Down only.
	void OnGazeTrigger();

	// Called when the trigger is released, after OnGazeTrigger has been called.
	void OnGazeTriggerEnd();
}
