using System;
using System.Runtime.CompilerServices;
using Prime31;
using UnityEngine;

public class EtceteraGUIManager : MonoBehaviourGUI
{
	[CompilerGenerated]
	private static Action<string> _003C_003Ef__am_0024cache0;

	private void Start()
	{
		EtceteraBinding.setPopoverPoint(500f, 200f);
	}

	private void OnGUI()
	{
		beginColumn();
		if (GUILayout.Button("Get Current Language"))
		{
			Debug.Log("current launguage: " + EtceteraBinding.getCurrentLanguage());
		}
		if (GUILayout.Button("Get Locale Info for Keys"))
		{
			Debug.Log("currency symbol: " + EtceteraBinding.localeObjectForKey(true, "kCFLocaleCurrencySymbolKey"));
			Debug.Log("country code: " + EtceteraBinding.localeObjectForKey(true, "kCFLocaleCountryCodeKey"));
		}
		if (GUILayout.Button("Get Localized String"))
		{
			string localizedString = EtceteraBinding.getLocalizedString("hello", "hello in English");
			Debug.Log("'hello' localized: " + localizedString);
		}
		if (GUILayout.Button("Alert with one Button"))
		{
			string[] buttons = new string[1] { "OK" };
			EtceteraBinding.showAlertWithTitleMessageAndButtons("This is the title", "You should really read this before pressing OK", buttons);
		}
		if (GUILayout.Button("Alert with three Buttons"))
		{
			string[] buttons2 = new string[3] { "OK", "In The Middle", "Cancel" };
			EtceteraBinding.showAlertWithTitleMessageAndButtons("This is another title", "You should really read this before pressing a button", buttons2);
		}
		if (GUILayout.Button("Show Prompt with 1 Field"))
		{
			EtceteraBinding.showPromptWithOneField("Enter your name", "This is the name of the main character", "name", false);
		}
		endColumn(true);
		if (GUILayout.Button("Show Prompt with 2 Fields"))
		{
			EtceteraBinding.showPromptWithTwoFields("Enter your credentials", string.Empty, "username", "password", false);
		}
		if (GUILayout.Button("Open Web Page"))
		{
			EtceteraBinding.showWebPage("http://www.prime31.com", true);
		}
		if (GUILayout.Button("Show Mail Composer"))
		{
			EtceteraBinding.showMailComposer("support@somecompany.com", "Tell us what you think", "I <b>really</b> like this game!", true);
		}
		if (GUILayout.Button("Show SMS Composer") && EtceteraBinding.isSMSAvailable())
		{
			EtceteraBinding.showSMSComposer("some text to prefill the message with");
		}
		if (GUILayout.Button("Mail Composer with Screenshot"))
		{
			StartCoroutine(EtceteraBinding.showMailComposerWithScreenshot(null, "Game Screenshot", "I like this game!", false));
		}
		if (GUILayout.Button("Take Screen Shot"))
		{
			if (_003C_003Ef__am_0024cache0 == null)
			{
				_003C_003Ef__am_0024cache0 = _003COnGUI_003Em__2;
			}
			StartCoroutine(EtceteraBinding.takeScreenShot("someScreenshot.png", _003C_003Ef__am_0024cache0));
		}
		endColumn();
		if (bottomRightButton("Next Scene"))
		{
			Application.LoadLevel("EtceteraTestSceneTwo");
		}
	}

	[CompilerGenerated]
	private static void _003COnGUI_003Em__2(string imagePath)
	{
		Debug.Log("Screenshot taken and saved to: " + imagePath);
	}
}
