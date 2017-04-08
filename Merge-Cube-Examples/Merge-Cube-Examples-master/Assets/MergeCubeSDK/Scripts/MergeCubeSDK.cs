using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

namespace Merge
{		
	public class MergeCubeSDK : MonoBehaviour 
	{
		private Transform arCameraRef;

		private VideoBackgroundBehaviour leftVidBackBehaviour;
		private VideoBackgroundBehaviour rightVidBackBehaviour;

		public GameObject doubleRenderSetup;
		//	public GameObject singleRenderSetup;
		public RenderTexture doubleViewRenderTexture;

		bool isActive = false;

		public UnityEngine.UI.Image fsSwitchButton;
		public UnityEngine.UI.Image fsSwitchGraphic;
		public Sprite fsSprite;
		public Sprite vrSprite;
		public Sprite disabledSprite;

		public bool isInDouble = false;

		public Animator mainPanelAnimator;
		bool menuIsOpen = false;

		void Start()
		{
			arCameraRef = Camera.main.transform;
			if (isInDouble)
			{
				Camera.main.targetTexture = doubleViewRenderTexture;
			}
		}

		public void ToggleMenu()
		{
			if (menuIsOpen)
			{
				mainPanelAnimator.Play("Close");
			}
			else
			{
				mainPanelAnimator.Play("Open");
			}

			menuIsOpen = !menuIsOpen;
		}

		public void SwitchView()
		{
			isInDouble = !isInDouble;

			if (isInDouble) 
			{
				SetToDoubleView ();
				fsSwitchGraphic.sprite = vrSprite;
			} 
			else 
			{
				SetToSingleView ();
				fsSwitchGraphic.sprite = fsSprite;
			}

			fsSwitchButton.gameObject.SetActive (false);
			Invoke ("EnableViewChangeBtn", 0.5f);
		}

		void EnableViewChangeBtn()
		{
			fsSwitchButton.gameObject.SetActive (true);
		}



		void SetToSingleView()
		{
			Camera.main.targetTexture = null;
	//		Camera.main.targetTexture = doubleViewRenderTexture;
			doubleRenderSetup.SetActive(false);
	//		singleRenderSetup.SetActive(true);
		}

		void SetToDoubleView()
		{
			Camera.main.targetTexture = doubleViewRenderTexture;
			doubleRenderSetup.SetActive(true);
	//		singleRenderSetup.SetActive(false);
		}


		public void SwapCameraFacingDirection()
		{
			Vuforia.CameraDevice.Instance.Stop();
			Vuforia.CameraDevice.Instance.Deinit();

			if (Vuforia.CameraDevice.Instance.GetCameraDirection() == Vuforia.CameraDevice.CameraDirection.CAMERA_BACK)
			{
				fsSwitchButton.raycastTarget = false;
				fsSwitchGraphic.sprite = disabledSprite;

				Vuforia.CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);

				//			Quaternion adjustedRotation = Quaternion.Euler(0f, 0f, 180f);
				//			Camera.main.transform.rotation = adjustedRotation;
				//			singleRenderSetup.transform.localScale = new Vector3(-1.325f, 1, 1);

				SetToSingleView();

				Debug.Log("Should be front: " + Vuforia.CameraDevice.Instance.GetCameraDirection());
			}
			else
			{
				fsSwitchButton.raycastTarget = true;

				Vuforia.CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_BACK);

				//			Camera.main.transform.rotation = Quaternion.identity;
				//			singleRenderSetup.transform.localScale = Vector3.one;

				if (isInDouble)
				{
					fsSwitchGraphic.sprite = vrSprite;
					SetToDoubleView();
				}
				else
				{
					fsSwitchGraphic.sprite = fsSprite;
					SetToSingleView();
				}

				Debug.Log("Should be back: " + Vuforia.CameraDevice.Instance.GetCameraDirection());
			}



			Vuforia.CameraDevice.Instance.Start();
		}

	//FlashLight
		public UnityEngine.UI.Image btnFlashLightSpritRef;
		bool isFlashOn = false;

		public void SwitchFlashLight()
		{
			isFlashOn = !isFlashOn;

			if (isFlashOn) 
			{
				TurnFlashOn ();
			} 
			else 
			{
				TurnFlashOff ();
			}
		}

		void TurnFlashOff()
		{
			Vuforia.CameraDevice.Instance.SetFlashTorchMode (false);
		}

		void TurnFlashOn()
		{
			Vuforia.CameraDevice.Instance.SetFlashTorchMode (true);
		}

		public void LoadScene( string sceneName )
		{
			SceneManager.LoadScene(sceneName);
		}

		bool sceneMenuIsOpen = false;
		public Animator scenePanelAnimator;

		public void ToggleSceneMenu()
		{
			if (sceneMenuIsOpen)
			{
				scenePanelAnimator.Play("Close");
			}
			else
			{
				scenePanelAnimator.Play("Open");
			}

			sceneMenuIsOpen = !sceneMenuIsOpen;

		}
	}
}