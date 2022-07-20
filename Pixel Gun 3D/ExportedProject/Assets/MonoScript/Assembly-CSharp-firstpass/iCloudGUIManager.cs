using System.Collections;
using Prime31;
using UnityEngine;

public class iCloudGUIManager : MonoBehaviourGUI
{
	private string _filename = "myCloudFile.txt";

	private void OnGUI()
	{
		beginColumn();
		if (GUILayout.Button("Synchronize"))
		{
			bool flag = P31Prefs.synchronize();
			Debug.Log("did synchronize: " + flag);
		}
		if (GUILayout.Button("Get the ubiquityIdentityToken"))
		{
			string ubiquityIdentityToken = iCloudBinding.getUbiquityIdentityToken();
			Debug.Log("ubiquityIdentityToken: " + ubiquityIdentityToken);
		}
		if (GUILayout.Button("Set Int 29"))
		{
			P31Prefs.setInt("theInt", 29);
			Debug.Log("int: " + P31Prefs.getInt("theInt"));
		}
		if (GUILayout.Button("Set string 'word'"))
		{
			P31Prefs.setString("theString", "word");
			Debug.Log("string: " + P31Prefs.getString("theString"));
		}
		if (GUILayout.Button("Set Bool"))
		{
			P31Prefs.setBool("theBool", true);
			Debug.Log("bool: " + P31Prefs.getBool("theBool"));
		}
		if (GUILayout.Button("Set Float 13.68"))
		{
			P31Prefs.setFloat("theFloat", 13.68f);
			Debug.Log("float: " + P31Prefs.getFloat("theFloat"));
		}
		if (GUILayout.Button("Set Dictionary"))
		{
			Hashtable hashtable = new Hashtable();
			hashtable.Add("aFloat", 25.5f);
			hashtable.Add("aString", "dogma");
			hashtable.Add("anInt", 16);
			P31Prefs.setDictionary("theDict", hashtable);
			Utils.logObject(P31Prefs.getDictionary("theDict"));
		}
		if (GUILayout.Button("Get All"))
		{
			Debug.Log("int: " + P31Prefs.getInt("theInt"));
			Debug.Log("string: " + P31Prefs.getString("theString"));
			Debug.Log("bool: " + P31Prefs.getBool("theBool"));
			Utils.logObject(P31Prefs.getDictionary("theDict"));
			Debug.Log("float: " + P31Prefs.getFloat("theFloat"));
		}
		if (GUILayout.Button("Remove All Values"))
		{
			P31Prefs.removeAll();
		}
		endColumn(true);
		if (GUILayout.Button("Is Document Store Available"))
		{
			Debug.Log("Is document store available: " + P31Prefs.iCloudDocumentStoreAvailable);
		}
		if (GUILayout.Button("Is File in iCloud?"))
		{
			Debug.Log("Is file in iCloud: " + iCloudBinding.isFileInCloud(_filename));
		}
		if (GUILayout.Button("Is File Downloaded?"))
		{
			Debug.Log("Is file downloaded: " + iCloudBinding.isFileDownloaded(_filename));
		}
		if (GUILayout.Button("Save File to iCloud"))
		{
			_filename = string.Format("myCloudFile{0}.txt", Random.Range(0, 10000));
			bool flag2 = P31CloudFile.writeAllText(_filename, "going to write some text");
			Debug.Log("Did write file to iCloud: " + flag2);
		}
		if (GUILayout.Button("Modify File"))
		{
			bool flag3 = P31CloudFile.writeAllText(_filename, "changed up the text and now its this");
			Debug.Log("Did write file to iCloud: " + flag3);
		}
		if (GUILayout.Button("Get Contents of File"))
		{
			string[] value = P31CloudFile.readAllLines(_filename);
			Debug.Log("File contents: " + string.Join(string.Empty, value));
		}
		if (GUILayout.Button("Evict File"))
		{
			iCloudBinding.evictFile(_filename);
		}
		endColumn();
	}
}
