using System.Collections.Generic;
using UnityEngine;

public class iCloudEventListener : MonoBehaviour
{
	private void OnEnable()
	{
		iCloudManager.keyValueStoreDidChangeEvent += keyValueStoreDidChangeEvent;
		iCloudManager.ubiquityIdentityDidChangeEvent += ubiquityIdentityDidChangeEvent;
		iCloudManager.entitlementsMissingEvent += entitlementsMissingEvent;
		iCloudManager.documentStoreUpdatedEvent += documentStoreUpdatedEvent;
	}

	private void OnDisable()
	{
		iCloudManager.keyValueStoreDidChangeEvent -= keyValueStoreDidChangeEvent;
		iCloudManager.ubiquityIdentityDidChangeEvent -= ubiquityIdentityDidChangeEvent;
		iCloudManager.entitlementsMissingEvent -= entitlementsMissingEvent;
		iCloudManager.documentStoreUpdatedEvent -= documentStoreUpdatedEvent;
	}

	private void keyValueStoreDidChangeEvent(List<object> keys)
	{
		Debug.Log("keyValueStoreDidChangeEvent.  changed keys: ");
		foreach (object key in keys)
		{
			Debug.Log(key);
		}
	}

	private void ubiquityIdentityDidChangeEvent()
	{
		Debug.Log("ubiquityIdentityDidChangeEvent");
	}

	private void entitlementsMissingEvent()
	{
		Debug.Log("entitlementsMissingEvent");
	}

	private void documentStoreUpdatedEvent(List<iCloudManager.iCloudDocument> files)
	{
		foreach (iCloudManager.iCloudDocument file in files)
		{
			Debug.Log(file);
		}
	}
}
