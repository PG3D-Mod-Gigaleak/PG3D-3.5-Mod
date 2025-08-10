using UnityEngine;

public class GUIHelper : MonoBehaviour
{
	public static GUIHelper instance;

	public GUIStyle loadingStyle;

	public static void DrawLoading()
	{
		float num = (float)Screen.width * 0.125f;
		float num2 = (float)Screen.height * 0.031f;
		Rect position = new Rect((float)Screen.width - num, (float)Screen.height - num2, num, num2);
		instance.loadingStyle.fontSize = Mathf.RoundToInt(17f * Defs.Coef);
		GUI.Box(position, "Loading", instance.loadingStyle);
	}

	private void Update()
	{
	}

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		instance = this;
	}
}
