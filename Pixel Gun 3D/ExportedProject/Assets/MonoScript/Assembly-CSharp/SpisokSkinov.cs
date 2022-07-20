using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Prime31;
using UnityEngine;

public class SpisokSkinov : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COnGUI_003Ec__AnonStorey17
	{
		internal Action restoreSucceeded;

		internal Action<string> restoreFailde;

		internal void _003C_003Em__A()
		{
			StoreKitManager.receiptValidationSuccessfulEvent -= restoreSucceeded;
			StoreKitManager.restoreTransactionsFailedEvent -= restoreFailde;
			PlayerPrefs.SetInt(Defs.inappsRestored_3_1, 1);
			PlayerPrefs.Save();
		}

		internal void _003C_003Em__B(string but)
		{
			StoreKitManager.receiptValidationSuccessfulEvent -= restoreSucceeded;
			StoreKitManager.restoreTransactionsFailedEvent -= restoreFailde;
		}
	}

	[CompilerGenerated]
	private sealed class _003COnGUI_003Ec__AnonStorey18
	{
		private sealed class _003COnGUI_003Ec__AnonStorey1A
		{
			private sealed class _003COnGUI_003Ec__AnonStorey19
			{
				internal Action<string> buyItem;

				internal _003COnGUI_003Ec__AnonStorey18 _003C_003Ef__ref_002424;

				internal _003COnGUI_003Ec__AnonStorey1A _003C_003Ef__ref_002426;

				internal void _003C_003Em__F(string pressedButton)
				{
					EtceteraManager.alertButtonClickedEvent -= buyItem;
					if (!pressedButton.Equals("Cancel"))
					{
						keychainPlugin.updateKCValue(_003C_003Ef__ref_002426.newCoins, Defs.Coins);
						_003C_003Ef__ref_002424._003C_003Ef__this.mainController.previewControl.PurchaseSuccessful(_003C_003Ef__ref_002424.id);
						_003C_003Ef__ref_002424._003C_003Ef__this.SetCurrent();
					}
				}
			}

			internal int newCoins;

			internal Action<string>[] showShop;

			internal _003COnGUI_003Ec__AnonStorey18 _003C_003Ef__ref_002424;

			internal void _003C_003Em__D()
			{
				_003COnGUI_003Ec__AnonStorey19 _003COnGUI_003Ec__AnonStorey = new _003COnGUI_003Ec__AnonStorey19();
				_003COnGUI_003Ec__AnonStorey._003C_003Ef__ref_002424 = _003C_003Ef__ref_002424;
				_003COnGUI_003Ec__AnonStorey._003C_003Ef__ref_002426 = this;
				_003COnGUI_003Ec__AnonStorey.buyItem = null;
				_003COnGUI_003Ec__AnonStorey.buyItem = _003COnGUI_003Ec__AnonStorey._003C_003Em__F;
				EtceteraManager.alertButtonClickedEvent += _003COnGUI_003Ec__AnonStorey.buyItem;
				EtceteraBinding.showAlertWithTitleMessageAndButtons(string.Empty, "Open " + InAppData.inappReadableNames[_003C_003Ef__ref_002424.id] + "?", new string[2] { "Cancel", "Open" });
			}

			internal void _003C_003Em__E(string pressedbutton)
			{
				EtceteraManager.alertButtonClickedEvent -= showShop[0];
				if (!pressedbutton.Equals("Cancel"))
				{
					coinsShop.thisScript.notEnoughCoins = true;
					coinsShop.thisScript.onReturnAction = _003C_003Ef__ref_002424.act;
					coinsShop.showCoinsShop();
				}
			}
		}

		internal string id;

		internal Action act;

		internal SpisokSkinov _003C_003Ef__this;

		internal void _003C_003Em__C()
		{
			_003COnGUI_003Ec__AnonStorey1A _003COnGUI_003Ec__AnonStorey1A = new _003COnGUI_003Ec__AnonStorey1A();
			_003COnGUI_003Ec__AnonStorey1A._003C_003Ef__ref_002424 = this;
			coinsShop.thisScript.notEnoughCoins = false;
			coinsShop.thisScript.onReturnAction = null;
			int num = ((!VirtualCurrencyHelper.prices.ContainsKey(id)) ? 10 : VirtualCurrencyHelper.prices[id]);
			_003COnGUI_003Ec__AnonStorey1A.newCoins = keychainPlugin.getKCValue(Defs.Coins) - num;
			Action action = _003COnGUI_003Ec__AnonStorey1A._003C_003Em__D;
			_003COnGUI_003Ec__AnonStorey1A.showShop = null;
			_003COnGUI_003Ec__AnonStorey1A.showShop = new Action<string>[1] { _003COnGUI_003Ec__AnonStorey1A._003C_003Em__E };
			if (_003COnGUI_003Ec__AnonStorey1A.newCoins >= 0)
			{
				action();
				return;
			}
			EtceteraManager.alertButtonClickedEvent += _003COnGUI_003Ec__AnonStorey1A.showShop[0];
			EtceteraBinding.showAlertWithTitleMessageAndButtons(string.Empty, "You do not have enough coins. Do you want to buy some?", new string[2] { "Cancel", "Yes!" });
		}
	}

	public bool showEnabled;

	private static float koefMashtab = (float)Screen.height / 768f;

	public Controller mainController;

	private ViborChastiTela viborChastiTelaController;

	public ArrayList arrNameSkin;

	public ArrayList arrTitleSkin;

	public Texture2D fonTitle;

	public Texture2D plashkaNiz;

	public Texture2D oknoDelSkin;

	public Texture2D head_Prof;

	public GUIStyle butBack;

	public GUIStyle labelTitle;

	public GUIStyle butDel;

	public GUIStyle nameStyle;

	public GUIStyle setStyle;

	public GUIStyle labelTitleSkin;

	public GUIStyle butDlgOk;

	public GUIStyle butDlgCancel;

	private bool dialogDelNeActiv = true;

	private bool msgSaveShow;

	private Rect rectDialogDel;

	private string namePlayer;

	public Texture leftArr;

	public Texture rightArr;

	public Texture swipeToChange;

	public Texture equipped;

	public Texture locked;

	public Texture cup;

	public GUIStyle buyStyle;

	public GUIStyle winsLabelStyle;

	public GUIStyle restoreStyle;

	public Texture restoreWindowTexture;

	public GUIStyle restoreWindButStyle;

	public GUIStyle cancelEindButStyle;

	private string _userId;

	private bool _canUserUseFacebookComposer;

	private bool _hasPublishPermission;

	private bool _hasPublishActions;

	private GameCenterSingleton _gc;

	private bool showMessagFacebook;

	private bool showMessagTiwtter;

	private bool clickButtonFacebook;

	public GUIStyle facebookStyle;

	public GUIStyle twitterStyle;

	public GUIStyle gamecenterStyle;

	public GUIStyle labelStyle;

	public GUIStyle scoresStyle;

	private void completionHandler(string error, object result)
	{
		if (error != null)
		{
			Debug.LogError(error);
		}
		else
		{
			Utils.logObject(result);
		}
	}

	private void Start()
	{
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 1)
		{
			InitFacebookEvents();
			FacebookBinding.init();
			FacebookBinding.setSessionLoginBehavior(FacebookSessionLoginBehavior.UseSystemAccountIfPresent);
			_gc = GameCenterSingleton.Instance;
			FacebookManager.graphRequestCompletedEvent += facebookGraphReqCompl;
			FacebookManager.sessionOpenedEvent += facebookSessionOpened;
			FacebookManager.reauthorizationSucceededEvent += facebookreauthorizationSucceededEvent;
			_canUserUseFacebookComposer = FacebookBinding.canUserUseFacebookComposer();
		}
		mainController = GetComponent<Controller>();
		viborChastiTelaController = GetComponent<ViborChastiTela>();
		mainController.previewControl.editModeEnteredDelegate = shooseSkin;
		rectDialogDel = new Rect((float)Screen.width * 0.5f - (float)oknoDelSkin.width * 0.5f * koefMashtab, (float)Screen.height * 0.5f - (float)oknoDelSkin.height * 0.5f * koefMashtab, (float)oknoDelSkin.width * koefMashtab, (float)oknoDelSkin.height * koefMashtab);
		namePlayer = PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName);
		nameStyle.fontSize = Mathf.RoundToInt(30f * koefMashtab);
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 1)
		{
			Camera.main.transform.position += new Vector3(0f, 0.37f, 0f);
		}
	}

	private void Update()
	{
		if (!showEnabled)
		{
		}
	}

	private void SetCurrent()
	{
		int currentTextureIndex = mainController.previewControl.CurrentTextureIndex;
		string value = Defs.SkinBaseName + (currentTextureIndex + 1);
		PlayerPrefs.SetString(Defs.SkinNameMultiplayer, value);
		PlayerPrefs.SetInt(Defs.SkinIndexMultiplayer, currentTextureIndex);
		PlayerPrefs.SetString("NamePlayer", namePlayer);
		PlayerPrefs.Save();
	}

	private void OnGUI()
	{
		if (!showEnabled || coinsShop.thisScript.enabled)
		{
			return;
		}
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 0)
		{
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, (float)fonTitle.height * koefMashtab), fonTitle);
			labelTitle.fontSize = Mathf.RoundToInt(25f * koefMashtab);
			GUI.Label(new Rect(0f, 0f, Screen.width, (float)fonTitle.height * koefMashtab), "CHOOSE THE SKIN", labelTitle);
			GUI.DrawTexture(new Rect(0f, (float)Screen.height - (float)plashkaNiz.height * koefMashtab, Screen.width, (float)plashkaNiz.height * koefMashtab), plashkaNiz);
		}
		bool flag = false;
		int depth = GUI.depth;
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 1 && PlayerPrefs.GetInt(Defs.restoreWindowShownProfile, 0) == 0 && PlayerPrefs.GetInt(Defs.inappsRestored_3_1, 0) != 1)
		{
			GUI.enabled = true;
			GUI.depth = -4;
			flag = true;
			Rect position = new Rect((float)Screen.width / 2f - (float)restoreWindowTexture.width * 0.5f * Defs.Coef, (float)Screen.height / 2f - (float)restoreWindowTexture.height * 0.5f * Defs.Coef, (float)restoreWindowTexture.width * Defs.Coef, (float)restoreWindowTexture.height * Defs.Coef);
			GUI.DrawTexture(position, restoreWindowTexture);
			float num = (float)Screen.width / 20f;
			float num2 = 0.15f;
			if (GUI.Button(new Rect((float)Screen.width / 2f + num, (float)Screen.height / 2f + (float)restoreWindowTexture.height * num2 * Defs.Coef, (float)restoreWindButStyle.normal.background.width * Defs.Coef, (float)restoreWindButStyle.normal.background.height * Defs.Coef), string.Empty, restoreWindButStyle))
			{
				_003COnGUI_003Ec__AnonStorey17 _003COnGUI_003Ec__AnonStorey = new _003COnGUI_003Ec__AnonStorey17();
				_003COnGUI_003Ec__AnonStorey.restoreSucceeded = null;
				_003COnGUI_003Ec__AnonStorey.restoreFailde = null;
				_003COnGUI_003Ec__AnonStorey.restoreSucceeded = _003COnGUI_003Ec__AnonStorey._003C_003Em__A;
				_003COnGUI_003Ec__AnonStorey.restoreFailde = _003COnGUI_003Ec__AnonStorey._003C_003Em__B;
				StoreKitManager.restoreTransactionsFinishedEvent += _003COnGUI_003Ec__AnonStorey.restoreSucceeded;
				StoreKitManager.restoreTransactionsFailedEvent += _003COnGUI_003Ec__AnonStorey.restoreFailde;
				StoreKitEventListener.purchaseInProcess = true;
				StoreKitEventListener.restoreInProcess = true;
				StoreKitBinding.restoreCompletedTransactions();
				PlayerPrefs.SetInt(Defs.restoreWindowShownProfile, 1);
				mainController.previewControl.Locked = false;
				return;
			}
			if (GUI.Button(new Rect((float)Screen.width / 2f - (float)cancelEindButStyle.normal.background.width * Defs.Coef - num, (float)Screen.height / 2f + (float)restoreWindowTexture.height * num2 * Defs.Coef, (float)cancelEindButStyle.normal.background.width * Defs.Coef, (float)cancelEindButStyle.normal.background.height * Defs.Coef), string.Empty, cancelEindButStyle))
			{
				PlayerPrefs.SetInt(Defs.restoreWindowShownProfile, 1);
				mainController.previewControl.Locked = false;
				return;
			}
			mainController.previewControl.Locked = true;
			GUI.enabled = false;
		}
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 1)
		{
			coinsPlashka.thisScript.enabled = true && !flag;
		}
		float left = 55f * koefMashtab;
		float width = (float)butBack.normal.background.width * koefMashtab;
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 1)
		{
			GUI.enabled = !StoreKitEventListener.restoreInProcess && !flag;
		}
		Rect position2 = ((PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) != 0) ? ConnectGUI.LeftButtonRect : new Rect(left, (float)Screen.height - (9f + (float)butBack.normal.background.height) * koefMashtab, width, (float)butBack.normal.background.height * koefMashtab));
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 0)
		{
			if (GUI.Button(position2, string.Empty, butBack) && dialogDelNeActiv)
			{
				mainController.showEnabled = true;
				showEnabled = false;
				mainController.objPeople.active = false;
			}
		}
		else if (GUI.RepeatButton(position2, string.Empty, butBack) && dialogDelNeActiv)
		{
			GUIHelper.DrawLoading();
			PlayerPrefs.SetInt("typeConnect__", 0);
			Application.LoadLevel("ConnectScene");
		}
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 1)
		{
			GUI.enabled = true && !flag;
		}
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 1)
		{
			GUI.DrawTexture(new Rect((float)Screen.width / 2f - (float)head_Prof.width / 2f * koefMashtab, (float)Screen.height * 0.1f - (float)head_Prof.height / 2f * koefMashtab, (float)head_Prof.width * koefMashtab, (float)head_Prof.height * koefMashtab), head_Prof);
			StoreKitEventListener.purchaseActivityInd.SetActive(StoreKitEventListener.restoreInProcess);
			GUI.enabled = !StoreKitEventListener.purchaseInProcess && !flag;
			Rect symmetricRect = coinsPlashka.symmetricRect;
			symmetricRect.x = (float)Screen.width - coinsPlashka.thisScript.rectButCoins.x - (float)restoreStyle.normal.background.width * koefMashtab;
			symmetricRect.y += symmetricRect.height / 2f;
			symmetricRect.y -= (float)restoreStyle.normal.background.height / 2f * koefMashtab;
			symmetricRect.width = (float)restoreStyle.normal.background.width * koefMashtab;
			symmetricRect.height = (float)restoreStyle.normal.background.height * koefMashtab;
			if (GUI.Button(symmetricRect, string.Empty, restoreStyle))
			{
				StoreKitEventListener.purchaseInProcess = true;
				StoreKitEventListener.restoreInProcess = true;
				StoreKitBinding.restoreCompletedTransactions();
			}
			GUI.enabled = true && !flag;
			Rect position3 = new Rect((float)Screen.width * 0.5f - (float)nameStyle.normal.background.width * 0.5f * koefMashtab, (float)Screen.height * 0.23f - (float)nameStyle.normal.background.height * 0.5f * koefMashtab, (float)nameStyle.normal.background.width * koefMashtab, (float)nameStyle.normal.background.height * koefMashtab);
			namePlayer = GUI.TextField(position3, namePlayer, nameStyle);
			PlayerPrefs.SetString("NamePlayer", namePlayer);
			Rect position4 = new Rect(coinsPlashka.thisScript.rectButCoins.x + coinsPlashka.thisScript.rectButCoins.width / 2f - (float)cup.width / 2f * koefMashtab, position3.y + position3.height / 2f - (float)cup.height / 2f * koefMashtab, (float)cup.width * koefMashtab, (float)cup.height * koefMashtab);
			GUI.DrawTexture(position4, cup);
			winsLabelStyle.fontSize = Mathf.RoundToInt(30f * koefMashtab);
			float num3 = position4.width * 2f;
			Rect rect = new Rect(position4.x + position4.width / 2f - num3 / 2f, position4.y + position4.height, num3, num3 / 3f);
			GUI.Box(rect, " Wins: " + PlayerPrefs.GetInt("Rating", 0), winsLabelStyle);
			Rect position5 = rect;
			bool flag2 = Defs.screenRation > 1.3666667f;
			position5.x = ((!flag2) ? (position3.x + position3.width + ((float)Screen.width - (position3.x + position3.width)) / 2f - position5.width / 2f) : (symmetricRect.x + symmetricRect.width - position5.width));
			position5.y = position3.y;
			position5.height = (float)Screen.width / 4f;
			scoresStyle.fontSize = winsLabelStyle.fontSize;
			keychainPlugin.createKCValue(0, Defs.COOPScore);
			GUI.Label(position5, "CO-OP\nMAX SCORE\n" + keychainPlugin.getKCValue(Defs.COOPScore) + "\n\nSURVIVAL\nMAX SCORE\n" + PlayerPrefs.GetInt(Defs.BestScoreSett, 0), scoresStyle);
			Rect rightButtonRect = ConnectGUI.RightButtonRect;
			rightButtonRect.y = ConnectGUI.LeftButtonRect.y;
			rightButtonRect.height = ConnectGUI.LeftButtonRect.height;
			if (InAppData.inAppData.ContainsKey(mainController.previewControl.CurrentTextureIndex) && Storager.getInt(InAppData.inAppData[mainController.previewControl.CurrentTextureIndex].Value) < 1)
			{
				GUI.enabled = !StoreKitEventListener.restoreInProcess && !flag;
				if (!mainController.previewControl.Locked && GUI.Button(rightButtonRect, string.Empty, buyStyle))
				{
					_003COnGUI_003Ec__AnonStorey18 _003COnGUI_003Ec__AnonStorey2 = new _003COnGUI_003Ec__AnonStorey18();
					_003COnGUI_003Ec__AnonStorey2._003C_003Ef__this = this;
					_003COnGUI_003Ec__AnonStorey2.id = InAppData.inAppData[mainController.previewControl.CurrentTextureIndex].Key;
					_003COnGUI_003Ec__AnonStorey2.act = null;
					_003COnGUI_003Ec__AnonStorey2.act = _003COnGUI_003Ec__AnonStorey2._003C_003Em__C;
					_003COnGUI_003Ec__AnonStorey2.act();
				}
				GUI.enabled = true && !flag;
			}
			else if (!mainController.previewControl.Locked && GUI.Button(rightButtonRect, string.Empty, setStyle) && dialogDelNeActiv)
			{
				SetCurrent();
			}
			if (flag)
			{
				return;
			}
			float num4 = (float)facebookStyle.normal.background.width * Defs.Coef / 3f;
			Rect position6 = new Rect((float)Screen.width / 2f + (float)facebookStyle.normal.background.width * Defs.Coef * 0.5f + num4, (float)Screen.height * 0.923f - (float)Screen.height * 0.0525f, (float)twitterStyle.normal.background.width * Defs.Coef, (float)twitterStyle.normal.background.height * Defs.Coef);
			Rect position7 = new Rect((float)Screen.width / 2f - (float)facebookStyle.normal.background.width * Defs.Coef * 1.5f - num4, (float)Screen.height * 0.923f - (float)Screen.height * 0.0525f, (float)facebookStyle.normal.background.width * Defs.Coef, (float)facebookStyle.normal.background.height * Defs.Coef);
			float left2 = (float)Screen.width / 2f - position7.width / 2f;
			float width2 = (float)Screen.height * 0.105f;
			if (GUI.Button(new Rect(left2, (float)Screen.height * 0.923f - (float)Screen.height * 0.0525f, width2, (float)Screen.height * 0.105f), string.Empty, gamecenterStyle))
			{
				if (_gc.IsUserAuthenticated())
				{
					_gc.ShowLeaderboardUI();
				}
				else
				{
					_gc.updateGameCenter();
					MonoBehaviour.print("error Authenticated ");
				}
			}
			if (GUI.Button(position6, string.Empty, twitterStyle))
			{
				InitTwitter();
			}
			if (MainMenu.iOSVersion > 5f && GUI.Button(position7, string.Empty, facebookStyle))
			{
				InitFacebook();
			}
			float num5 = (float)Screen.height / 768f;
			float num6 = (float)Screen.width / 4f;
			GUI.DrawTexture(new Rect((float)Screen.width / 2f - num6 - (float)leftArr.width / 2f * num5, Screen.height / 2, (float)leftArr.width * num5, (float)leftArr.height * num5), leftArr);
			Rect position8 = new Rect((float)Screen.width / 2f + num6 - (float)leftArr.width / 2f * num5, Screen.height / 2, (float)leftArr.width * num5, (float)leftArr.height * num5);
			GUI.DrawTexture(position8, rightArr);
			GUI.DrawTexture(new Rect((float)Screen.width / 2f - (float)swipeToChange.width / 2f * num5, ConnectGUI.RightButtonRect.y + ConnectGUI.RightButtonRect.height / 2f - (float)(swipeToChange.height / 2) * num5, (float)swipeToChange.width * num5, (float)swipeToChange.height * num5), swipeToChange);
			if (!mainController.previewControl.Locked && PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 1 && PlayerPrefs.GetInt(Defs.SkinIndexMultiplayer, 0) == mainController.previewControl.CurrentTextureIndex)
			{
				GUI.DrawTexture(new Rect(position8.x - (float)equipped.width * 0.56f * num5, position8.y - position8.height * 0.5f - (float)equipped.height * 0.5f * num5 - (float)equipped.height * 0.16f * num5, (float)equipped.width * num5, (float)equipped.height * num5), equipped);
			}
			if (InAppData.inAppData.ContainsKey(mainController.previewControl.CurrentTextureIndex) && Storager.getInt(InAppData.inAppData[mainController.previewControl.CurrentTextureIndex].Value) < 1)
			{
				GUI.DrawTexture(new Rect((float)Screen.width / 2f - (float)locked.width / 2f * num5, position8.y + position8.height / 2f - (float)locked.height / 2f * num5, (float)locked.width * num5, (float)locked.height * num5), locked);
			}
			if (showMessagFacebook)
			{
				labelStyle.fontSize = Player_move_c.FontSizeForMessages;
				GUI.Label(Player_move_c.SuccessMessageRect(), _SocialSentSuccess("Facebook"), labelStyle);
			}
			if (showMessagTiwtter)
			{
				labelStyle.fontSize = Player_move_c.FontSizeForMessages;
				GUI.Label(Player_move_c.SuccessMessageRect(), _SocialSentSuccess("Twitter"), labelStyle);
			}
		}
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 0)
		{
			GUI.Label(new Rect(0f, 120f * koefMashtab, Screen.width, 50f * koefMashtab), (string)arrTitleSkin[mainController.previewControl.CurrentTextureIndex], labelTitleSkin);
		}
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 0 && arrNameSkin != null && mainController.previewControl.CurrentTextureIndex > Controller.SkinMaker_arrVremTitle.Length - 1 && GUI.Button(new Rect((float)Screen.width - 55f * koefMashtab - (float)butDel.normal.background.width * koefMashtab, (float)Screen.height - (9f + (float)butDel.normal.background.height) * koefMashtab, (float)butDel.normal.background.width * koefMashtab, (float)butDel.normal.background.height * koefMashtab), string.Empty, butDel) && dialogDelNeActiv)
		{
			dialogDelNeActiv = false;
			mainController.previewControl.Locked = true;
		}
		if (!dialogDelNeActiv)
		{
			GUI.DrawTexture(rectDialogDel, oknoDelSkin);
			if (GUI.Button(new Rect(rectDialogDel.x + 55f * koefMashtab, rectDialogDel.y + rectDialogDel.height - 125f * koefMashtab, (float)butDlgCancel.normal.background.width * koefMashtab, (float)butDlgCancel.normal.background.height * koefMashtab), string.Empty, butDlgCancel))
			{
				dialogDelNeActiv = true;
				mainController.previewControl.Locked = false;
			}
			if (GUI.Button(new Rect(rectDialogDel.x + rectDialogDel.width - 55f * koefMashtab - (float)butDlgOk.normal.background.width * koefMashtab, rectDialogDel.y + rectDialogDel.height - 125f * koefMashtab, (float)butDlgOk.normal.background.width * koefMashtab, (float)butDlgOk.normal.background.height * koefMashtab), string.Empty, butDlgOk))
			{
				SkinsManager.DeleteTexture((string)arrNameSkin[mainController.previewControl.CurrentTextureIndex]);
				arrNameSkin.RemoveAt(mainController.previewControl.CurrentTextureIndex);
				arrTitleSkin.RemoveAt(mainController.previewControl.CurrentTextureIndex);
				string[] variable = arrNameSkin.ToArray(typeof(string)) as string[];
				string[] variable2 = arrTitleSkin.ToArray(typeof(string)) as string[];
				Save.SaveStringArray("arrNameSkin", variable);
				Save.SaveStringArray("arrTitleSkin", variable2);
				mainController.previewControl.updateSpisok();
				mainController.previewControl.ShowSkin(mainController.previewControl.CurrentTextureIndex - 1);
				mainController.previewControl.Locked = false;
				dialogDelNeActiv = true;
			}
		}
		if (msgSaveShow)
		{
			labelTitle.fontSize = Mathf.RoundToInt(25f * koefMashtab);
			GUI.Label(new Rect(0f, (float)Screen.height - 200f * koefMashtab, Screen.width, 100f * koefMashtab), "The Skin has been  saved to gallery", labelTitle);
		}
	}

	private void shooseSkin()
	{
		int currentTextureIndex = mainController.previewControl.CurrentTextureIndex;
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) != 1)
		{
			viborChastiTelaController.cutSkin(currentTextureIndex);
			showEnabled = false;
			viborChastiTelaController.showEnabled = true;
			ViborChastiTela.skinIzm = false;
		}
	}

	public void hideMsg()
	{
		msgSaveShow = false;
	}

	public void showMsg()
	{
		msgSaveShow = true;
		Invoke("hideMsg", 2f);
	}

	private void OnDestroy()
	{
		coinsPlashka.thisScript.enabled = false;
		StoreKitEventListener.purchaseActivityInd.SetActive(false);
		if (PlayerPrefs.GetInt(Defs.SkinEditorMode, 0) == 1)
		{
			CleanFacebookEvents();
		}
	}

	private void InitTwitter()
	{
		Debug.Log("InitTwitter(): init");
		if (GlobalGameController.isFullVersion)
		{
			TwitterBinding.init("Aw3DKZAHCPluVbLi9ZvUg", "amiSRlQgYmblYHsxJVZLu2t9Nvn6ogZKa2zclu8Lld4");
		}
		else
		{
			TwitterBinding.init("Jb7CwCaMgCQQiMViQRNHw", "zGVrax4vqgs3CYf04O7glsoRbNT3vhIafte6lfm8w");
		}
		if (!TwitterBinding.isLoggedIn())
		{
			TwitterLogin();
		}
		else
		{
			TwitterPost();
		}
	}

	private void TwitterLogin()
	{
		TwitterManager.loginSucceededEvent += OnTwitterLogin;
		TwitterManager.loginFailedEvent += OnTwitterLoginFailed;
		TwitterBinding.showOauthLoginDialog();
	}

	private void OnTwitterLogin()
	{
		TwitterManager.loginSucceededEvent -= OnTwitterLogin;
		TwitterManager.loginFailedEvent -= OnTwitterLoginFailed;
		TwitterPost();
	}

	private void OnTwitterLoginFailed(string _error)
	{
		TwitterManager.loginSucceededEvent -= OnTwitterLogin;
		TwitterManager.loginFailedEvent -= OnTwitterLoginFailed;
	}

	private void TwitterPost()
	{
		TwitterManager.postSucceededEvent += OnTwitterPost;
		TwitterManager.postFailedEvent += OnTwitterPostFailed;
		TwitterBinding.postStatusUpdate(_SocialMessage());
	}

	private void OnTwitterPost()
	{
		TwitterManager.postSucceededEvent -= OnTwitterPost;
		TwitterManager.postFailedEvent -= OnTwitterPostFailed;
		showMessagTiwtter = true;
		Invoke("hideMessagTwitter", 3f);
	}

	private void OnTwitterPostFailed(string _error)
	{
		TwitterManager.postSucceededEvent -= OnTwitterPost;
		TwitterManager.postFailedEvent -= OnTwitterPostFailed;
	}

	private void hideMessag()
	{
		showMessagFacebook = false;
	}

	private void hideMessagTwitter()
	{
		showMessagTiwtter = false;
	}

	private void InitFacebook()
	{
		clickButtonFacebook = true;
		if (!FacebookBinding.isSessionValid())
		{
			Debug.Log("!isSessionValid");
			string[] permissions = new string[1] { "email" };
			FacebookBinding.loginWithReadPermissions(permissions);
		}
		else
		{
			Debug.Log("isSessionValid");
			OnEventFacebookLogin();
		}
	}

	private void InitFacebookEvents()
	{
		FacebookManager.reauthorizationSucceededEvent += OnEventFacebookLogin;
		FacebookManager.loginFailedEvent += OnEventFacebookLoginFailed;
		FacebookManager.sessionOpenedEvent += OnEventFacebookLogin;
	}

	private void CleanFacebookEvents()
	{
		FacebookManager.reauthorizationSucceededEvent -= OnEventFacebookLogin;
		FacebookManager.loginFailedEvent -= OnEventFacebookLoginFailed;
		FacebookManager.sessionOpenedEvent -= OnEventFacebookLogin;
	}

	private void OnEventFacebookLogin()
	{
		if (!clickButtonFacebook)
		{
			return;
		}
		Debug.Log("OnEventFacebookLogin");
		if (FacebookBinding.isSessionValid())
		{
			if (_hasPublishPermission)
			{
				Debug.Log("sendMessag");
				clickButtonFacebook = false;
				showMessagFacebook = true;
				Invoke("hideMessag", 3f);
				Facebook.instance.postMessage(_SocialMessage(), completionHandler);
			}
			else
			{
				Debug.Log("poluchau permissions");
				string[] permissions = new string[2] { "publish_actions", "publish_stream" };
				FacebookBinding.reauthorizeWithPublishPermissions(permissions, FacebookSessionDefaultAudience.Everyone);
			}
		}
	}

	private void facebookGraphReqCompl(object result)
	{
		Utils.logObject(result);
	}

	private void facebookSessionOpened()
	{
		_hasPublishPermission = FacebookBinding.getSessionPermissions().Contains("publish_stream");
		_hasPublishActions = FacebookBinding.getSessionPermissions().Contains("publish_actions");
	}

	private void facebookreauthorizationSucceededEvent()
	{
		_hasPublishPermission = FacebookBinding.getSessionPermissions().Contains("publish_stream");
		_hasPublishActions = FacebookBinding.getSessionPermissions().Contains("publish_actions");
	}

	private void OnEventFacebookLoginFailed(string s)
	{
		clickButtonFacebook = false;
		Debug.Log("OnEventFacebookLoginFailed=" + s);
	}

	private string _SocialMessage()
	{
		keychainPlugin.createKCValue(0, Defs.COOPScore);
		return "I have " + PlayerPrefs.GetInt("Rating", 0) + " wins in multiplayaer and " + keychainPlugin.getKCValue(Defs.COOPScore) + " max score in Coop mode! Fight with me in Pixel Gun 3D!";
	}

	private string _SocialSentSuccess(string SocialName)
	{
		return "Message was sent to " + SocialName;
	}
}
