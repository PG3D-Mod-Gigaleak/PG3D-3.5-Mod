using System.Collections;
using UnityEngine;

public class SkinsManagerPixlGun : MonoBehaviour
{
	public Hashtable skins = new Hashtable();

	private void OnLevelWasLoaded(int idx)
	{
		Debug.Log("OnLevelWasLoaded");
		if (skins.Count > 0)
		{
			skins.Clear();
			Debug.Log("Clear");
		}
		string path = ((PlayerPrefs.GetInt("COOP", 0) != 0) ? "EnemySkins/COOP/" : ("EnemySkins/Level" + ((GlobalGameController.currentLevel != GlobalGameController.levelMapping[0]) ? (GlobalGameController.previousLevel + 1) : 0)));
		Object[] array = Resources.LoadAll(path);
		Object[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			Texture texture = (Texture)array2[i];
			skins.Add(texture.name, texture);
		}
	}

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}
}
