using System.Collections;
using Prime31;
using UnityEngine;

public class EtceteraGUIManagerTwo : MonoBehaviourGUI
{
	public GameObject testPlane;

	private string imagePath;

	private void Start()
	{
		EtceteraManager.imagePickerChoseImageEvent += imagePickerChoseImage;
	}

	private void OnDisable()
	{
		EtceteraManager.imagePickerChoseImageEvent -= imagePickerChoseImage;
	}

	private void OnGUI()
	{
		beginColumn();
		if (GUILayout.Button("Show Activity View"))
		{
			EtceteraBinding.showActivityView();
			StartCoroutine(hideActivityView());
		}
		if (GUILayout.Button("Show Bezel Activity View"))
		{
			EtceteraBinding.showBezelActivityViewWithLabel("Loading Stuff...");
			StartCoroutine(hideActivityView());
		}
		if (GUILayout.Button("Rate This App"))
		{
			EtceteraBinding.askForReview("Do you like this game?", "Please review the game if you do!", "366238041");
		}
		if (GUILayout.Button("Register for Push"))
		{
			EtceteraBinding.registerForRemoteNotifcations((P31RemoteNotificationType)7);
		}
		if (GUILayout.Button("Get Registered Push Types"))
		{
			P31RemoteNotificationType enabledRemoteNotificationTypes = EtceteraBinding.getEnabledRemoteNotificationTypes();
			if ((enabledRemoteNotificationTypes & P31RemoteNotificationType.Alert) != 0)
			{
				Debug.Log("registered for alerts");
			}
			if ((enabledRemoteNotificationTypes & P31RemoteNotificationType.Sound) != 0)
			{
				Debug.Log("registered for sounds");
			}
			if ((enabledRemoteNotificationTypes & P31RemoteNotificationType.Badge) != 0)
			{
				Debug.Log("registered for badges");
			}
		}
		endColumn(true);
		if (GUILayout.Button("Set Urban Airship Credentials"))
		{
			EtceteraBinding.setUrbanAirshipCredentials("S8Tf2CiUQSuh2A4NVdD2CA", "J6O97Dm2QK2-GGXZsPMlEA", "optional alias");
		}
		if (GUILayout.Button("Set Push.IO Credentials"))
		{
			EtceteraBinding.setPushIOCredentials("5VRVDMujew_a9UQ");
		}
		if (GUILayout.Button("Prompt for Photo"))
		{
			EtceteraBinding.promptForPhoto(0.25f, PhotoPromptType.CameraAndAlbum);
		}
		if (GUILayout.Button("Load Photo Texture"))
		{
			if (imagePath == null)
			{
				string[] buttons = new string[1] { "OK" };
				EtceteraBinding.showAlertWithTitleMessageAndButtons("Load Photo Texture Error", "You have to choose a photo before loading", buttons);
				return;
			}
			StartCoroutine(EtceteraManager.textureFromFileAtPath("file://" + imagePath, textureLoaded, textureLoadFailed));
		}
		if (GUILayout.Button("Save Photo to Album"))
		{
			if (imagePath == null)
			{
				string[] buttons2 = new string[1] { "OK" };
				EtceteraBinding.showAlertWithTitleMessageAndButtons("Load Photo Texture Error", "You have to choose a photo before loading", buttons2);
				return;
			}
			EtceteraBinding.saveImageToPhotoAlbum(imagePath);
		}
		if (GUILayout.Button("Get Image Size"))
		{
			if (imagePath == null)
			{
				string[] buttons3 = new string[1] { "OK" };
				EtceteraBinding.showAlertWithTitleMessageAndButtons("Error Getting Image Size", "You have to choose a photo before checking it's size", buttons3);
				return;
			}
			Vector2 imageSize = EtceteraBinding.getImageSize(imagePath);
			Debug.Log("image size: " + imageSize);
		}
		endColumn();
		if (bottomRightButton("Next"))
		{
			Application.LoadLevel("EtceteraTestSceneThree");
		}
	}

	private void imagePickerChoseImage(string imagePath)
	{
		this.imagePath = imagePath;
	}

	public IEnumerator hideActivityView()
	{
		yield return new WaitForSeconds(2f);
		EtceteraBinding.hideActivityView();
	}

	public void textureLoaded(Texture2D texture)
	{
		testPlane.GetComponent<Renderer>().material.mainTexture = texture;
	}

	public void textureLoadFailed(string error)
	{
		string[] buttons = new string[1] { "OK" };
		EtceteraBinding.showAlertWithTitleMessageAndButtons("Error Loading Texture.  Did you choose a photo first?", error, buttons);
		Debug.Log("textureLoadFailed: " + error);
	}
}
