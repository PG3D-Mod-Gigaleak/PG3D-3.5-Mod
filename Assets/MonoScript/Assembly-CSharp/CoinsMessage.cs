using UnityEngine;

public class CoinsMessage : MonoBehaviour
{
	public GUIStyle labelStyle;

	public Rect rect = Player_move_c.SuccessMessageRect();

	public string message = "Purchases have been restored";

	public int depth = -2;

	public bool singleMessage;

	private int coinsToShow;

	private int coinsForNextLevels;

	private double startTime;

	private float _time = 4f;

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		Invoke("Remove", (!singleMessage) ? (2f * _time) : _time);
		coinsToShow = keychainPlugin.getKCValue(Defs.EarnedCoins);
		keychainPlugin.updateKCValue(0, Defs.EarnedCoins);
		coinsForNextLevels = ((!singleMessage) ? (coinsToShow + GlobalGameController.coinsBaseAdding) : GlobalGameController.coinsBase);
		labelStyle.contentOffset = new Vector2(labelStyle.contentOffset.x, 70f * Defs.Coef);
		labelStyle.fontSize = Mathf.RoundToInt(30f * Defs.Coef);
		startTime = Time.realtimeSinceStartup;
	}

	private void Remove()
	{
		Object.Destroy(base.gameObject);
	}

	private void OnGUI()
	{
		rect = new Rect((float)Screen.width / 4f, (float)Screen.height * 0.246f, (float)Screen.width / 2f, (float)Screen.height / 5f);
		GUI.depth = depth;
		string text = "Pass next " + GlobalGameController.levelsToGetCoins + " levels and get " + coinsForNextLevels + " coins!";
		message = (singleMessage ? text : ((!((double)Time.realtimeSinceStartup - startTime < (double)_time)) ? text : ("Congratulations! You've got " + coinsToShow + " coins!")));
		GUI.Label(rect, message, labelStyle);
	}
}
