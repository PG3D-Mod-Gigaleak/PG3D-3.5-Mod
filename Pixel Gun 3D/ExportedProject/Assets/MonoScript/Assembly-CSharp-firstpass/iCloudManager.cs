using System;
using System.Collections.Generic;
using Prime31;

public class iCloudManager : AbstractManager
{
	public class iCloudDocument
	{
		public string filename;

		public bool isDownloaded;

		public DateTime contentChangedDate;

		public iCloudDocument(Dictionary<string, object> dict)
		{
			if (dict.ContainsKey("filename"))
			{
				filename = dict["filename"].ToString();
			}
			if (dict.ContainsKey("isDownloaded"))
			{
				isDownloaded = bool.Parse(dict["isDownloaded"].ToString());
			}
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			if (dict.ContainsKey("contentChangedDate"))
			{
				double value = double.Parse(dict["contentChangedDate"].ToString());
				contentChangedDate = dateTime.AddSeconds(value);
			}
		}

		public static List<iCloudDocument> fromJSON(string json)
		{
			List<object> list = json.listFromJson();
			List<iCloudDocument> list2 = new List<iCloudDocument>(list.Count);
			foreach (Dictionary<string, object> item in list)
			{
				list2.Add(new iCloudDocument(item));
			}
			return list2;
		}

		public override string ToString()
		{
			return string.Format("<iCloudDocument> filename: {0}, isDownloaded: {1}, contentChangedDate: {2}", filename, isDownloaded, contentChangedDate);
		}
	}

	public static event Action<List<object>> keyValueStoreDidChangeEvent;

	public static event Action ubiquityIdentityDidChangeEvent;

	public static event Action entitlementsMissingEvent;

	public static event Action<List<iCloudDocument>> documentStoreUpdatedEvent;

	static iCloudManager()
	{
		AbstractManager.initialize(typeof(iCloudManager));
	}

	private void ubiquityIdentityDidChange(string param)
	{
		iCloudManager.ubiquityIdentityDidChangeEvent.fire();
	}

	private void keyValueStoreDidChange(string param)
	{
		if (iCloudManager.keyValueStoreDidChangeEvent != null)
		{
			List<object> obj = param.listFromJson();
			iCloudManager.keyValueStoreDidChangeEvent(obj);
		}
	}

	private void entitlementsMissing(string empty)
	{
		if (iCloudManager.entitlementsMissingEvent != null)
		{
			iCloudManager.entitlementsMissingEvent();
		}
	}

	private void documentStoreUpdated(string json)
	{
		if (iCloudManager.documentStoreUpdatedEvent != null)
		{
			List<iCloudDocument> obj = iCloudDocument.fromJSON(json);
			iCloudManager.documentStoreUpdatedEvent(obj);
		}
	}
}
