using UnityEngine;

public class GUISetting : MonoBehaviour
{
	public GUIStyle back;

	public GUIStyle soundOnOff;

	public GUIStyle restore;

	public GUIStyle sliderStyle;

	public GUIStyle thumbStyle;

	public Texture settingPlashka;

	public Texture settingTitle;

	public Texture fon;

	public Texture slow_fast;

	public Texture polzunok;

	private GameObject _purchaseActivityIndicator;

	private float mySens;

	private void Start()
	{
		_purchaseActivityIndicator = StoreKitEventListener.purchaseActivityInd;
	}

	private void Update()
	{
		_purchaseActivityIndicator.SetActive(StoreKitEventListener.purchaseInProcess);
	}

	private void OnGUI()
	{
		GUI.depth = 2;
		float num = (float)Screen.height / 768f;
		GUI.DrawTexture(new Rect((float)Screen.width / 2f - 683f * num, 0f, 1366f * num, Screen.height), fon);
		GUI.DrawTexture(new Rect((float)Screen.width / 2f - (float)settingPlashka.width * num * 0.5f, (float)Screen.height * 0.56f - (float)settingPlashka.height * num * 0.5f, (float)settingPlashka.width * num, (float)settingPlashka.height * num), settingPlashka);
		GUI.DrawTexture(new Rect((float)Screen.width / 2f - (float)settingTitle.width / 2f * Defs.Coef, (float)Screen.height * 0.12f, (float)settingTitle.width * Defs.Coef, (float)settingTitle.height * Defs.Coef), settingTitle);
		Rect position = new Rect((float)Screen.width * 0.5f - (float)soundOnOff.normal.background.width * 0.5f * num, (float)Screen.height * 0.67f - (float)soundOnOff.normal.background.height * 0.5f * num, (float)soundOnOff.normal.background.width * num, (float)soundOnOff.normal.background.height * num);
		bool @bool = PlayerPrefsX.GetBool(PlayerPrefsX.SndSetting, true);
		@bool = GUI.Toggle(position, @bool, string.Empty, soundOnOff);
		Debug.Log("sound=" + @bool);
		AudioListener.volume = (@bool ? 1 : 0);
		PlayerPrefsX.SetBool(PlayerPrefsX.SndSetting, @bool);
		PlayerPrefs.Save();
		if (GUI.Button(new Rect((float)Screen.width / 2f - (float)settingPlashka.width * num * 0.5f, (float)Screen.height * 0.9f - (float)back.normal.background.height * 0.5f * num, (float)back.normal.background.width * num, (float)back.normal.background.height * num), string.Empty, back))
		{
			Application.LoadLevel("Restart");
		}
		GUI.enabled = !StoreKitEventListener.purchaseInProcess;
		if (GUI.Button(new Rect((float)Screen.width / 2f + (float)settingPlashka.width * num * 0.5f - (float)restore.normal.background.width * num, (float)Screen.height * 0.9f - (float)restore.normal.background.height * 0.5f * num, (float)restore.normal.background.width * num, (float)restore.normal.background.height * num), string.Empty, restore))
		{
			StoreKitEventListener.purchaseInProcess = true;
			StoreKitBinding.restoreCompletedTransactions();
		}
		GUI.enabled = true;
		sliderStyle.fixedWidth = (float)slow_fast.width * num;
		sliderStyle.fixedHeight = (float)slow_fast.height * num;
		thumbStyle.fixedWidth = (float)polzunok.width * num;
		thumbStyle.fixedHeight = (float)polzunok.height * num;
		Rect position2 = new Rect((float)Screen.width * 0.5f - (float)slow_fast.width * 0.5f * num, (float)Screen.height * 0.5f - (float)slow_fast.height * 0.5f * num, (float)slow_fast.width * num, (float)slow_fast.height * num);
		mySens = GUI.HorizontalSlider(position2, PlayerPrefs.GetFloat("SensitivitySett", 12f), 6f, 18f, sliderStyle, thumbStyle);
		PlayerPrefs.SetFloat("SensitivitySett", mySens);
	}

	private void OnDestroy()
	{
		_purchaseActivityIndicator.SetActive(false);
	}
}
