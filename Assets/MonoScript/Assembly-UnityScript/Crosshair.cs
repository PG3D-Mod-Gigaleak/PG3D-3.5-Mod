using System;
using UnityEngine;

[Serializable]
public class Crosshair : MonoBehaviour
{
	public Texture2D crosshairTexture;

	public Rect position;

	public void Start()
	{
		position = new Rect((Screen.width - crosshairTexture.width * Screen.height / 640) / 2, (Screen.height - crosshairTexture.height * Screen.height / 640) / 2, crosshairTexture.width * Screen.height / 640, crosshairTexture.height * Screen.height / 640);
	}

	public void OnGUI()
	{
		GUI.DrawTexture(position, crosshairTexture);
	}

	public void Main()
	{
	}
}
