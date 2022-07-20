using UnityEngine;

public class Storager
{
	private static bool iCloudAvailable;

	static Storager()
	{
		P31Prefs.hasKey("abc123");
	}

	public static void Initialize(bool _cloudAvailable)
	{
		iCloudAvailable = _cloudAvailable;
	}

	public static void setInt(string key, int val)
	{
		if (iCloudAvailable)
		{
			iCloudBinding.setInt(val, key);
		}
		keychainPlugin.createKCValue(val, key);
		keychainPlugin.updateKCValue(val, key);
	}

	public static int getInt(string key)
	{
		int a = ((iCloudAvailable && iCloudBinding.hasKey(key)) ? iCloudBinding.intForKey(key) : 0);
		return Mathf.Max(a, keychainPlugin.getKCValue(key));
	}
}
