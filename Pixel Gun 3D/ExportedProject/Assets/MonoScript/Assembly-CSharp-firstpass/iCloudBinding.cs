using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Prime31;
using UnityEngine;

public class iCloudBinding
{
	[DllImport("__Internal")]
	private static extern bool _iCloudSynchronize();

	public static bool synchronize()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudSynchronize();
		}
		return false;
	}

	[DllImport("__Internal")]
	private static extern string _iCloudUbiquityIdentityToken();

	public static string getUbiquityIdentityToken()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudUbiquityIdentityToken();
		}
		return string.Empty;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudRemoveObjectForKey(string key);

	public static void removeObjectForKey(string aKey)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_iCloudRemoveObjectForKey(aKey);
		}
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudHasKey(string key);

	public static bool hasKey(string key)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudHasKey(key);
		}
		return false;
	}

	[DllImport("__Internal")]
	private static extern string _iCloudStringForKey(string key);

	public static string stringForKey(string key)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudStringForKey(key);
		}
		return string.Empty;
	}

	[DllImport("__Internal")]
	private static extern string _iCloudAllKeys();

	public static List<object> allKeys()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudAllKeys().listFromJson();
		}
		return new List<object>();
	}

	[DllImport("__Internal")]
	private static extern void _iCloudRemoveAll();

	public static void removeAll()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_iCloudRemoveAll();
		}
	}

	[DllImport("__Internal")]
	private static extern void _iCloudSetString(string aString, string aKey);

	public static void setString(string aString, string aKey)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_iCloudSetString(aString, aKey);
		}
	}

	[DllImport("__Internal")]
	private static extern string _iCloudDictionaryForKey(string aKey);

	public static IDictionary dictionaryForKey(string aKey)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudDictionaryForKey(aKey).dictionaryFromJson();
		}
		return new Hashtable();
	}

	[DllImport("__Internal")]
	private static extern void _iCloudSetDictionary(string dict, string aKey);

	public static void setDictionary(string dict, string aKey)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_iCloudSetDictionary(dict, aKey);
		}
	}

	[DllImport("__Internal")]
	private static extern float _iCloudDoubleForKey(string aKey);

	public static float doubleForKey(string aKey)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudDoubleForKey(aKey);
		}
		return 0f;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudSetDouble(double value, string aKey);

	public static void setDouble(double value, string aKey)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_iCloudSetDouble(value, aKey);
		}
	}

	[DllImport("__Internal")]
	private static extern int _iCloudIntForKey(string aKey);

	public static int intForKey(string aKey)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudIntForKey(aKey);
		}
		return 0;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudSetInt(int value, string aKey);

	public static void setInt(int value, string aKey)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_iCloudSetInt(value, aKey);
		}
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudBoolForKey(string aKey);

	public static bool boolForKey(string aKey)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudBoolForKey(aKey);
		}
		return false;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudSetBool(bool value, string aKey);

	public static void setBool(bool value, string aKey)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_iCloudSetBool(value, aKey);
		}
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudDocumentStoreAvailable();

	public static bool documentStoreAvailable()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudDocumentStoreAvailable();
		}
		return false;
	}

	[DllImport("__Internal")]
	private static extern string _iCloudDocumentsDirectory();

	public static string documentsDirectory()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudDocumentsDirectory();
		}
		return string.Empty;
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudIsFileInCloud(string file);

	public static bool isFileInCloud(string file)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudIsFileInCloud(file);
		}
		return false;
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudIsFileDownloaded(string file);

	public static bool isFileDownloaded(string file)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudIsFileDownloaded(file);
		}
		return false;
	}

	[DllImport("__Internal")]
	private static extern bool _iCloudAddFile(string file);

	public static bool addFile(string file)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return _iCloudAddFile(file);
		}
		return false;
	}

	[DllImport("__Internal")]
	private static extern void _iCloudEvictFile(string file);

	public static void evictFile(string file)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			_iCloudEvictFile(file);
		}
	}
}
