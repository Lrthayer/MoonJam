using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This is the MatchPosLookCam script attached to the ArrowRoot object in the InputExample 
 * scene we provided.
 * 
 * It's a simple tool script that's used to set its object's position to that of a referenced
 * object while also having it look at the main Camera.
 * 
 **/
public class MatchPosLookCam : MonoBehaviour 
{
	public Transform toMatch;

	void Update () 
	{
		transform.position = toMatch.position;
		transform.LookAt (Camera.main.transform.forward + transform.position);
	}
}
