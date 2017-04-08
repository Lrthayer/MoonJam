using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merge
{
	/**
	 * How to use: 
	 * Call this script's OrientateToCamera function from another script by using the proper namespace:
	 * Merge.CubeOrientation.OrientateToCamera (Transform imageTargetLocation, Transform target);
	 * 
	 * Orientates an object to face toward the side physically located closest towards the Camera.
	 * 
	 **/
	public class CubeOrientation : MonoBehaviour 
		{
		/// <summary>
		/// Orientates to camera.
		/// </summary>
		/// <param name="imageTargetLocation">Image target loation.Use MultiTarget if no special use.</param>
		/// <param name="target">The root of your Model or Obj that you want to have face the side closest to the camera</param>
		public static void OrientateToCamera(Transform imageTargetLocation, Transform target)
		{
			int comboX = -1;
			int comboY1 = -1;
			int comboY2 = 0;
			float distance1 = 1000f;
			float distance2 = 1000f;
			Vector3 cameraPosition = Camera.main.transform.position;
			Vector3[] toCompare = new Vector3[checkPoints.Length];
			Vector3 frontPos =  new Vector3 (cameraPosition.x, imageTargetLocation.position.y, cameraPosition.z);
			Vector3 topPos =  new Vector3 (imageTargetLocation.position.x, imageTargetLocation.position.y + 10f, imageTargetLocation.position.z);

			for(int i=0;i<checkPoints.Length;i++)
			{
				toCompare [i] = imageTargetLocation.TransformPoint( checkPoints [i] );
				float distanceTransformPoint = Vector3.Distance (frontPos, toCompare[i]);
				if (distance1 > distanceTransformPoint) 
					{
					distance1 = distanceTransformPoint;
					comboX = i;
				}
				distanceTransformPoint = Vector3.Distance (topPos, toCompare[i]);
				if (distance2 > distanceTransformPoint) 
					{
					distance2 = distanceTransformPoint;
					comboY2 = comboY1;
					comboY1 = i;
				}
			}

			if (!SetRotation (comboX * 10 + comboY1, target)) 
			{
				SetRotation (comboX * 10 + comboY2, target);
			}
		}

		static Vector3 [] checkPoints = new [] {  new Vector3(0f,0f,-0.1f), new Vector3(-0.1f,0f,0f), new Vector3(0f,0f,0.1f),
			new Vector3(0.1f,0f,0f), new Vector3(0f,0.1f,0f), new Vector3(0f,-0.1f,0f) };


		static bool SetRotation(int combo, Transform toSet)
			{
			Vector3 setValue = Vector3.zero;
			switch (combo) {
			case 04:
				break;
			case 01:
				setValue.z = 90f;
				break;
			case 05:
				setValue.z = 180f;
				break;
			case 03:
				setValue.z = 270f;
				break;

			case 14:
				setValue.y = 90f;
				break;
			case 12:
				setValue.y = 90f;
				setValue.z = 90f;
				break;
			case 15:
				setValue.y = 90f;
				setValue.z = 180f;
				break;
			case 10:
				setValue.y = 90f;
				setValue.z = 270f;
				break;


			case 24:
				setValue.y = 180f;
				break;
			case 23:
				setValue.y = 180f;
				setValue.z = 90f;
				break;
			case 25:
				setValue.y = 180f;
				setValue.z = 180f;
				break;
			case 21:
				setValue.y = 180f;
				setValue.z = 270f;
				break;

			case 34:
				setValue.y = 270f;
				break;
			case 30:
				setValue.y = 270f;
				setValue.z = 90f;
				break;
			case 35:
				setValue.y = 270f;
				setValue.z = 180f;
				break;
			case 32:
				setValue.y = 270f;
				setValue.z = 270f;
				break;

			case 42:
				setValue.x = 90f;
				break;
			case 41:
				setValue.x = 90f;
				setValue.z = 90f;
				break;
			case 40:
				setValue.x = 90f;
				setValue.z = 180f;
				break;
			case 43:
				setValue.x = 90f;
				setValue.z = 270f;
				break;

			case 50:
				setValue.x = 270f;
				break;
			case 51:
				setValue.x = 270f;
				setValue.z = 90f;
				break;
			case 52:
				setValue.x = 270f;
				setValue.z = 180f;
				break;
			case 53:
				setValue.x = 270f;
				setValue.z = 270f;
				break;

			default:
				return false;
			}
			toSet.localEulerAngles = setValue;
			return true;
		}
	}
}
