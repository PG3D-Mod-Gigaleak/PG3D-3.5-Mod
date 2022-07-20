using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003COnGUI_003Ec__AnonStorey14
	{
		private sealed class _003COnGUI_003Ec__AnonStorey13
		{
			internal int newCoins;

			internal Action<string>[] showShop;

			internal _003COnGUI_003Ec__AnonStorey14 _003C_003Ef__ref_002420;

			internal void _003C_003Em__1()
			{
				keychainPlugin.updateKCValue(newCoins, Defs.Coins);
				_003C_003Ef__ref_002420._003C_003Ef__this._Buy();
			}

			internal void _003C_003Em__2(string pressedbutton)
			{
				EtceteraManager.alertButtonClickedEvent -= showShop[0];
				if (!pressedbutton.Equals("Cancel"))
				{
					coinsShop.thisScript.notEnoughCoins = true;
					coinsShop.thisScript.onReturnAction = _003C_003Ef__ref_002420.act;
					coinsShop.showCoinsShop();
				}
			}
		}

		internal Action act;

		internal GameOver _003C_003Ef__this;

		internal void _003C_003Em__0()
		{
			_003COnGUI_003Ec__AnonStorey13 _003COnGUI_003Ec__AnonStorey = new _003COnGUI_003Ec__AnonStorey13();
			_003COnGUI_003Ec__AnonStorey._003C_003Ef__ref_002420 = this;
			coinsShop.thisScript.notEnoughCoins = false;
			coinsShop.thisScript.onReturnAction = null;
			int num = ((!VirtualCurrencyHelper.prices.ContainsKey(StoreKitEventListener.elixirID)) ? 10 : VirtualCurrencyHelper.prices[StoreKitEventListener.elixirID]);
			_003COnGUI_003Ec__AnonStorey.newCoins = keychainPlugin.getKCValue(Defs.Coins) - num;
			Action action = _003COnGUI_003Ec__AnonStorey._003C_003Em__1;
			_003COnGUI_003Ec__AnonStorey.showShop = null;
			_003COnGUI_003Ec__AnonStorey.showShop = new Action<string>[1] { _003COnGUI_003Ec__AnonStorey._003C_003Em__2 };
			if (_003COnGUI_003Ec__AnonStorey.newCoins >= 0)
			{
				action();
				return;
			}
			EtceteraManager.alertButtonClickedEvent += _003COnGUI_003Ec__AnonStorey.showShop[0];
			EtceteraBinding.showAlertWithTitleMessageAndButtons(string.Empty, "You do not have enough coins. Do you want to buy coins?", new string[2] { "Cancel", "Yes!" });
		}
	}

	private GameObject _purchaseActivityIndicator;

	public Texture elixir;

	public Texture noElixir;

	public Texture noElixirNOinet;

	public GUIStyle resurrect;

	public GUIStyle retry;

	public GUIStyle quit;

	public GUIStyle decline;

	public GUIStyle buy;

	public GUIStyle ok;

	private bool haveNoElixirSh;

	private float coef = (float)Screen.height / 768f;

	private GameObject _inAppGameObject;

	public StoreKitEventListener _listener;

	public List<StoreKitProduct> _products = new List<StoreKitProduct>();

	public bool activeInicator;

	private void Start()
	{
		_inAppGameObject = GameObject.FindGameObjectWithTag("InAppGameObject");
		_listener = _inAppGameObject.GetComponent<StoreKitEventListener>();
		_purchaseActivityIndicator = StoreKitEventListener.purchaseActivityInd;
		_purchaseActivityIndicator.SetActive(false);
		Invoke("setAppropriateProducts", 0.01f);
		coinsPlashka.thisScript.enabled = true;
	}

	private void setAppropriateProducts()
	{
		_products = _listener._products;
	}

	private void hideActiveInd(string error)
	{
		activeInicator = false;
		Debug.Log("activeInicator=false; " + error);
	}

	private void OnEnable()
	{
		StoreKitManager.purchaseSuccessfulEvent += ElixirBuy;
	}

	private void OnDisable()
	{
		StoreKitManager.purchaseSuccessfulEvent -= ElixirBuy;
	}

	private void OnDestroy()
	{
		coinsPlashka.thisScript.enabled = false;
	}

	public void ElixirBuy()
	{
		activeInicator = false;
		_purchaseActivityIndicator.SetActive(activeInicator);
		_Resurrect();
	}

	private void ElixirBuy(StoreKitTransaction t)
	{
		if (t.productIdentifier.Equals(StoreKitEventListener.elixirID))
		{
			ElixirBuy();
		}
	}

	private void _Resurrect()
	{
		Defs.NumberOfElixirs--;
		WeaponManager component = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
		foreach (Weapon playerWeapon in component.playerWeapons)
		{
			WeaponSounds component2 = playerWeapon.weaponPrefab.GetComponent<WeaponSounds>();
			if (playerWeapon.currentAmmoInClip + playerWeapon.currentAmmoInBackpack < component2.InitialAmmo + component2.ammoInClip)
			{
				playerWeapon.currentAmmoInClip = component2.ammoInClip;
				playerWeapon.currentAmmoInBackpack = component2.InitialAmmo;
			}
		}
		if (GlobalGameController.currentLevel == GlobalGameController.levelMapping[0])
		{
			GlobalGameController.currentLevel = 101;
		}
		else
		{
			GlobalGameController.decrementLevel();
		}
		PlayerPrefs.SetFloat(Defs.CurrentHealthSett, Player_move_c.MaxPlayerHealth);
		PlayerPrefs.SetFloat(Defs.CurrentArmorSett, 0f);
		Application.LoadLevel("Loading");
	}

	private void _Retry()
	{
	}

	private void _Buy()
	{
		Defs.NumberOfElixirs++;
		ElixirBuy();
	}

	private void OnGUI()
	{
		int depth = GUI.depth;
		_purchaseActivityIndicator.SetActive(activeInicator);
		float num = (float)Screen.width * 0.31f;
		float num2 = num * ((float)resurrect.normal.background.height / (float)resurrect.normal.background.width);
		float num3 = num2 * 0.2f;
		Rect position = new Rect((float)(Screen.width / 2) - num / 2f, (float)Screen.height - num2 * 3f - num3 * 3f, num, num2);
		GUI.enabled = !haveNoElixirSh && !activeInicator;
		if (GUI.Button(position, string.Empty, resurrect))
		{
			if (Defs.NumberOfElixirs > 0)
			{
				_Resurrect();
			}
			else
			{
				haveNoElixirSh = true;
			}
		}
		GUI.enabled = !haveNoElixirSh && !activeInicator;
		if (GUI.Button(new Rect((float)(Screen.width / 2) - num / 2f, (float)Screen.height - num2 * 2f - num3 * 2f, num, num2), string.Empty, retry))
		{
			GUI.enabled = true;
			GlobalGameController.ResetParameters();
			GlobalGameController.Score = 0;
			GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>().Reset();
			PlayerPrefs.SetFloat(Defs.CurrentHealthSett, Player_move_c.MaxPlayerHealth);
			PlayerPrefs.SetFloat(Defs.CurrentArmorSett, 0f);
			Application.LoadLevel("LoadingNoWait");
		}
		float num4 = num * ((float)quit.normal.background.width / (float)resurrect.normal.background.width);
		float height = num4 * ((float)quit.normal.background.height / (float)quit.normal.background.width);
		if (GUI.Button(new Rect((float)Screen.width * 0.491f - num4 / 2f, (float)Screen.height - num2 - num3 * 1f, num4, height), string.Empty, quit))
		{
			GUI.enabled = true;
			Application.LoadLevel("Restart");
		}
		float num5 = num * 0.4f;
		float num6 = num5 * ((float)elixir.height / (float)elixir.width);
		GUI.DrawTexture(new Rect(position.x + position.width + num3, position.y + position.height / 2f - num6 / 2f, num5, num6), elixir);
		if (haveNoElixirSh)
		{
			GUI.enabled = !activeInicator;
			float num7 = (float)Screen.width * 0.45f * 2f;
			float num8 = num7 * ((float)((_products.Count <= 0) ? noElixirNOinet : noElixir).height / (float)((_products.Count <= 0) ? noElixirNOinet : noElixir).width);
			float num9 = num7 * 0.27f;
			float num10 = num9 * ((float)buy.normal.background.height / (float)buy.normal.background.width);
			float num11 = num9 / 10f;
			float num12 = num10 * ((_products.Count <= 0) ? 1.5f : 3f);
			GUI.DrawTexture(new Rect((float)(Screen.width / 2) - num7 / 2f, (float)(Screen.height / 2) - num8 / 2f, num7, num8), (_products.Count <= 0) ? noElixirNOinet : noElixir);
			if (_products.Count > 0 && GUI.Button(new Rect((float)(Screen.width / 2) + num11, (float)(Screen.height / 2) + num12, num9, num10), string.Empty, buy))
			{
				_003COnGUI_003Ec__AnonStorey14 _003COnGUI_003Ec__AnonStorey = new _003COnGUI_003Ec__AnonStorey14();
				_003COnGUI_003Ec__AnonStorey._003C_003Ef__this = this;
				_003COnGUI_003Ec__AnonStorey.act = null;
				_003COnGUI_003Ec__AnonStorey.act = _003COnGUI_003Ec__AnonStorey._003C_003Em__0;
				_003COnGUI_003Ec__AnonStorey.act();
			}
			if (haveNoElixirSh && GUI.Button(new Rect((float)(Screen.width / 2) - ((_products.Count <= 0) ? (num9 / 2f) : (num11 + num9)), (float)(Screen.height / 2) + num12, num9, num10), string.Empty, (_products.Count <= 0) ? ok : decline))
			{
				haveNoElixirSh = false;
			}
			GUI.enabled = false;
		}
		GUI.depth = depth;
	}
}
