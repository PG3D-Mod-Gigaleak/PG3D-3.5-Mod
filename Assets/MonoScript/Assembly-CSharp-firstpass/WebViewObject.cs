using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class WebViewObject : MonoBehaviour
{
	private Action<string> callback;

	private IntPtr webView;

	[DllImport("__Internal")]
	private static extern IntPtr _WebViewPlugin_Init(string gameObject);

	[DllImport("__Internal")]
	private static extern int _WebViewPlugin_Destroy(IntPtr instance);

	[DllImport("__Internal")]
	private static extern void _WebViewPlugin_SetMargins(IntPtr instance, int left, int top, int right, int bottom);

	[DllImport("__Internal")]
	private static extern void _WebViewPlugin_SetVisibility(IntPtr instance, bool visibility);

	[DllImport("__Internal")]
	private static extern void _WebViewPlugin_LoadURL(IntPtr instance, string url);

	[DllImport("__Internal")]
	private static extern void _WebViewPlugin_EvaluateJS(IntPtr instance, string url);

	[DllImport("__Internal")]
	private static extern void _WebViewPlugin_homeUrl(IntPtr instance);

	public void Init(Action<string> cb = null)
	{
		callback = cb;
		webView = _WebViewPlugin_Init(base.name);
	}

	private void OnDestroy()
	{
		if (!(webView == IntPtr.Zero))
		{
			_WebViewPlugin_Destroy(webView);
		}
	}

	public void SetMargins(int left, int top, int right, int bottom)
	{
		if (!(webView == IntPtr.Zero))
		{
			_WebViewPlugin_SetMargins(webView, left, top, right, bottom);
		}
	}

	public void SetVisibility(bool v)
	{
		if (!(webView == IntPtr.Zero))
		{
			_WebViewPlugin_SetVisibility(webView, v);
		}
	}

	public void LoadURL(string url)
	{
		if (!(webView == IntPtr.Zero))
		{
			_WebViewPlugin_LoadURL(webView, url);
		}
	}

	public void EvaluateJS(string js)
	{
		if (!(webView == IntPtr.Zero))
		{
			_WebViewPlugin_EvaluateJS(webView, js);
		}
	}

	public void CallFromJS(string message)
	{
		if (callback != null)
		{
			callback(message);
		}
	}

	public void goHome()
	{
		if (!(webView == IntPtr.Zero))
		{
			_WebViewPlugin_homeUrl(webView);
		}
	}
}
