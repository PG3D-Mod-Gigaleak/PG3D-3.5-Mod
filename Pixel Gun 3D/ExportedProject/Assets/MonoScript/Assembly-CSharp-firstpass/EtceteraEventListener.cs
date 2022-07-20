using System.Collections;
using Prime31;
using UnityEngine;

public class EtceteraEventListener : MonoBehaviour
{
	private void OnEnable()
	{
		EtceteraManager.dismissingViewControllerEvent += dismissingViewControllerEvent;
		EtceteraManager.imagePickerCancelledEvent += imagePickerCancelled;
		EtceteraManager.imagePickerChoseImageEvent += imagePickerChoseImage;
		EtceteraManager.saveImageToPhotoAlbumSucceededEvent += saveImageToPhotoAlbumSucceededEvent;
		EtceteraManager.saveImageToPhotoAlbumFailedEvent += saveImageToPhotoAlbumFailedEvent;
		EtceteraManager.alertButtonClickedEvent += alertButtonClicked;
		EtceteraManager.promptCancelledEvent += promptCancelled;
		EtceteraManager.singleFieldPromptTextEnteredEvent += singleFieldPromptTextEntered;
		EtceteraManager.twoFieldPromptTextEnteredEvent += twoFieldPromptTextEntered;
		EtceteraManager.remoteRegistrationSucceededEvent += remoteRegistrationSucceeded;
		EtceteraManager.remoteRegistrationFailedEvent += remoteRegistrationFailed;
		EtceteraManager.pushIORegistrationCompletedEvent += pushIORegistrationCompletedEvent;
		EtceteraManager.urbanAirshipRegistrationSucceededEvent += urbanAirshipRegistrationSucceeded;
		EtceteraManager.urbanAirshipRegistrationFailedEvent += urbanAirshipRegistrationFailed;
		EtceteraManager.remoteNotificationReceivedEvent += remoteNotificationReceived;
		EtceteraManager.remoteNotificationReceivedAtLaunchEvent += remoteNotificationReceivedAtLaunch;
		EtceteraManager.localNotificationWasReceivedAtLaunchEvent += localNotificationWasReceivedAtLaunchEvent;
		EtceteraManager.localNotificationWasReceivedEvent += localNotificationWasReceivedEvent;
		EtceteraManager.mailComposerFinishedEvent += mailComposerFinished;
		EtceteraManager.smsComposerFinishedEvent += smsComposerFinished;
	}

	private void OnDisable()
	{
		EtceteraManager.dismissingViewControllerEvent += dismissingViewControllerEvent;
		EtceteraManager.imagePickerCancelledEvent -= imagePickerCancelled;
		EtceteraManager.imagePickerChoseImageEvent -= imagePickerChoseImage;
		EtceteraManager.saveImageToPhotoAlbumSucceededEvent -= saveImageToPhotoAlbumSucceededEvent;
		EtceteraManager.saveImageToPhotoAlbumFailedEvent -= saveImageToPhotoAlbumFailedEvent;
		EtceteraManager.alertButtonClickedEvent -= alertButtonClicked;
		EtceteraManager.promptCancelledEvent -= promptCancelled;
		EtceteraManager.singleFieldPromptTextEnteredEvent -= singleFieldPromptTextEntered;
		EtceteraManager.twoFieldPromptTextEnteredEvent -= twoFieldPromptTextEntered;
		EtceteraManager.remoteRegistrationSucceededEvent -= remoteRegistrationSucceeded;
		EtceteraManager.remoteRegistrationFailedEvent -= remoteRegistrationFailed;
		EtceteraManager.pushIORegistrationCompletedEvent -= pushIORegistrationCompletedEvent;
		EtceteraManager.urbanAirshipRegistrationSucceededEvent -= urbanAirshipRegistrationSucceeded;
		EtceteraManager.urbanAirshipRegistrationFailedEvent -= urbanAirshipRegistrationFailed;
		EtceteraManager.remoteNotificationReceivedAtLaunchEvent -= remoteNotificationReceivedAtLaunch;
		EtceteraManager.localNotificationWasReceivedAtLaunchEvent -= localNotificationWasReceivedAtLaunchEvent;
		EtceteraManager.localNotificationWasReceivedEvent -= localNotificationWasReceivedEvent;
		EtceteraManager.mailComposerFinishedEvent -= mailComposerFinished;
		EtceteraManager.smsComposerFinishedEvent -= smsComposerFinished;
	}

	private void dismissingViewControllerEvent()
	{
		Debug.Log("dismissingViewControllerEvent");
	}

	private void imagePickerCancelled()
	{
		Debug.Log("imagePickerCancelled");
	}

	private void imagePickerChoseImage(string imagePath)
	{
		Debug.Log("image picker chose image: " + imagePath);
	}

	private void saveImageToPhotoAlbumSucceededEvent()
	{
		Debug.Log("saveImageToPhotoAlbumSucceededEvent");
	}

	private void saveImageToPhotoAlbumFailedEvent(string error)
	{
		Debug.Log("saveImageToPhotoAlbumFailedEvent: " + error);
	}

	private void alertButtonClicked(string text)
	{
		Debug.Log("alert button clicked: " + text);
	}

	private void promptCancelled()
	{
		Debug.Log("promptCancelled");
	}

	private void singleFieldPromptTextEntered(string text)
	{
		Debug.Log("field : " + text);
	}

	private void twoFieldPromptTextEntered(string textOne, string textTwo)
	{
		Debug.Log("field one: " + textOne + ", field two: " + textTwo);
	}

	private void remoteRegistrationSucceeded(string deviceToken)
	{
		Debug.Log("remoteRegistrationSucceeded with deviceToken: " + deviceToken);
	}

	private void remoteRegistrationFailed(string error)
	{
		Debug.Log("remoteRegistrationFailed : " + error);
	}

	private void pushIORegistrationCompletedEvent(string error)
	{
		if (error != null)
		{
			Debug.Log("pushIORegistrationCompletedEvent failed with error: " + error);
		}
		else
		{
			Debug.Log("pushIORegistrationCompletedEvent successful");
		}
	}

	private void urbanAirshipRegistrationSucceeded()
	{
		Debug.Log("urbanAirshipRegistrationSucceeded");
	}

	private void urbanAirshipRegistrationFailed(string error)
	{
		Debug.Log("urbanAirshipRegistrationFailed : " + error);
	}

	private void remoteNotificationReceived(IDictionary notification)
	{
		Debug.Log("remoteNotificationReceived");
		Utils.logObject(notification);
	}

	private void remoteNotificationReceivedAtLaunch(IDictionary notification)
	{
		Debug.Log("remoteNotificationReceivedAtLaunch");
		Utils.logObject(notification);
	}

	private void localNotificationWasReceivedEvent(IDictionary notification)
	{
		Debug.Log("localNotificationWasReceivedEvent");
		Utils.logObject(notification);
	}

	private void localNotificationWasReceivedAtLaunchEvent(IDictionary notification)
	{
		Debug.Log("localNotificationWasReceivedAtLaunchEvent");
		Utils.logObject(notification);
	}

	private void mailComposerFinished(string result)
	{
		Debug.Log("mailComposerFinished : " + result);
	}

	private void smsComposerFinished(string result)
	{
		Debug.Log("smsComposerFinished : " + result);
	}
}
