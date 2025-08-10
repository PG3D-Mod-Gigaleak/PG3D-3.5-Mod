using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class NerdFlurry : MonoBehaviour
{
	[DllImport("__Internal", CharSet = CharSet.Ansi)]
	private static extern void NerdFlurry_startSession([In][MarshalAs(UnmanagedType.LPStr)] string apiKey);

	[DllImport("__Internal")]
	private static extern void NerdFlurry_setShowErrorInLogEnabled(bool bEnabled);

	[DllImport("__Internal")]
	private static extern void NerdFlurry_setDebugLogEnabled(bool bEnabled);

	[DllImport("__Internal")]
	private static extern void NerdFlurry_setEventLoggingEnabled(bool bEnabled);

	[DllImport("__Internal")]
	private static extern void NerdFlurry_setSessionReportsOnCloseEnabled(bool bEnabled);

	[DllImport("__Internal")]
	private static extern void NerdFlurry_setSessionReportsOnPauseEnabled(bool bEnabled);

	[DllImport("__Internal")]
	private static extern void NerdFlurry_setAge(int age);

	[DllImport("__Internal", CharSet = CharSet.Ansi)]
	private static extern void NerdFlurry_setAppVersion([In][MarshalAs(UnmanagedType.LPStr)] string version);

	[DllImport("__Internal")]
	private static extern void NerdFlurry_setSessionContinueSeconds(int seconds);

	[DllImport("__Internal", CharSet = CharSet.Ansi)]
	private static extern void NerdFlurry_setUserID([In][MarshalAs(UnmanagedType.LPStr)] string userId);

	[DllImport("__Internal", CharSet = CharSet.Ansi)]
	private static extern void NerdFlurry_logEvent([In][MarshalAs(UnmanagedType.LPStr)] string evendId);

	[DllImport("__Internal", CharSet = CharSet.Ansi)]
	private static extern void NerdFlurry_logEventWithParameters([In][MarshalAs(UnmanagedType.LPStr)] string evendId, [In][MarshalAs(UnmanagedType.LPStr)] string parameters);

	[DllImport("__Internal", CharSet = CharSet.Ansi)]
	private static extern void NerdFlurry_logEventWithParametersTimed([In][MarshalAs(UnmanagedType.LPStr)] string evendId, [In][MarshalAs(UnmanagedType.LPStr)] string parameters);

	[DllImport("__Internal", CharSet = CharSet.Ansi)]
	private static extern void NerdFlurry_logEventTimed([In][MarshalAs(UnmanagedType.LPStr)] string evendId);

	[DllImport("__Internal", CharSet = CharSet.Ansi)]
	private static extern void NerdFlurry_endTimedEvent([In][MarshalAs(UnmanagedType.LPStr)] string evendId);

	public void StartSession(string API_KEY)
	{
		NerdFlurry_setDebugLogEnabled(true);
		NerdFlurry_setShowErrorInLogEnabled(true);
		NerdFlurry_setEventLoggingEnabled(true);
		NerdFlurry_startSession(API_KEY);
	}

	public void EndSession()
	{
	}

	public int GetAgentVersion()
	{
		return 0;
	}

	public void LogEvent(string eventId, bool timed = false)
	{
		if (!timed)
		{
			NerdFlurry_logEvent(eventId);
		}
		else
		{
			NerdFlurry_logEventTimed(eventId);
		}
	}

	public void LogEvent(string eventId, Dictionary<string, string> parameters, bool timed = false)
	{
		string text = string.Empty;
		foreach (KeyValuePair<string, string> parameter in parameters)
		{
			string text2 = text;
			text = text2 + parameter.Key + "=" + parameter.Value + "\n";
		}
		if (!timed)
		{
			NerdFlurry_logEventWithParameters(eventId, text);
		}
		else
		{
			NerdFlurry_logEventWithParametersTimed(eventId, text);
		}
	}

	public void EndTimedEvent(string eventId)
	{
		NerdFlurry_endTimedEvent(eventId);
	}

	public void SetAge(int age)
	{
		NerdFlurry_setAge(age);
	}
}
