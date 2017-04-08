using UnityEngine;
using System.Collections;

/**
 * This is the OffSetAnimation sript attached to our InsideCube's CubeFrame object in
 * the InsideCubeExample scene.
 * It's used to constantly adjust the object's material offset for a nice effect
 * when the cube is tracked.
 **/
public class OffSetAnimation : MonoBehaviour 
{
	Vector2 offSetSpeed = new Vector2(0f,1.5f);
	Vector2 offSetValue = Vector2.zero;

	bool isAnimating = false;

	void Start () 
	{
		Invoke ("StartAnimation", 1f);
	}

	//We use the update function to adjust the material's offset every frame.
	void Update () 
	{
		if (isAnimating) 
		{
			offSetValue -= offSetSpeed * Time.deltaTime;
			GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", offSetValue);

			//Once we've reached the end of our material, we call HandleAnimationComplete 
			//to reset the necessary values in order to repeat the animation.
			if ( Mathf.Abs( offSetValue.y )>= 1f) 
			{
				HandleAnimationComplete ();
			}
		}
	}

	void HandleAnimationComplete()
	{
		isAnimating = false;
		offSetValue = Vector2.one;
		GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", offSetValue);
		Invoke ("StartAnimation", Random.Range(1f,3f));
	}

	void StartAnimation()
	{
		isAnimating = true;
	}


}
