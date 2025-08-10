using System.Collections;
using System.Collections.Generic;
using Prime31;

public class P31Prefs
{
	private static bool _iCloudDocumentStoreAvailable;

	public static bool iCloudDocumentStoreAvailable
	{
		get
		{
			return _iCloudDocumentStoreAvailable;
		}
	}

	static P31Prefs()
	{
		_iCloudDocumentStoreAvailable = iCloudBinding.documentStoreAvailable();
	}

	public static bool synchronize()
	{
		return iCloudBinding.synchronize();
	}

	public static bool hasKey(string key)
	{
		return iCloudBinding.hasKey(key);
	}

	public static List<object> allKeys()
	{
		return iCloudBinding.allKeys();
	}

	public static void removeObjectForKey(string key)
	{
		iCloudBinding.removeObjectForKey(key);
	}

	public static void removeAll()
	{
		iCloudBinding.removeAll();
	}

	public static void setInt(string key, int val)
	{
		iCloudBinding.setInt(val, key);
	}

	public static int getInt(string key)
	{
		return iCloudBinding.intForKey(key);
	}

	public static void setFloat(string key, float val)
	{
		iCloudBinding.setDouble(val, key);
	}

	public static float getFloat(string key)
	{
		return iCloudBinding.doubleForKey(key);
	}

	public static void setString(string key, string val)
	{
		iCloudBinding.setString(val, key);
	}

	public static string getString(string key)
	{
		return iCloudBinding.stringForKey(key);
	}

	public static void setBool(string key, bool val)
	{
		iCloudBinding.setBool(val, key);
	}

	public static bool getBool(string key)
	{
		return iCloudBinding.boolForKey(key);
	}

	public static void setDictionary(string key, Hashtable val)
	{
		string dict = Json.jsonEncode(val);
		iCloudBinding.setDictionary(dict, key);
	}

	public static IDictionary getDictionary(string key)
	{
		return iCloudBinding.dictionaryForKey(key);
	}
}
