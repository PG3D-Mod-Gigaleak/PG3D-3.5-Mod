using System.Runtime.InteropServices;
using UnityEngine;

public class keychainPlugin
{
	[DllImport("__Internal")]
	private static extern bool createKeychainValue(string pass, string iden);

	[DllImport("__Internal")]
	private static extern bool updateKeychainValue(string pass, string iden);

	[DllImport("__Internal")]
	private static extern void deleteKeychainValue(string iden);

	[DllImport("__Internal")]
	private static extern string getKeychainValue(string iden);

	public static int getKCValue(string id)
	{
		int result = 0;
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			result = int.Parse(getKeychainValue(id));
		}
		return result;
	}

	public static bool createKCValue(int val, string id)
	{
		bool result = false;
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			result = createKeychainValue(val.ToString(), id);
		}
		return result;
	}

	public static bool createKCValue(string val, string id)
	{
		bool result = false;
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			result = createKeychainValue(val, id);
		}
		return result;
	}

	public static bool updateKCValue(int val, string id)
	{
		bool result = false;
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			result = updateKeychainValue(val.ToString(), id);
		}
		return result;
	}

	public static bool updateKCValue(string val, string id)
	{
		bool result = false;
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			result = updateKeychainValue(val, id);
		}
		return result;
	}

	public static void deleteKCValue(string id)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			deleteKeychainValue(id);
		}
	}
}
