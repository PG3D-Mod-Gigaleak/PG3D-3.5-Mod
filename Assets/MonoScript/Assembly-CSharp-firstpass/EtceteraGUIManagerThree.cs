using Prime31;
using UnityEngine;

public class EtceteraGUIManagerThree : MonoBehaviourGUI
{
	private void OnGUI()
	{
		beginColumn();
		if (GUILayout.Button("Show Inline WebView"))
		{
			EtceteraBinding.inlineWebViewShow(50, 10, 260, 300);
			EtceteraBinding.inlineWebViewSetUrl("http://google.com");
		}
		if (GUILayout.Button("Close Inline WebView"))
		{
			EtceteraBinding.inlineWebViewClose();
		}
		if (GUILayout.Button("Set Url of Inline WebView"))
		{
			EtceteraBinding.inlineWebViewSetUrl("http://prime31.com");
		}
		if (GUILayout.Button("Set Frame of Inline WebView"))
		{
			EtceteraBinding.inlineWebViewSetFrame(10, 200, 250, 250);
		}
		endColumn(true);
		if (GUILayout.Button("Get Badge Count"))
		{
			Debug.Log("badge count is: " + EtceteraBinding.getBadgeCount());
		}
		if (GUILayout.Button("Set Badge Count"))
		{
			EtceteraBinding.setBadgeCount(46);
		}
		if (GUILayout.Button("Get Orientation"))
		{
			UIInterfaceOrientation statusBarOrientation = EtceteraBinding.getStatusBarOrientation();
			Debug.Log("status bar orientation: " + statusBarOrientation);
		}
		endColumn();
		if (bottomRightButton("Back"))
		{
			Application.LoadLevel("EtceteraTestScene");
		}
	}
}
