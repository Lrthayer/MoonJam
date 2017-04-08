using UnityEngine;
using System.Collections;

/**
 * This is the SmallCubeMove class attached to our Cube_Small_Faces and 
 * Particle objects in our InsideCubeExample scene.
 * 
 * This script rotates the object it's attached to on all three axes, 
 * constantly updating their rotation, rotational strengths, and rotational
 * directions.
 **/
public class SmallCubeMove : MonoBehaviour 
{
	bool rotateAroundX = true;
	bool rotateAroundY = true;
	bool rotateAroundZ = true;

	public float rotateXSpeed = 1f;
	public float rotateYSpeed = -1f;
	public float rotateZSpeed = 0f;

	public float rotateSpeed = 37f;

	void Update () 
	{
		RotateChange ();
		transform.RotateAround (transform.position,new Vector3(rotateXSpeed, rotateYSpeed, rotateZSpeed), rotateSpeed * Time.deltaTime);
	}
		
	//This function updates the object's rotational speeds and directions on all axes.
	//By checking the speed values, we can update each of the flags to inverse their 
	//rotational directions.
	void RotateChange()
	{
		if (rotateAroundX)
		{
			rotateXSpeed += 0.5f*Time.deltaTime;

			if (rotateXSpeed >= 1f) 
			{
				rotateXSpeed = 1f;
				rotateAroundX = false;
			}
		} 
		else 
		{
			rotateXSpeed -= 0.5f*Time.deltaTime;

			if (rotateXSpeed <= -1f) 
			{
				rotateXSpeed = -1f;
				rotateAroundX = true;
			}
		}

		if (rotateAroundY) 
		{
			rotateYSpeed += 0.5f*Time.deltaTime;

			if (rotateYSpeed >= 1f) 
			{
				rotateYSpeed = 1f;
				rotateAroundY = false;
			}
		} 
		else 
		{
			rotateYSpeed -= 0.5f*Time.deltaTime;

			if (rotateYSpeed <= -1f) 
			{
				rotateYSpeed = -1f;
				rotateAroundY = true;
			}
		}

		if (rotateAroundZ) 
		{
			rotateZSpeed += 0.5f*Time.deltaTime;
			if (rotateZSpeed >= 1f) 
			{
				rotateZSpeed = 1f;
				rotateAroundZ = false;
			}
		} 
		else 
		{
			rotateZSpeed -= 0.5f*Time.deltaTime;

			if (rotateZSpeed <= -1f) 
			{
				rotateZSpeed = -1f;
				rotateAroundZ = true;
			}
		}
	}

}
