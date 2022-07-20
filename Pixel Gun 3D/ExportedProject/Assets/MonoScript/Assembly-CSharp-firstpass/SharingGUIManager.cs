using System;
using System.IO;
using System.Runtime.CompilerServices;
using Prime31;
using UnityEngine;

public class SharingGUIManager : MonoBehaviourGUI
{
	public static string screenshotFilename = "someScreenshot.png";

	[CompilerGenerated]
	private static Action<string> _003C_003Ef__am_0024cache1;

	[CompilerGenerated]
	private static Action _003C_003Ef__am_0024cache2;

	private void Start()
	{
		if (_003C_003Ef__am_0024cache1 == null)
		{
			_003C_003Ef__am_0024cache1 = _003CStart_003Em__B;
		}
		SharingManager.sharingFinishedWithActivityTypeEvent += _003C_003Ef__am_0024cache1;
		if (_003C_003Ef__am_0024cache2 == null)
		{
			_003C_003Ef__am_0024cache2 = _003CStart_003Em__C;
		}
		SharingManager.sharingCancelledEvent += _003C_003Ef__am_0024cache2;
		ScreenCapture.CaptureScreenshot(screenshotFilename);
	}

	private void OnGUI()
	{
		beginColumn();
		if (GUILayout.Button("Share URL and Text"))
		{
			SharingBinding.shareItems(new string[2] { "http://prime31.com", "Here is some text with the URL" });
		}
		if (GUILayout.Button("Share Screenshot"))
		{
			string text = Path.Combine(Application.persistentDataPath, screenshotFilename);
			if (!File.Exists(text))
			{
				Debug.LogError("there is no screenshot avaialable at path: " + text);
				return;
			}
			SharingBinding.shareItems(new string[1] { text });
		}
		if (GUILayout.Button("Share Screenshot and Text"))
		{
			string text2 = Path.Combine(Application.persistentDataPath, screenshotFilename);
			if (!File.Exists(text2))
			{
				Debug.LogError("there is no screenshot avaialable at path: " + text2);
				return;
			}
			SharingBinding.shareItems(new string[2] { text2, "Here is some text with the image" });
		}
		endColumn();
		if (bottomRightButton("Facebook..."))
		{
			Application.LoadLevel("FacebookTestScene");
		}
	}

	[CompilerGenerated]
	private static void _003CStart_003Em__B(string activityType)
	{
		Debug.Log("sharingFinishedWithActivityTypeEvent: " + activityType);
	}

	[CompilerGenerated]
	private static void _003CStart_003Em__C()
	{
		Debug.Log("sharingCancelledEvent");
	}
}
