using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This is the FireworkManager script attached to the FireworksManager 
 * object within the FireworksDemo scene.
 * 
 * It provides simple controls for our Cube_FireworksCrate and plays 
 * particle and sound effects on user input.
 * 
 **/
[RequireComponent(typeof (AudioSource))]
public class FireworkManager : MonoBehaviour 
{
	//Thi is the scene's BasicTrackableEventHandler script that we
	//use to determine when the cube is and isn't being tracked.
	public BasicTrackableEventHandler imageTarget;

	public Transform headTransform;
	public ParticleSystem fireworkEmitter;
	public AudioClip fireworkSFX;

	private AudioSource audSource;

	void Start()
	{
		audSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		//Since the phone screen is used to interface between the user and the program,
		//typical tap controls can be called.
		if ( Input.GetMouseButtonDown(0) && imageTarget.isTracking )
		{
			ShootFirework();
		}
	}

	void LateUpdate()
	{
		//The firework emitter needs to have the same position and rotation as the cube 
		//so that it will look like the fireworks are coming out of the top of the box.

		//However, we can't parent the fireworks to the cube because we want the fireworks 
		//to still be visibile even when tracking is lost. So we will do a "soft"
		//parenting by just manually setting it's position and rotation.

		fireworkEmitter.transform.parent.position = imageTarget.transform.position;
		fireworkEmitter.transform.parent.rotation = imageTarget.transform.rotation;
	}

	public void ShootFirework()
	{
		fireworkEmitter.Emit(1);

		if (fireworkSFX != null)
		{
			audSource.PlayOneShot(fireworkSFX);
		}
	}
}
