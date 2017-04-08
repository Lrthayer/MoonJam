using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class BasicGazeButton : MonoBehaviour, GazeResponder 
{
	public UnityEvent OnGazeStart;
	public UnityEvent OnGazeEnd;
	public UnityEvent OnGazeInput;
	public UnityEvent OnGazeInputEnd;

	public void OnGazeEnter()
	{
		OnGazeStart.Invoke();
	}

	public void OnGazeExit()
	{
		OnGazeEnd.Invoke();
	}

	public void OnGazeTrigger()
	{
		OnGazeInput.Invoke();
	}

	public void OnGazeTriggerEnd()
	{
		OnGazeInputEnd.Invoke();
	}
}
