using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Holoville.HOTween;
using UnityEngine;

public class Player_move_c : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CshowCategory_003Ec__AnonStorey1B
	{
		internal Action restoreSucceeded;

		internal Action<string> restoreFailde;

		internal void _003C_003Em__14()
		{
			StoreKitManager.receiptValidationSuccessfulEvent -= restoreSucceeded;
			StoreKitManager.restoreTransactionsFailedEvent -= restoreFailde;
			PlayerPrefs.SetInt(Defs.inappsRestored_3_1, 1);
			PlayerPrefs.Save();
		}

		internal void _003C_003Em__15(string but)
		{
			StoreKitManager.receiptValidationSuccessfulEvent -= restoreSucceeded;
			StoreKitManager.restoreTransactionsFailedEvent -= restoreFailde;
		}
	}

	public string myCAnim(string a){
        return Defs.CAnim(_weaponManager.currentWeaponSounds.animationObject, a);
    }

	[CompilerGenerated]
	private sealed class _003CshowCategory_003Ec__AnonStorey1D
	{
		internal int i;

		internal Player_move_c _003C_003Ef__this;
	}

	[CompilerGenerated]
	private sealed class _003CshowCategory_003Ec__AnonStorey1C
	{
		private sealed class _003CshowCategory_003Ec__AnonStorey1F
		{
			private sealed class _003CshowCategory_003Ec__AnonStorey1E
			{
				internal Action<string> buyItem;

				internal _003CshowCategory_003Ec__AnonStorey1C _003C_003Ef__ref_002428;

				internal _003CshowCategory_003Ec__AnonStorey1F _003C_003Ef__ref_002431;

				internal void _003C_003Em__19(string pressedButton)
				{
					EtceteraManager.alertButtonClickedEvent -= buyItem;
					if (!pressedButton.Equals("Cancel"))
					{
						keychainPlugin.updateKCValue(_003C_003Ef__ref_002431.newCoins, Defs.Coins);
						_003C_003Ef__ref_002428._003C_003Ef__this._weaponManager.AddMinerWeapon(_003C_003Ef__ref_002428.id);
						_003C_003Ef__ref_002428._003C_003Ef__this.PurchaseSuccessful(_003C_003Ef__ref_002428.id);
					}
				}
			}

			internal int newCoins;

			internal Action<string>[] showShop;

			internal _003CshowCategory_003Ec__AnonStorey1D _003C_003Ef__ref_002429;

			internal _003CshowCategory_003Ec__AnonStorey1C _003C_003Ef__ref_002428;

			internal void _003C_003Em__17()
			{
				_003CshowCategory_003Ec__AnonStorey1E _003CshowCategory_003Ec__AnonStorey1E = new _003CshowCategory_003Ec__AnonStorey1E();
				_003CshowCategory_003Ec__AnonStorey1E._003C_003Ef__ref_002428 = _003C_003Ef__ref_002428;
				_003CshowCategory_003Ec__AnonStorey1E._003C_003Ef__ref_002431 = this;
				_003CshowCategory_003Ec__AnonStorey1E.buyItem = null;
				_003CshowCategory_003Ec__AnonStorey1E.buyItem = _003CshowCategory_003Ec__AnonStorey1E._003C_003Em__19;
				EtceteraManager.alertButtonClickedEvent += _003CshowCategory_003Ec__AnonStorey1E.buyItem;
				EtceteraBinding.showAlertWithTitleMessageAndButtons(string.Empty, "Do you want to buy " + InAppData.inappReadableNames[_003C_003Ef__ref_002428.id] + "?", new string[2] { "Cancel", "Buy" });
			}

			internal void _003C_003Em__18(string pressedbutton)
			{
				EtceteraManager.alertButtonClickedEvent -= showShop[0];
				if (!pressedbutton.Equals("Cancel"))
				{
					coinsShop.thisScript.notEnoughCoins = true;
					coinsShop.thisScript.onReturnAction = _003C_003Ef__ref_002428.act;
					coinsShop.showCoinsShop();
				}
			}
		}

		internal string id;

		internal Action act;

		internal _003CshowCategory_003Ec__AnonStorey1D _003C_003Ef__ref_002429;

		internal Player_move_c _003C_003Ef__this;

		internal void _003C_003Em__16()
		{
			_003CshowCategory_003Ec__AnonStorey1F _003CshowCategory_003Ec__AnonStorey1F = new _003CshowCategory_003Ec__AnonStorey1F();
			_003CshowCategory_003Ec__AnonStorey1F._003C_003Ef__ref_002429 = _003C_003Ef__ref_002429;
			_003CshowCategory_003Ec__AnonStorey1F._003C_003Ef__ref_002428 = this;
			coinsShop.thisScript.notEnoughCoins = false;
			coinsShop.thisScript.onReturnAction = null;
			int num = ((!VirtualCurrencyHelper.prices.ContainsKey(id)) ? (10 * (1 + _003C_003Ef__ref_002429.i)) : VirtualCurrencyHelper.prices[id]);
			_003CshowCategory_003Ec__AnonStorey1F.newCoins = keychainPlugin.getKCValue(Defs.Coins) - num;
			Action action = _003CshowCategory_003Ec__AnonStorey1F._003C_003Em__17;
			_003CshowCategory_003Ec__AnonStorey1F.showShop = null;
			_003CshowCategory_003Ec__AnonStorey1F.showShop = new Action<string>[1] { _003CshowCategory_003Ec__AnonStorey1F._003C_003Em__18 };
			if (_003CshowCategory_003Ec__AnonStorey1F.newCoins >= 0)
			{
				action();
				return;
			}
			EtceteraManager.alertButtonClickedEvent += _003CshowCategory_003Ec__AnonStorey1F.showShop[0];
			EtceteraBinding.showAlertWithTitleMessageAndButtons(string.Empty, "You do not have enough coins. Do you want to buy some?", new string[2] { "Cancel", "Yes!" });
		}
	}

	public GUISkin MySkin;

	public Texture2D ammoTexture;

	public Texture2D scoreTexture;

	public Texture2D enemiesTxture;

	public Texture HeartTexture;

	public Texture buyTexture;

	public Texture head_players;

	public Texture nicksStyle;

	public Texture killsStyle;

	public Texture scoreTextureCOOP;

	public Texture timeTexture;

	public Texture2D AimTexture;

	public int AimTextureWidth = 50;

	public int AimTextureHeight = 50;

	private Transform GunFlash;

	public bool showGUIUnlockFullVersion;

	public Texture fonFull;

	public Texture fonFullNoInet;

	public GUIStyle noStyle;

	public GUIStyle fullVerStyle;

	public GUIStyle unlockStyle;

	public GUIStyle playersWindow;

	public GUIStyle playersWindowFrags;

	public GUIStyle closeRanksStyle;

	public int BulletForce = 5000;

	public GameObject renderAllObjectPrefab;

	private Texture zaglushkaTexture;

	public GUIStyle labelStyle;

	private bool productPurchased;

	public bool killed;

	private Vector2 scrollPosition = Vector2.zero;

	public ZombiManager zombiManager;

	public bool showGUI = true;

	public bool showRanks;

	public Texture minerWeaponSoldTexture;

	public Texture swordSoldTexture;

	public Texture hasElixirTexture;

	public Texture combatRifleSoldTexture;

	public Texture goldenEagleSoldTexture;

	public Texture magicBowSoldTexture;

	public Texture axeBoughtTexture;

	public Texture spasBoughtTexture;

	public Texture chainsawOffTexture;

	public Texture famasOffTexture;

	public Texture GlockOffTexture;

	public Texture scytheOffTexture;

	public Texture shovelOffTexture;

	public Texture elixir;

	public Texture multiplayerInappFon;

	public Texture ranksFon;

	public string[] killedSpisok = new string[3]
	{
		string.Empty,
		string.Empty,
		string.Empty
	};

	public GUIStyle elixirsCountStyle;

	public GUIStyle ranksStyle;

	public GUIStyle shopFromPauseStyle;

	public GUIStyle killedStyle;

	public GUIStyle combatRifleStyle;

	public GUIStyle goldenEagleInappStyle;

	public GUIStyle magicBowInappStyle;

	public GUIStyle spasStyle;

	public GUIStyle axeStyle;

	public GUIStyle famasStyle;

	public GUIStyle glockStyle;

	public GUIStyle chainsawStyle;

	public GUIStyle scytheStyle;

	public GUIStyle shovelStyle;

	public GUIStyle restoreStyle;

	private string[] productIdentifiers = StoreKitEventListener.idsForSingle;

	public string myIp = string.Empty;

	public bool isKilled;

	public bool theEnd;

	public string nickPobeditel;

	private bool _flashing;

	public Texture hitTexture;

	public Texture _skin;

	public float showNoInetTimer = 5f;

	public int countKills;

	public int maxCountKills;

	private GameObject _leftJoystick;

	private GameObject _rightJoystick;

	public float _curHealth;

	private float _timeWhenPurchShown;

	private bool inAppOpenedFromPause;

	public Texture restoreWindowTexture;

	public GUIStyle restoreWindButStyle;

	public GUIStyle cancelEindButStyle;

	private GameObject _label;

	private int currentCategory = -1;

	public float MaxHealth;

	public float curArmor;

	public float MaxArmor;

	public int AmmoBoxWidth = 100;

	public int AmmoBoxHeight = 100;

	public int AmmoBoxOffset = 10;

	public int ScoreBoxWidth = 100;

	public int ScoreBoxHeight = 100;

	public int ScoreBoxOffset = 10;

	public float[] timerShow = new float[3] { -1f, -1f, -1f };

	private float GunFlashLifetime;

	public GameObject[] zoneCreatePlayer;

	public GUIStyle ScoreBox;

	public GUIStyle EnemiesBox;

	public GUIStyle AmmoBox;

	public GUIStyle HealthBox;

	public GUIStyle pauseStyle;

	public GUIStyle pauseFonStyle;

	public GUIStyle resumeStyle;

	public GUIStyle menuStyle;

	public GUIStyle soundStyle;

	public GUIStyle buyStyle;

	public GUIStyle resumePauseStyle;

	public Texture sensitPausePlashka;

	public Texture slow_fast;

	public Texture polzunok;

	private float mySens;

	public GUIStyle sliderSensStyle;

	public GUIStyle thumbSensStyle;

	public GUIStyle enemiesLeftStyle;

	private GameObject damage;

	private bool damageShown;

	public Texture pauseFon;

	private Pauser _pauser;

	public Texture pauseTitle;

	private GameObject _gameController;

	private bool _backWasPressed;

	private GameObject _player;

	private GameObject bulletPrefab;

	private GameObject RedstoneBulletPrefab;

	private GameObject _bulletSpawnPoint;

	public GameObject _purchaseActivityIndicator;

	private GameObject _inAppGameObject;

	public StoreKitEventListener _listener;

	public GUIStyle puliInApp;

	public GUIStyle healthInApp;

	public GUIStyle pulemetInApp;

	public GUIStyle crystalSwordInapp;

	public GUIStyle elixirInapp;

	public bool isInappWinOpen;

	private Dictionary<string, KeyValuePair<Action, GUIStyle>> _actionsForPurchasedItems = new Dictionary<string, KeyValuePair<Action, GUIStyle>>();

	private bool scrollEnabled;

	private Vector2 scrollStartTouch;

	private float otstupMejduProd = 10f;

	private float widthPoduct;

	private List<StoreKitProduct> _products = new List<StoreKitProduct>();

	private List<StoreKitProduct> _productsFull = new List<StoreKitProduct>();

	private ZombieCreator _zombieCreator;

	private WeaponManager ___weaponManager;

	public Texture shopHead;

	public Texture shopFon;

	public GUIStyle[] catStyles;

	public GUIStyle armorStyle;

	public Texture armorShield;

	public Texture[] categoryHeads;

	private Vector2 leftFingerPos = Vector2.zero;

	private Vector2 leftFingerLastPos = Vector2.zero;

	private Vector2 leftFingerMovedBy = Vector2.zero;

	private bool canReceiveSwipes = true;

	public float slideMagnitudeX;

	public float slideMagnitudeY;

	public AudioClip ChangeWeaponClip;

	private PhotonView photonView;

	private float height = (float)Screen.height * 0.078f;

	private float _width = 125f;

	[CompilerGenerated]
	private static Action _003C_003Ef__am_0024cacheA1;

	public static int MaxPlayerHealth
	{
		get
		{
			return 9;
		}
	}

	public float CurHealth
	{
		get
		{
			return _curHealth;
		}
		set
		{
			_curHealth = value;
		}
	}

	public float curHealthProp
	{
		get
		{
			return CurHealth;
		}
		set
		{
			if (CurHealth > value && !damageShown)
			{
				StartCoroutine(FlashWhenHit());
			}
			CurHealth = value;
		}
	}

	public static int FontSizeForMessages
	{
		get
		{
			return Mathf.RoundToInt((float)Screen.height * 0.03f);
		}
	}

	public WeaponManager _weaponManager
	{
		get
		{
			return ___weaponManager;
		}
		set
		{
			___weaponManager = value;
		}
	}

	public void hit(float dam)
	{
		if (curArmor >= dam)
		{
			curArmor -= dam;
		}
		else
		{
			CurHealth -= dam - curArmor;
			curArmor = 0f;
		}
		if (!damageShown)
		{
			StartCoroutine(FlashWhenHit());
		}
	}

	private void RestoreButton(bool disable)
	{
		GUI.enabled = !StoreKitEventListener.purchaseInProcess && !disable;
		Rect symmetricRect = coinsPlashka.symmetricRect;
		symmetricRect.x = (float)Screen.width - coinsPlashka.thisScript.rectButCoins.x - (float)restoreStyle.normal.background.width * Defs.Coef;
		symmetricRect.y += symmetricRect.height / 2f;
		symmetricRect.y -= (float)restoreStyle.normal.background.height / 2f * Defs.Coef;
		symmetricRect.width = (float)restoreStyle.normal.background.width * Defs.Coef;
		symmetricRect.height = (float)restoreStyle.normal.background.height * Defs.Coef;
		if (GUI.Button(symmetricRect, string.Empty, restoreStyle))
		{
			StoreKitEventListener.restoreInProcess = true;
			StoreKitEventListener.purchaseInProcess = true;
			StoreKitBinding.restoreCompletedTransactions();
		}
		GUI.enabled = true && !disable;
	}

	private void WalkAnimation()
	{
		if (_singleOrMultiMine() && (bool)_weaponManager && (bool)_weaponManager.currentWeaponSounds)
		{
			_weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>().CrossFade(myCAnim("Walk"));
		}
	}

	private void IdleAnimation()
	{
		if (_singleOrMultiMine() && (bool)___weaponManager && (bool)___weaponManager.currentWeaponSounds)
		{
			___weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>().CrossFade(myCAnim("Idle"));
		}
	}

	public void hideGUI()
	{
		showGUI = false;
	}

	public void AddWeapon(GameObject weaponPrefab)
	{
		int score;
		if (_weaponManager.AddWeapon(weaponPrefab, out score))
		{
			ChangeWeapon(_weaponManager.CurrentWeaponIndex, false);
			return;
		}
		Debug.Log(" " + (weaponPrefab != _weaponManager.GetPickPrefab()) + " " + (weaponPrefab != _weaponManager.GetSwordPrefab()) + " " + (weaponPrefab != _weaponManager.GetCombatRiflePrefab()) + " " + (weaponPrefab != _weaponManager.GetGoldenEaglePrefab()) + " " + (weaponPrefab != _weaponManager.GetMagicBowPrefab()) + " ");
		if (weaponPrefab != _weaponManager.GetPickPrefab() && weaponPrefab != _weaponManager.GetSwordPrefab() && weaponPrefab != _weaponManager.GetCombatRiflePrefab() && weaponPrefab != _weaponManager.GetGoldenEaglePrefab() && weaponPrefab != _weaponManager.GetMagicBowPrefab() && weaponPrefab != _weaponManager.GetSPASPrefab() && weaponPrefab != _weaponManager.GetAxePrefab() && weaponPrefab != _weaponManager.GetChainsawPrefab() && weaponPrefab != _weaponManager.GetFAMASPrefab() && weaponPrefab != _weaponManager.GetGlockPrefab() && weaponPrefab != _weaponManager.GetScythePrefab() && weaponPrefab != _weaponManager.GetShovelPrefab())
		{
			GlobalGameController.Score += score;
			if (PlayerPrefsX.GetBool(PlayerPrefsX.SndSetting, true))
			{
				base.gameObject.GetComponent<AudioSource>().PlayOneShot(ChangeWeaponClip);
			}
			Debug.Log("AddWeapon not changeWeapon");
			return;
		}
		foreach (Weapon playerWeapon in _weaponManager.playerWeapons)
		{
			if (playerWeapon.weaponPrefab == weaponPrefab)
			{
				ChangeWeapon(_weaponManager.playerWeapons.IndexOf(playerWeapon), false);
				break;
			}
		}
	}

	public void minusLiveFromZombi(int _minusLive)
	{
		photonView.RPC("minusLiveFromZombiRPC", PhotonTargets.All, _minusLive);
	}

	[RPC]
	public void minusLiveFromZombiRPC(int live)
	{
		if (photonView.isMine && !isKilled)
		{
			float num = (float)live - curArmor;
			if (num < 0f)
			{
				curArmor -= live;
				num = 0f;
			}
			else
			{
				curArmor = 0f;
			}
			CurHealth -= num;
		}
		StartCoroutine(Flash(base.gameObject.transform.parent.gameObject));
	}

	public void setParentWeaponHelp(string _tag, GameObject[] players, NetworkViewID idWeapon, NetworkViewID idParent, string _ip, string nameSkin, string _nickName)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(_tag);
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			Debug.Log("------" + gameObject.GetComponent<NetworkView>().viewID);
			GameObject gameObject2 = null;
			if (!idWeapon.Equals(gameObject.GetComponent<NetworkView>().viewID))
			{
				continue;
			}
			gameObject.transform.position = Vector3.zero;
			if (!gameObject.GetComponent<WeaponSounds>().isMelee)
			{
				foreach (Transform item in gameObject.transform)
				{
					if (item.gameObject.name.Equals("BulletSpawnPoint"))
					{
						gameObject2 = item.GetChild(0).gameObject;
						if (((PlayerPrefs.GetString("TypeConnect").Equals("local") && !base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && !photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1)
						{
							gameObject2.SetActive(false);
						}
						break;
					}
				}
			}
			foreach (GameObject gameObject3 in players)
			{
				if (!idParent.Equals(gameObject3.GetComponent<NetworkView>().viewID))
				{
					continue;
				}
				foreach (Transform item2 in gameObject3.transform)
				{
					item2.parent = null;
					item2.position += -Vector3.up * 1000f;
				}
				gameObject.transform.parent = gameObject3.transform;
				gameObject.transform.position = Vector3.zero;
				gameObject.transform.rotation = gameObject3.transform.rotation;
				GameObject gameObject4 = null;
				gameObject4 = gameObject3.transform.GetChild(0).gameObject.GetComponent<WeaponSounds>().bonusPrefab;
				Texture texture = Resources.Load(Path.Combine(Defs.MultSkinsDirectoryName, nameSkin)) as Texture;
				gameObject3.GetComponent<Player_move_c>()._skin = texture;
				gameObject3.transform.parent.gameObject.GetComponent<SkinName>().NickName = _nickName;
				GameObject[] array3 = null;
				SetTextureRecursivelyFrom(stopObjs: (gameObject.GetComponent<WeaponSounds>().isMelee || !(gameObject2 != null)) ? new GameObject[1] { gameObject4 } : new GameObject[2] { gameObject4, gameObject2 }, obj: gameObject3.transform.parent.gameObject, txt: texture);
				if (PlayerPrefs.GetInt("MultyPlayer") == 1 && ((PlayerPrefs.GetString("TypeConnect").Equals("local") && !base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && !photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1 && _label == null)
				{
					GameObject original = Resources.Load("ObjectLabel") as GameObject;
					_label = UnityEngine.Object.Instantiate(original) as GameObject;
					_label.GetComponent<ObjectLabel>().target = base.transform;
					_label.GetComponent<GUIText>().text = _nickName;
				}
			}
		}
	}

	[RPC]
	public void setParentWeapon(NetworkViewID idWeapon, NetworkViewID idParent, string _ip, string nameSkin, string _nickName)
	{
		string[] multiplayerWeaponTags = WeaponManager.multiplayerWeaponTags;
		Debug.Log(string.Concat(idWeapon, "  ", idParent));
		GameObject[] array = GameObject.FindGameObjectsWithTag("PlayerGun");
		string[] array2 = multiplayerWeaponTags;
		foreach (string text in array2)
		{
			setParentWeaponHelp(text, array, idWeapon, idParent, _ip, nameSkin, _nickName);
		}
		GameObject[] array3 = array;
		foreach (GameObject gameObject in array3)
		{
			if (idParent.Equals(gameObject.GetComponent<NetworkView>().viewID))
			{
				gameObject.transform.GetComponent<Player_move_c>().myIp = _ip;
			}
		}
	}

	public void setParentWeaponHelpPhoton(string _tag, GameObject[] players, int idWeapon, int idParent, string _ip, string nameSkin, string _nickName)
	{
		photonView = PhotonView.Get(this);
		GameObject[] array = GameObject.FindGameObjectsWithTag(_tag);
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			GameObject gameObject2 = null;
			if (idWeapon != gameObject.GetComponent<PhotonView>().viewID)
			{
				continue;
			}
			if (!gameObject.GetComponent<WeaponSounds>().isMelee)
			{
				foreach (Transform item in gameObject.transform)
				{
					if (item.gameObject.name.Equals("BulletSpawnPoint"))
					{
						gameObject2 = item.GetChild(0).gameObject;
						if (((PlayerPrefs.GetString("TypeConnect").Equals("local") && !base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && !photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1)
						{
							gameObject2.SetActive(false);
						}
						break;
					}
				}
			}
			foreach (GameObject gameObject3 in players)
			{
				if (idParent != gameObject3.GetComponent<PhotonView>().viewID)
				{
					continue;
				}
				foreach (Transform item2 in gameObject3.transform)
				{
					item2.parent = null;
					item2.position += -Vector3.up * 1000f;
				}
				gameObject.transform.parent = gameObject3.transform;
				gameObject.transform.localPosition = new Vector3(0f, -1.7f, 0f);
				gameObject.transform.rotation = gameObject3.transform.rotation;
				GameObject gameObject4 = null;
				gameObject4 = gameObject3.transform.GetChild(0).gameObject.GetComponent<WeaponSounds>().bonusPrefab;
				Texture texture = Resources.Load(Path.Combine(Defs.MultSkinsDirectoryName, nameSkin)) as Texture;
				gameObject3.GetComponent<Player_move_c>()._skin = texture;
				gameObject3.transform.parent.gameObject.GetComponent<SkinName>().NickName = _nickName;
				GameObject[] array3 = null;
				SetTextureRecursivelyFrom(stopObjs: (gameObject.GetComponent<WeaponSounds>().isMelee || !(gameObject2 != null)) ? new GameObject[1] { gameObject4 } : new GameObject[2] { gameObject4, gameObject2 }, obj: gameObject3.transform.parent.gameObject, txt: texture);
				if (PlayerPrefs.GetInt("MultyPlayer") == 1 && ((PlayerPrefs.GetString("TypeConnect").Equals("local") && !base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && !photonView.isMine)) && _label == null)
				{
					GameObject original = Resources.Load("ObjectLabel") as GameObject;
					_label = UnityEngine.Object.Instantiate(original) as GameObject;
					_label.GetComponent<ObjectLabel>().target = base.transform;
					_label.GetComponent<GUIText>().text = _nickName;
				}
			}
		}
	}

	[RPC]
	public void setParentWeaponPhoton(int idWeapon, int idParent, string _ip, string nameSkin, string _nickName)
	{
		string[] multiplayerWeaponTags = WeaponManager.multiplayerWeaponTags;
		GameObject[] array = GameObject.FindGameObjectsWithTag("PlayerGun");
		string[] array2 = multiplayerWeaponTags;
		foreach (string text in array2)
		{
			setParentWeaponHelpPhoton(text, array, idWeapon, idParent, _ip, nameSkin, _nickName);
		}
		GameObject[] array3 = array;
		foreach (GameObject gameObject in array3)
		{
			if (idParent == gameObject.GetComponent<PhotonView>().viewID)
			{
				gameObject.transform.GetComponent<Player_move_c>().myIp = _ip;
			}
		}
	}

	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		if (null == obj)
		{
			return;
		}
		obj.layer = newLayer;
		foreach (Transform item in obj.transform)
		{
			if (!(null == item))
			{
				SetLayerRecursively(item.gameObject, newLayer);
			}
		}
	}

	public void ChangeWeapon(int index, bool shouldSetMaxAmmo = true)
	{
		photonView = PhotonView.Get(this);
		Quaternion rotation = Quaternion.identity;
		if ((bool)_player)
		{
			rotation = _player.transform.rotation;
		}
		if ((bool)_weaponManager.currentWeaponSounds)
		{
			rotation = _weaponManager.currentWeaponSounds.gameObject.transform.rotation;
			if (PlayerPrefs.GetInt("MultyPlayer") != 1)
			{
				_SetGunFlashActive(false);
				_weaponManager.currentWeaponSounds.gameObject.transform.parent = null;
				UnityEngine.Object.Destroy(_weaponManager.currentWeaponSounds.gameObject);
			}
			else
			{
				_weaponManager.currentWeaponSounds.gameObject.transform.parent = null;
				if (PlayerPrefs.GetString("TypeConnect").Equals("inet"))
				{
					PhotonNetwork.Destroy(_weaponManager.currentWeaponSounds.gameObject);
				}
				else
				{
					Network.Destroy(_weaponManager.currentWeaponSounds.gameObject);
				}
			}
			_weaponManager.currentWeaponSounds = null;
		}
		GameObject gameObject;
		if (PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			gameObject = (GameObject)UnityEngine.Object.Instantiate(((Weapon)_weaponManager.playerWeapons[index]).weaponPrefab, Vector3.zero, Quaternion.identity);
			gameObject.transform.parent = base.gameObject.transform;
			gameObject.transform.rotation = rotation;
		}
		else if (PlayerPrefs.GetString("TypeConnect").Equals("inet"))
		{
			gameObject = PhotonNetwork.Instantiate("Weapons/" + ((Weapon)_weaponManager.playerWeapons[index]).weaponPrefab.name, -Vector3.up * 1000f, Quaternion.identity, 0);
			gameObject.transform.position = -1000f * Vector3.up;
			string ipAddress = Network.player.ipAddress;
			photonView.RPC("setParentWeaponPhoton", PhotonTargets.AllBuffered, gameObject.GetComponent<PhotonView>().viewID, base.gameObject.GetComponent<PhotonView>().viewID, ipAddress, PlayerPrefs.GetString("SkinNameMultiplayer", Defs.SkinBaseName + 1), PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName));
		}
		else
		{
			gameObject = (GameObject)Network.Instantiate(((Weapon)_weaponManager.playerWeapons[index]).weaponPrefab, -Vector3.up * 1000f, Quaternion.identity, 0);
			gameObject.transform.position = -1000f * Vector3.up;
			base.GetComponent<NetworkView>().RPC("setParentWeapon", RPCMode.AllBuffered, gameObject.GetComponent<NetworkView>().viewID, base.gameObject.GetComponent<NetworkView>().viewID, Network.player.ipAddress, PlayerPrefs.GetString("SkinNameMultiplayer", Defs.SkinBaseName + 1), PlayerPrefs.GetString("NamePlayer", Defs.defaultPlayerName));
			Debug.Log("nw.GetComponent<WeaponSounds> ().isSerialShooting=" + gameObject.GetComponent<WeaponSounds>().isSerialShooting);
		}
		SetLayerRecursively(gameObject, 9);
		_weaponManager.CurrentWeaponIndex = index;
		_weaponManager.currentWeaponSounds = gameObject.GetComponent<WeaponSounds>();
		Vector3 vector = ((PlayerPrefs.GetInt("MultyPlayer") != 1) ? _weaponManager.currentWeaponSounds.gunPosition : new Vector3(0f, _weaponManager.currentWeaponSounds.gunPosition.y, 0f));
		gameObject.transform.position = gameObject.transform.parent.TransformPoint(_weaponManager.currentWeaponSounds.gunPosition);
		PlayerPrefs.SetInt("setSeriya", _weaponManager.currentWeaponSounds.isSerialShooting ? 1 : 0);
		PlayerPrefs.Save();
		_rightJoystick.SendMessage("setSeriya", _weaponManager.currentWeaponSounds.isSerialShooting, SendMessageOptions.DontRequireReceiver);
		if (shouldSetMaxAmmo)
		{
		}
		if (((Weapon)_weaponManager.playerWeapons[_weaponManager.CurrentWeaponIndex]).currentAmmoInClip > 0 || _weaponManager.currentWeaponSounds.isMelee)
		{
			_rightJoystick.SendMessage("HasAmmo");
		}
		else
		{
			_rightJoystick.SendMessage("NoAmmo");
		}
		_weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>()[myCAnim("Reload")].layer = 1;
		_weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>()[myCAnim("Shoot")].layer = 1;
		if (!_weaponManager.currentWeaponSounds.isMelee)
		{
			foreach (Transform item in _weaponManager.currentWeaponSounds.gameObject.transform)
			{
				if (item.name.Equals("BulletSpawnPoint"))
				{
					_bulletSpawnPoint = item.gameObject;
					break;
				}
			}
			GunFlash = GameObject.Find("GunFlash").transform;
		}
		SendSpeedModifier();
		if (PlayerPrefsX.GetBool(PlayerPrefsX.SndSetting, true))
		{
			base.gameObject.GetComponent<AudioSource>().PlayOneShot(ChangeWeaponClip);
		}
	}

	private void SendSpeedModifier()
	{
		if (_player != null)
		{
			_player.SendMessage("SetSpeedModifier", _weaponManager.currentWeaponSounds.speedModifier);
		}
	}

	public bool NeedAmmo()
	{
		int currentWeaponIndex = _weaponManager.CurrentWeaponIndex;
		Weapon weapon = (Weapon)_weaponManager.playerWeapons[currentWeaponIndex];
		return weapon.currentAmmoInBackpack < _weaponManager.currentWeaponSounds.MaxAmmoWithRespectToInApp;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	[RPC]
	private void setIp(string _ip)
	{
		myIp = _ip;
		Debug.Log("myIp=" + Network.player.ipAddress + " setIp=" + _ip + "id=" + base.transform.parent.transform.GetComponent<NetworkView>().viewID);
	}

	private int Comparison(StoreKitProduct a, StoreKitProduct b)
	{
		return Array.IndexOf(productIdentifiers, a.productIdentifier).CompareTo(Array.IndexOf(productIdentifiers, b.productIdentifier));
	}

	private void SetProducts(List<StoreKitProduct> allProducts)
	{
		Invoke("setAppropriateProducts", 0.01f);
	}

	private void setAppropriateProducts()
	{
		_products = ((PlayerPrefs.GetInt("MultyPlayer") == 1) ? _listener._multiplayerProducts : _listener._products);
		_products.Sort(Comparison);
		_productsFull = _listener._fullProducts;
	}

	private void Start()
	{
		widthPoduct = (float)(healthInApp.normal.background.width * Screen.height) / 768f * (320f / (float)healthInApp.normal.background.height);
		photonView = PhotonView.Get(this);
		if (PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			productIdentifiers = StoreKitEventListener.idsForSingle;
		}
		else
		{
			productIdentifiers = StoreKitEventListener.idsForMulti;
			if (PlayerPrefs.GetInt("COOP", 0) == 1)
			{
				zombiManager = GameObject.FindGameObjectWithTag("ZombiCreator").GetComponent<ZombiManager>();
			}
		}
		maxCountKills = int.Parse(PlayerPrefs.GetString("MaxKill", "10"));
		if (PlayerPrefs.GetInt("MultyPlayer") == 1 && PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)
		{
			maxCountKills = int.Parse(PhotonNetwork.room.customProperties["MaxKill"].ToString());
		}
		Debug.Log("maxCountKills=" + maxCountKills + " " + PlayerPrefs.GetString("MaxKill", "10"));
		if (PlayerPrefs.GetInt("MultyPlayer") != 1 || (((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1))
		{
			_actionsForPurchasedItems.Add(StoreKitEventListener.bigAmmoPackID, new KeyValuePair<Action, GUIStyle>(ProvideAmmo, puliInApp));
			_actionsForPurchasedItems.Add(StoreKitEventListener.fullHealthID, new KeyValuePair<Action, GUIStyle>(ProvideHealth, healthInApp));
			_actionsForPurchasedItems.Add(StoreKitEventListener.minerWeaponID, new KeyValuePair<Action, GUIStyle>(provideminerweapon, pulemetInApp));
			Dictionary<string, KeyValuePair<Action, GUIStyle>> actionsForPurchasedItems = _actionsForPurchasedItems;
			string elixirID = StoreKitEventListener.elixirID;
			if (_003C_003Ef__am_0024cacheA1 == null)
			{
				_003C_003Ef__am_0024cacheA1 = _003CStart_003Em__11;
			}
			actionsForPurchasedItems.Add(elixirID, new KeyValuePair<Action, GUIStyle>(_003C_003Ef__am_0024cacheA1, elixirInapp));
			_actionsForPurchasedItems.Add(StoreKitEventListener.crystalswordID, new KeyValuePair<Action, GUIStyle>(providesword, crystalSwordInapp));
			_actionsForPurchasedItems.Add(StoreKitEventListener.combatrifle, new KeyValuePair<Action, GUIStyle>(providecombatrifle, combatRifleStyle));
			_actionsForPurchasedItems.Add(StoreKitEventListener.goldeneagle, new KeyValuePair<Action, GUIStyle>(providegoldeneagle, goldenEagleInappStyle));
			_actionsForPurchasedItems.Add(StoreKitEventListener.magicbow, new KeyValuePair<Action, GUIStyle>(providemagicbow, magicBowInappStyle));
			_actionsForPurchasedItems.Add(StoreKitEventListener.spas, new KeyValuePair<Action, GUIStyle>(providespas, spasStyle));
			_actionsForPurchasedItems.Add(StoreKitEventListener.axe, new KeyValuePair<Action, GUIStyle>(provideaxe, axeStyle));
			_actionsForPurchasedItems.Add(StoreKitEventListener.armor, new KeyValuePair<Action, GUIStyle>(_003CStart_003Em__12, armorStyle));
			_actionsForPurchasedItems.Add(StoreKitEventListener.famas, new KeyValuePair<Action, GUIStyle>(provideFAMAS, famasStyle));
			_actionsForPurchasedItems.Add(StoreKitEventListener.glock, new KeyValuePair<Action, GUIStyle>(provideGlock, glockStyle));
			_actionsForPurchasedItems.Add(StoreKitEventListener.chainsaw, new KeyValuePair<Action, GUIStyle>(provideChainsaw, chainsawStyle));
			_actionsForPurchasedItems.Add(StoreKitEventListener.scythe, new KeyValuePair<Action, GUIStyle>(provideScythe, scytheStyle));
			_actionsForPurchasedItems.Add(StoreKitEventListener.shovel, new KeyValuePair<Action, GUIStyle>(provideShovel, shovelStyle));
			_purchaseActivityIndicator = StoreKitEventListener.purchaseActivityInd;
			_purchaseActivityIndicator.SetActive(false);
		}
		_inAppGameObject = GameObject.FindGameObjectWithTag("InAppGameObject");
		_listener = _inAppGameObject.GetComponent<StoreKitEventListener>();
		if (PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			foreach (Transform item in base.transform.parent)
			{
				if (item.gameObject.name.Equals("FPS_Player"))
				{
					item.gameObject.SetActive(false);
					break;
				}
			}
		}
		zoneCreatePlayer = GameObject.FindGameObjectsWithTag("MultyPlayerCreateZone");
		HOTween.Init(true, true, true);
		HOTween.EnableOverwriteManager();
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			if ((((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1) || PlayerPrefs.GetInt("MultyPlayer") != 1)
			{
				showGUI = true;
			}
			else
			{
				showGUI = false;
			}
		}
		zaglushkaTexture = Resources.Load("zaglushka") as Texture;
		if (PlayerPrefs.GetInt("MultyPlayer") != 1 || (((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1))
		{
			SetProducts(null);
			StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
		}
		if ((PlayerPrefs.GetInt("MultyPlayer") != 1 || (((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1)) && StoreKitBinding.canMakePayments())
		{
			StoreKitManager.productListReceivedEvent += SetProducts;
		}
		if ((((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1) || PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			_player = base.transform.parent.gameObject;
		}
		else
		{
			_player = null;
		}
		_weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
		if (((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			foreach (Weapon playerWeapon in _weaponManager.playerWeapons)
			{
				playerWeapon.currentAmmoInClip = playerWeapon.weaponPrefab.GetComponent<WeaponSounds>().ammoInClip;
				playerWeapon.currentAmmoInBackpack = playerWeapon.weaponPrefab.GetComponent<WeaponSounds>().InitialAmmo;
			}
		}
		if (((PlayerPrefs.GetString("TypeConnect").Equals("local") && !base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && !photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			base.gameObject.transform.parent.transform.Find("LeftTouchPad").gameObject.SetActive(false);
			base.gameObject.transform.parent.transform.Find("RightTouchPad").gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetInt("MultyPlayer") != 1 || (((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1))
		{
			GameObject original = Resources.Load("Damage") as GameObject;
			damage = (GameObject)UnityEngine.Object.Instantiate(original);
			Color color = damage.GetComponent<GUITexture>().color;
			color.a = 0f;
			damage.GetComponent<GUITexture>().color = color;
		}
		if (PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			_gameController = GameObject.FindGameObjectWithTag("GameController");
			_zombieCreator = _gameController.GetComponent<ZombieCreator>();
		}
		_pauser = GameObject.FindGameObjectWithTag("GameController").GetComponent<Pauser>();
		_leftJoystick = GameObject.Find("LeftTouchPad");
		_rightJoystick = GameObject.Find("RightTouchPad");
		if (_singleOrMultiMine())
		{
			ChangeWeapon(_weaponManager.CurrentWeaponIndex, false);
			_weaponManager.myGun = base.gameObject;
			if (_weaponManager.currentWeaponSounds != null)
			{
				_weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>()[myCAnim("Reload")].layer = 1;
				_weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>().Stop();
			}
		}
		_SetGunFlashActive(false);
		if (PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			CurHealth = PlayerPrefs.GetFloat(Defs.CurrentHealthSett, MaxPlayerHealth);
			curArmor = PlayerPrefs.GetFloat(Defs.CurrentArmorSett, MaxArmor);
		}
		else
		{
			CurHealth = MaxPlayerHealth;
			curArmor = 0f;
		}
		Invoke("SendSpeedModifier", 0.5f);
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(renderAllObjectPrefab, Vector3.zero, Quaternion.identity);
	}

	public bool _singleOrMultiMine()
	{
		if (PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			return true;
		}
		return (((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && (bool)photonView && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1) || PlayerPrefs.GetInt("MultyPlayer") != 1;
	}

	private void OnDestroy()
	{
		coinsShop.hideCoinsShop();
		coinsPlashka.hidePlashka();
		if (PlayerPrefs.GetInt("MultyPlayer", 0) == 1 && ((PlayerPrefs.GetString("TypeConnect").Equals("local") && !base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && (bool)photonView && !photonView.isMine)) && _label != null)
		{
			UnityEngine.Object.Destroy(_label);
		}
		if (PlayerPrefs.GetInt("MultyPlayer") != 1 || (((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && (bool)photonView && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1))
		{
			StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessful;
			StoreKitManager.productListReceivedEvent -= SetProducts;
		}
	}

	private void _SetGunFlashActive(bool state)
	{
		if (!_weaponManager.currentWeaponSounds.isMelee && GunFlash != null)
		{
			GunFlash.gameObject.SetActive(state);
		}
	}

	[RPC]
	private void ReloadGun(NetworkViewID id)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("PlayerGun");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (id.Equals(gameObject.GetComponent<NetworkView>().viewID))
			{
				gameObject.transform.GetChild(0).GetComponent<WeaponSounds>().animationObject.GetComponent<Animation>().Play(myCAnim("Reload"));
				gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.transform.GetChild(0).GetComponent<WeaponSounds>().reload);
			}
		}
	}

	[RPC]
	private void ReloadGunPhoton(int id)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("PlayerGun");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (id == gameObject.GetComponent<PhotonView>().viewID)
			{
				gameObject.transform.GetChild(0).GetComponent<WeaponSounds>().animationObject.GetComponent<Animation>().Play(myCAnim("Reload"));
				gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.transform.GetChild(0).GetComponent<WeaponSounds>().reload);
			}
		}
	}

	private void ReloadPressed()
	{
		if (_weaponManager.currentWeaponSounds.isMelee || _weaponManager.CurrentWeaponIndex < 0 || _weaponManager.CurrentWeaponIndex >= _weaponManager.playerWeapons.Count || ((Weapon)_weaponManager.playerWeapons[_weaponManager.CurrentWeaponIndex]).currentAmmoInBackpack <= 0 || ((Weapon)_weaponManager.playerWeapons[_weaponManager.CurrentWeaponIndex]).currentAmmoInClip == _weaponManager.currentWeaponSounds.ammoInClip)
		{
			return;
		}
		_weaponManager.Reload();
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
			{
				base.GetComponent<NetworkView>().RPC("ReloadGun", RPCMode.Others, base.gameObject.GetComponent<NetworkView>().viewID);
			}
			else
			{
				photonView.RPC("ReloadGunPhoton", PhotonTargets.Others, base.gameObject.GetComponent<PhotonView>().viewID);
			}
		}
		if (PlayerPrefsX.GetBool(PlayerPrefsX.SndSetting, true))
		{
			base.GetComponent<AudioSource>().PlayOneShot(_weaponManager.currentWeaponSounds.reload);
		}
		_rightJoystick.SendMessage("HasAmmo");
	}

	private void ShotPressed()
	{
		if (_weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>().IsPlaying(myCAnim("Shoot")) || _weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>().IsPlaying(myCAnim("Reload")) || _weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>().IsPlaying(myCAnim("Empty")))
		{
			return;
		}
		_weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>().Stop();
		if (_weaponManager.currentWeaponSounds.isMelee)
		{
			_Shot();
		}
		else if (((Weapon)_weaponManager.playerWeapons[_weaponManager.CurrentWeaponIndex]).currentAmmoInClip > 0)
		{
			((Weapon)_weaponManager.playerWeapons[_weaponManager.CurrentWeaponIndex]).currentAmmoInClip--;
			if (((Weapon)_weaponManager.playerWeapons[_weaponManager.CurrentWeaponIndex]).currentAmmoInClip == 0)
			{
				_rightJoystick.SendMessage("NoAmmo");
			}
			_Shot();
			_SetGunFlashActive(true);
			GunFlashLifetime = 0.1f;
		}
		else
		{
			_weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>().Play(myCAnim("Empty"));
			if (PlayerPrefsX.GetBool(PlayerPrefsX.SndSetting, true))
			{
				base.GetComponent<AudioSource>().PlayOneShot(_weaponManager.currentWeaponSounds.empty);
			}
		}
	}

	private void _Shot()
	{
		_weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>().Play(myCAnim("Shoot"));
		shootS();
		if (PlayerPrefsX.GetBool(PlayerPrefsX.SndSetting, true))
		{
			base.GetComponent<AudioSource>().PlayOneShot(_weaponManager.currentWeaponSounds.shoot);
		}
	}

	public void sendImDeath(string _name)
	{
		if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
		{
			base.GetComponent<NetworkView>().RPC("imDeath", RPCMode.All, _name);
		}
		else
		{
			photonView.RPC("imDeath", PhotonTargets.All, _name);
		}
	}

	public void setInString(string nick)
	{
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[2] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[1];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[1] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[0];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[0] = nick + " joined the game.";
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[2] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[1];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[1] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[0];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[0] = 3f;
	}

	public void setOutString(string nick)
	{
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[2] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[1];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[1] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[0];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[0] = nick + " left the game.";
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[2] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[1];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[1] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[0];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[0] = 3f;
	}

	[RPC]
	public void imDeath(string _name)
	{
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[2] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[1];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[1] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[0];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[0] = _name + " fell to death";
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[2] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[1];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[1] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[0];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[0] = 3f;
	}

	[RPC]
	public void Killed(NetworkViewID idKiller, NetworkViewID id)
	{
		if (_weaponManager == null || _weaponManager.myPlayer == null)
		{
			return;
		}
		string text = string.Empty;
		string text2 = string.Empty;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (gameObject.GetComponent<NetworkView>().viewID.Equals(idKiller))
			{
				text = gameObject.GetComponent<SkinName>().NickName;
			}
			if (gameObject.GetComponent<NetworkView>().viewID.Equals(id))
			{
				text2 = gameObject.GetComponent<SkinName>().NickName;
			}
			if (gameObject.GetComponent<NetworkView>().viewID.Equals(idKiller) && gameObject == _weaponManager.myPlayer)
			{
				countKills++;
				_weaponManager.myTable.GetComponent<NetworkStartTable>().CountKills = countKills;
				_weaponManager.myTable.GetComponent<NetworkStartTable>().synchState();
				if (countKills >= maxCountKills)
				{
					base.GetComponent<NetworkView>().RPC("pobeda", RPCMode.AllBuffered, idKiller);
					PlayerPrefs.SetInt("Rating", PlayerPrefs.GetInt("Rating", 0) + 1);
				}
				Debug.Log("killedCount " + countKills + " Rating=" + PlayerPrefs.GetInt("Rating", 0));
			}
		}
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[2] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[1];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[1] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[0];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[0] = text + " kill " + text2;
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[2] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[1];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[1] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[0];
		_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[0] = 3f;
	}

	[RPC]
	public void KilledPhoton(int idKiller, int id)
	{
		if (_weaponManager == null || _weaponManager.myPlayer == null)
		{
			return;
		}
		string text = string.Empty;
		string text2 = string.Empty;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (gameObject.GetComponent<PhotonView>().viewID == idKiller)
			{
				text = gameObject.GetComponent<SkinName>().NickName;
			}
			if (gameObject.GetComponent<PhotonView>().viewID == id)
			{
				text2 = gameObject.GetComponent<SkinName>().NickName;
			}
			if (gameObject.GetComponent<PhotonView>().viewID == idKiller && gameObject == _weaponManager.myPlayer)
			{
				countKills++;
				_weaponManager.myTable.GetComponent<NetworkStartTable>().CountKills = countKills;
				_weaponManager.myTable.GetComponent<NetworkStartTable>().synchState();
				if (countKills >= maxCountKills)
				{
					photonView.RPC("pobedaPhoton", PhotonTargets.AllBuffered, idKiller);
					PlayerPrefs.SetInt("Rating", PlayerPrefs.GetInt("Rating", 0) + 1);
					_weaponManager.myTable.GetComponent<NetworkStartTable>().isIwin = true;
				}
				Debug.Log("killedCount " + countKills + " Rating=" + PlayerPrefs.GetInt("Rating", 0));
			}
		}
		if (_weaponManager.myPlayer != null)
		{
			_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[2] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[1];
			_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[1] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[0];
			_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().killedSpisok[0] = text + " kill " + text2;
			_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[2] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[1];
			_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[1] = _weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[0];
			_weaponManager.myPlayer.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().timerShow[0] = 3f;
		}
	}

	[RPC]
	public void pobeda(NetworkViewID idKiller)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (idKiller.Equals(gameObject.GetComponent<NetworkView>().viewID))
			{
				nickPobeditel = gameObject.GetComponent<SkinName>().NickName;
				Debug.Log("Pobeditel " + nickPobeditel);
			}
		}
		GameObject.FindGameObjectWithTag("NetworkTable").GetComponent<NetworkStartTable>().win(nickPobeditel);
	}

	[RPC]
	public void pobedaPhoton(int idKiller)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (idKiller == gameObject.GetComponent<PhotonView>().viewID)
			{
				nickPobeditel = gameObject.GetComponent<SkinName>().NickName;
				Debug.Log("Pobeditel " + nickPobeditel);
			}
		}
		GameObject.FindGameObjectWithTag("NetworkTable").GetComponent<NetworkStartTable>().win(nickPobeditel);
	}

	[RPC]
	public void minusLive(NetworkViewID id, NetworkViewID idKiller, float minus)
	{
		if (_weaponManager == null || _weaponManager.myPlayer == null)
		{
			return;
		}
		Debug.Log(string.Concat(idKiller, " poopak v ", id, "   "));
		if (id.Equals(base.transform.parent.transform.GetComponent<NetworkView>().viewID))
		{
			return;
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (!id.Equals(gameObject.GetComponent<NetworkView>().viewID))
			{
				continue;
			}
			foreach (Transform item in gameObject.transform)
			{
				if (!item.gameObject.name.Equals("GameObject"))
				{
					continue;
				}
				Debug.Log("------minus live------ " + item.gameObject.GetComponent<Player_move_c>().CurHealth);
				if (gameObject.Equals(_weaponManager.myPlayer) && !gameObject.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().isKilled)
				{
					float num = minus - item.gameObject.GetComponent<Player_move_c>().curArmor;
					if (num < 0f)
					{
						item.gameObject.GetComponent<Player_move_c>().curArmor -= minus;
						num = 0f;
					}
					else
					{
						item.gameObject.GetComponent<Player_move_c>().curArmor = 0f;
					}
					item.gameObject.GetComponent<Player_move_c>().CurHealth -= num;
					if (item.gameObject.GetComponent<Player_move_c>().CurHealth <= 0f)
					{
						base.GetComponent<NetworkView>().RPC("Killed", RPCMode.All, idKiller, id);
					}
				}
				break;
			}
			StartCoroutine(Flash(gameObject));
		}
	}

	[RPC]
	public void minusLivePhoton(int id, int idKiller, float minus)
	{
		if (_weaponManager == null || _weaponManager.myPlayer == null || id == base.transform.parent.transform.GetComponent<PhotonView>().viewID)
		{
			return;
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (id != gameObject.GetComponent<PhotonView>().viewID)
			{
				continue;
			}
			foreach (Transform item in gameObject.transform)
			{
				if (!item.gameObject.name.Equals("GameObject"))
				{
					continue;
				}
				if (gameObject.Equals(_weaponManager.myPlayer) && !gameObject.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>().isKilled)
				{
					float num = minus - item.gameObject.GetComponent<Player_move_c>().curArmor;
					if (num < 0f)
					{
						item.gameObject.GetComponent<Player_move_c>().curArmor -= minus;
						num = 0f;
					}
					else
					{
						item.gameObject.GetComponent<Player_move_c>().curArmor = 0f;
					}
					item.gameObject.GetComponent<Player_move_c>().CurHealth -= num;
					if (item.gameObject.GetComponent<Player_move_c>().CurHealth <= 0f)
					{
						Debug.Log(idKiller + " kill " + id);
						photonView.RPC("KilledPhoton", PhotonTargets.All, idKiller, id);
					}
				}
				break;
			}
			StartCoroutine(Flash(gameObject));
		}
	}

	public static void SetTextureRecursivelyFrom(GameObject obj, Texture txt, GameObject[] stopObjs)
	{
		foreach (Transform item in obj.transform)
		{
			bool flag = false;
			foreach (GameObject gameObject in stopObjs)
			{
				if (item.gameObject == gameObject)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				continue;
			}
			if ((bool)item.gameObject.GetComponent<Renderer>() && (bool)item.gameObject.GetComponent<Renderer>().material)
			{
				if (item.gameObject.GetComponent<Renderer>().materials.Length > 1 && item.gameObject.name.Equals("raven_head"))
				{
					Material[] materials = item.gameObject.GetComponent<Renderer>().materials;
					foreach (Material material in materials)
					{
						if (material.name.Equals("raven_eye (Instance)"))
						{
							if (GlobalGameController.previousLevel == 5)
							{
								material.color = new Color(0.32156864f, 0f, 44f / 85f);
							}
						}
						else
						{
							material.mainTexture = txt;
						}
					}
				}
				else
				{
					item.gameObject.GetComponent<Renderer>().material.mainTexture = txt;
				}
			}
			flag = false;
			foreach (GameObject gameObject2 in stopObjs)
			{
				if (item.gameObject == gameObject2)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				SetTextureRecursivelyFrom(item.gameObject, txt, stopObjs);
			}
		}
	}

	private IEnumerator Flash(GameObject _obj)
	{
		_flashing = true;
		GameObject _gunWiapon = null;
		GameObject gunFlashTmp = null;
		foreach (Transform chaild in _obj.transform)
		{
			if (chaild.gameObject.name.Equals("GameObject"))
			{
				WeaponSounds ws = chaild.transform.GetChild(0).gameObject.GetComponent<WeaponSounds>();
				_gunWiapon = ws.bonusPrefab;
				if (!ws.isMelee)
				{
					gunFlashTmp = chaild.transform.GetChild(0).Find("BulletSpawnPoint").transform.GetChild(0).gameObject;
				}
				break;
			}
		}
		GameObject[] stopObjs2 = null;
		stopObjs2 = ((!(gunFlashTmp != null)) ? new GameObject[1] { _gunWiapon } : new GameObject[2] { _gunWiapon, gunFlashTmp });
		SetTextureRecursivelyFrom(_obj, hitTexture, stopObjs2);
		yield return new WaitForSeconds(0.125f);
		if (_obj != null)
		{
			SetTextureRecursivelyFrom(_obj, _obj.GetComponent<SkinName>().playerGameObject.GetComponent<Player_move_c>()._skin, stopObjs2);
		}
		_flashing = false;
	}

	[RPC]
	private void fireFlash(NetworkViewID id, bool isFlash)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("PlayerGun");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (id.Equals(gameObject.GetComponent<NetworkView>().viewID))
			{
				if (isFlash)
				{
					gameObject.transform.GetChild(0).GetComponent<FlashFire>().fire();
				}
				gameObject.transform.GetChild(0).GetComponent<WeaponSounds>().animationObject.GetComponent<Animation>().Play(myCAnim("Shoot"));
				gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.transform.GetChild(0).GetComponent<WeaponSounds>().shoot);
			}
		}
	}

	[RPC]
	private void fireFlashPhoton(int id, bool isFlash)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("PlayerGun");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (id == gameObject.GetComponent<PhotonView>().viewID)
			{
				if (isFlash)
				{
					gameObject.transform.GetChild(0).GetComponent<FlashFire>().fire();
				}
				gameObject.transform.GetChild(0).GetComponent<WeaponSounds>().animationObject.GetComponent<Animation>().Play(myCAnim("Shoot"));
				gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.transform.GetChild(0).GetComponent<WeaponSounds>().shoot);
			}
		}
	}

	public void shootS()
	{
		if (!_weaponManager.currentWeaponSounds.isMelee)
		{	
			//troubleshooting: IF WEAPONS DONT WANT TO SHOOT, REVERT THIS CHANGE BY REMOVING LINE 1612 TO 1619 AND CHANGING BULLETPREFAB TO PUBLIC AND ASSIGNING IT IN THE INSPECTOR!
			if (!_weaponManager.currentWeaponSounds.isRedstone)
			{
				bulletPrefab = Resources.Load("Bullet") as GameObject;
			}
			if (_weaponManager.currentWeaponSounds.isRedstone)
			{
				bulletPrefab = Resources.Load("Bullet_Redstone") as GameObject;
			}
			GameObject gameObject = ((PlayerPrefs.GetInt("MultyPlayer") != 1) ? ((GameObject)UnityEngine.Object.Instantiate(bulletPrefab, _bulletSpawnPoint.transform.position, Quaternion.LookRotation(Camera.main.transform.TransformDirection(Vector3.forward)))) : ((!PlayerPrefs.GetString("TypeConnect").Equals("inet")) ? ((GameObject)Network.Instantiate(bulletPrefab, _bulletSpawnPoint.transform.position, Quaternion.LookRotation(Camera.main.transform.TransformDirection(Vector3.forward)), 0)) : PhotonNetwork.Instantiate(bulletPrefab.name, _bulletSpawnPoint.transform.position, Quaternion.LookRotation(Camera.main.transform.TransformDirection(Vector3.forward)), 0)));
			if (PlayerPrefs.GetInt("MultyPlayer") == 1)
			{
				if (PlayerPrefs.GetString("TypeConnect").Equals("inet"))
				{
					photonView.RPC("fireFlashPhoton", PhotonTargets.Others, base.gameObject.transform.GetComponent<PhotonView>().viewID, true);
				}
				else
				{
					base.GetComponent<NetworkView>().RPC("fireFlash", RPCMode.Others, base.gameObject.transform.GetComponent<NetworkView>().viewID, true);
				}
			}
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
			RaycastHit hitInfo;
			if (!Physics.Raycast(ray, out hitInfo, 100f, -5))
			{
				return;
			}
			if ((bool)hitInfo.collider.gameObject.transform.parent && hitInfo.collider.gameObject.transform.parent.CompareTag("Enemy"))
			{
				if (PlayerPrefs.GetInt("MultyPlayer") != 1)
				{
					BotHealth component = hitInfo.collider.gameObject.transform.parent.GetComponent<BotHealth>();
					component.adjustHealth((float)(-_weaponManager.currentWeaponSounds.damage) + UnityEngine.Random.Range(_weaponManager.currentWeaponSounds.damageRange.x, _weaponManager.currentWeaponSounds.damageRange.y), Camera.main.transform);
				}
				else if (PlayerPrefs.GetInt("COOP", 0) == 1)
				{
					float health = hitInfo.collider.gameObject.transform.parent.GetComponent<ZombiUpravlenie>().health;
					if (health > 0f)
					{
						health -= (float)_weaponManager.currentWeaponSounds.damage + UnityEngine.Random.Range(_weaponManager.currentWeaponSounds.damageRange.x, _weaponManager.currentWeaponSounds.damageRange.y);
						hitInfo.collider.gameObject.transform.parent.GetComponent<ZombiUpravlenie>().setHealth(health, true);
						GlobalGameController.Score += 5;
						if (health <= 0f)
						{
							GlobalGameController.Score += hitInfo.collider.gameObject.GetComponent<Sounds>().scorePerKill;
						}
						_weaponManager.myTable.GetComponent<NetworkStartTable>().score = GlobalGameController.Score;
						_weaponManager.myTable.GetComponent<NetworkStartTable>().synchState();
					}
				}
			}
			if (PlayerPrefs.GetInt("MultyPlayer") == 1)
			{
				gameObject.GetComponent<Bullet>().lifeS = hitInfo.distance;
				gameObject.GetComponent<Bullet>().endPos = hitInfo.point;
			}
			if (hitInfo.collider.gameObject.CompareTag("Player") && PlayerPrefs.GetInt("MultyPlayer") == 1 && PlayerPrefs.GetInt("COOP", 0) != 1)
			{
				if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
				{
					base.GetComponent<NetworkView>().RPC("minusLive", RPCMode.All, hitInfo.collider.gameObject.GetComponent<NetworkView>().viewID, base.transform.parent.gameObject.GetComponent<NetworkView>().viewID, _weaponManager.currentWeaponSounds.multiplayerDamage);
				}
				else
				{
					photonView.RPC("minusLivePhoton", PhotonTargets.All, hitInfo.collider.gameObject.GetComponent<PhotonView>().viewID, base.transform.parent.gameObject.GetComponent<PhotonView>().viewID, _weaponManager.currentWeaponSounds.multiplayerDamage);
				}
			}
			return;
		}
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
			{
				base.GetComponent<NetworkView>().RPC("fireFlash", RPCMode.Others, base.gameObject.transform.GetComponent<NetworkView>().viewID, false);
			}
			else
			{
				photonView.RPC("fireFlashPhoton", PhotonTargets.Others, base.gameObject.transform.GetComponent<PhotonView>().viewID, false);
			}
		}
		GameObject[] array = ((PlayerPrefs.GetInt("MultyPlayer") != 1 || PlayerPrefs.GetInt("COOP", 0) == 1) ? GameObject.FindGameObjectsWithTag("Enemy") : GameObject.FindGameObjectsWithTag("Player"));
		GameObject gameObject2 = null;
		float num = float.PositiveInfinity;
		GameObject[] array2 = array;
		foreach (GameObject gameObject3 in array2)
		{
			if (!gameObject3.transform.position.Equals(_player.transform.position))
			{
				Vector3 to = gameObject3.transform.position - _player.transform.position;
				float magnitude = to.magnitude;
				if (magnitude < num && ((magnitude < _weaponManager.currentWeaponSounds.range && Vector3.Angle(_player.transform.forward, to) < _weaponManager.currentWeaponSounds.meleeAngle) || magnitude < 1.5f))
				{
					num = magnitude;
					gameObject2 = gameObject3;
				}
			}
		}
		if ((bool)gameObject2)
		{
			StartCoroutine(HitByMelee(gameObject2));
		}
	}

	private IEnumerator HitByMelee(GameObject enemyToHit)
	{
		yield return new WaitForSeconds(_weaponManager.currentWeaponSounds.animationObject.GetComponent<Animation>()[myCAnim("Shoot")].length * _weaponManager.currentWeaponSounds.meleeAttackTimeModifier);
		if (PlayerPrefs.GetInt("MultyPlayer") == 1 && PlayerPrefs.GetInt("COOP", 0) != 1)
		{
			foreach (Transform tr in enemyToHit.transform)
			{
				if (tr.gameObject.tag.Equals("PlayerGun") && PlayerPrefs.GetInt("MultyPlayer") == 1)
				{
					if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
					{
						base.GetComponent<NetworkView>().RPC("minusLive", RPCMode.All, tr.gameObject.transform.parent.gameObject.GetComponent<NetworkView>().viewID, base.transform.parent.gameObject.GetComponent<NetworkView>().viewID, _weaponManager.currentWeaponSounds.multiplayerDamage);
					}
					else
					{
						photonView.RPC("minusLivePhoton", PhotonTargets.All, tr.gameObject.transform.parent.gameObject.GetComponent<PhotonView>().viewID, base.transform.parent.gameObject.GetComponent<PhotonView>().viewID, _weaponManager.currentWeaponSounds.multiplayerDamage);
					}
				}
			}
			yield break;
		}
		if (PlayerPrefs.GetInt("MultyPlayer") == 1 && PlayerPrefs.GetInt("COOP", 0) == 1)
		{
			float liveEnemy2 = enemyToHit.GetComponent<ZombiUpravlenie>().health;
			if (liveEnemy2 > 0f)
			{
				liveEnemy2 -= (float)_weaponManager.currentWeaponSounds.damage + UnityEngine.Random.Range(_weaponManager.currentWeaponSounds.damageRange.x, _weaponManager.currentWeaponSounds.damageRange.y);
				Debug.Log("liveEnemy=" + liveEnemy2);
				enemyToHit.GetComponent<ZombiUpravlenie>().setHealth(liveEnemy2, true);
				GlobalGameController.Score += 5;
				if (liveEnemy2 <= 0f)
				{
					GlobalGameController.Score += enemyToHit.transform.GetChild(0).gameObject.GetComponent<Sounds>().scorePerKill;
				}
				_weaponManager.myTable.GetComponent<NetworkStartTable>().score = GlobalGameController.Score;
				_weaponManager.myTable.GetComponent<NetworkStartTable>().synchState();
			}
		}
		else if ((bool)enemyToHit && (bool)enemyToHit.GetComponent<BotHealth>() && enemyToHit.GetComponent<BotHealth>().getIsLife())
		{
			enemyToHit.GetComponent<BotHealth>().adjustHealth((float)(-_weaponManager.currentWeaponSounds.damage) + UnityEngine.Random.Range(_weaponManager.currentWeaponSounds.damageRange.x, _weaponManager.currentWeaponSounds.damageRange.y), Camera.main.transform);
		}
	}

	private IEnumerator Fade(float start, float end, float length, GameObject currentObject)
	{
		for (float i = 0f; i < 1f; i += Time.deltaTime / length)
		{
			Color rgba = currentObject.GetComponent<GUITexture>().color;
			rgba.a = Mathf.Lerp(start, end, i);
			currentObject.GetComponent<GUITexture>().color = rgba;
			yield return 0;
			Color rgba_ = currentObject.GetComponent<GUITexture>().color;
			rgba_.a = end;
			currentObject.GetComponent<GUITexture>().color = rgba_;
		}
	}

	private IEnumerator FlashWhenHit()
	{
		damageShown = true;
		Color rgba = damage.GetComponent<GUITexture>().color;
		rgba.a = 0f;
		damage.GetComponent<GUITexture>().color = rgba;
		float danageTime = 0.15f;
		yield return StartCoroutine(Fade(0f, 1f, danageTime, damage));
		yield return new WaitForSeconds(0.01f);
		yield return StartCoroutine(Fade(1f, 0f, danageTime, damage));
		damageShown = false;
	}

	private IEnumerator SetCanReceiveSwipes()
	{
		yield return new WaitForSeconds(0.1f);
		canReceiveSwipes = true;
	}

	private void Update()
	{
		if (!Application.isMobilePlatform)
		{
			if (Input.GetKeyDown("r"))
			{
				ReloadPressed();
			}
			if (Input.GetMouseButton(0))
			{
				ShotPressed();
			}
			        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _weaponManager.CurrentWeaponIndex++;
						int count = _weaponManager.playerWeapons.Count;
						count = ((count == 0) ? 1 : count);
						_weaponManager.CurrentWeaponIndex %= count;
						ChangeWeapon(_weaponManager.CurrentWeaponIndex, false);
        }
                if (Input.GetKeyDown(KeyCode.Alpha1))
        {
						_weaponManager.CurrentWeaponIndex--;
						if (_weaponManager.CurrentWeaponIndex < 0)
						{
							_weaponManager.CurrentWeaponIndex = _weaponManager.playerWeapons.Count - 1;
						}
						_weaponManager.CurrentWeaponIndex %= _weaponManager.playerWeapons.Count;
						ChangeWeapon(_weaponManager.CurrentWeaponIndex, false);
        }
		}
		slideScroll();
		if (timerShow[0] > 0f)
		{
			timerShow[0] -= Time.deltaTime;
		}
		if (timerShow[1] > 0f)
		{
			timerShow[1] -= Time.deltaTime;
		}
		if (timerShow[2] > 0f)
		{
			timerShow[2] -= Time.deltaTime;
		}
		if (!_pauser.paused && canReceiveSwipes && !isInappWinOpen)
		{
			Rect rect = new Rect((float)Screen.width - 264f * (float)Screen.width / 1024f, (float)Screen.height - 94f * (float)Screen.width / 1024f - 95f * (float)Screen.width / 1024f, 264f * (float)Screen.width / 1024f, 95f * (float)Screen.width / 1024f);
			Touch[] touches = Input.touches;
			for (int i = 0; i < touches.Length; i++)
			{
				Touch touch = touches[i];
				if (!rect.Contains(touch.position))
				{
					continue;
				}
				if (touch.phase == TouchPhase.Began)
				{
					leftFingerPos = Vector2.zero;
					leftFingerLastPos = Vector2.zero;
					leftFingerMovedBy = Vector2.zero;
					slideMagnitudeX = 0f;
					slideMagnitudeY = 0f;
					leftFingerPos = touch.position;
				}
				else if (touch.phase == TouchPhase.Moved)
				{
					leftFingerMovedBy = touch.position - leftFingerPos;
					leftFingerLastPos = leftFingerPos;
					leftFingerPos = touch.position;
					slideMagnitudeX = leftFingerMovedBy.x / (float)Screen.width;
					Debug.Log("slideMagnitudeX = " + slideMagnitudeX);
					float num = 0.02f;
					if (slideMagnitudeX > num)
					{
						if ((((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1) || PlayerPrefs.GetInt("MultyPlayer") != 1)
						{
							_weaponManager.CurrentWeaponIndex++;
							int count = _weaponManager.playerWeapons.Count;
							count = ((count == 0) ? 1 : count);
							_weaponManager.CurrentWeaponIndex %= count;
							Debug.Log("move _weaponManager.CurrentWeaponIndex" + _weaponManager.CurrentWeaponIndex);
							ChangeWeapon(_weaponManager.CurrentWeaponIndex, false);
						}
						canReceiveSwipes = false;
						StartCoroutine(SetCanReceiveSwipes());
						leftFingerLastPos = leftFingerPos;
						leftFingerPos = touch.position;
						slideMagnitudeX = 0f;
					}
					else if (slideMagnitudeX < 0f - num)
					{
						if ((((PlayerPrefs.GetString("TypeConnect").Equals("local") && base.GetComponent<NetworkView>().isMine) || (PlayerPrefs.GetString("TypeConnect").Equals("inet") && photonView.isMine)) && PlayerPrefs.GetInt("MultyPlayer") == 1) || PlayerPrefs.GetInt("MultyPlayer") != 1)
						{
							_weaponManager.CurrentWeaponIndex--;
							if (_weaponManager.CurrentWeaponIndex < 0)
							{
								_weaponManager.CurrentWeaponIndex = _weaponManager.playerWeapons.Count - 1;
							}
							_weaponManager.CurrentWeaponIndex %= _weaponManager.playerWeapons.Count;
							Debug.Log("_weaponManager.CurrentWeaponIndex" + _weaponManager.CurrentWeaponIndex);
							ChangeWeapon(_weaponManager.CurrentWeaponIndex, false);
						}
						canReceiveSwipes = false;
						StartCoroutine(SetCanReceiveSwipes());
						leftFingerLastPos = leftFingerPos;
						leftFingerPos = touch.position;
						slideMagnitudeX = 0f;
					}
					slideMagnitudeY = leftFingerMovedBy.y / (float)Screen.height;
				}
				else if (touch.phase == TouchPhase.Stationary)
				{
					leftFingerLastPos = leftFingerPos;
					leftFingerPos = touch.position;
					slideMagnitudeX = 0f;
					slideMagnitudeY = 0f;
				}
				else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
				{
					slideMagnitudeX = 0f;
					slideMagnitudeY = 0f;
				}
			}
		}
		if (GunFlashLifetime > 0f)
		{
			GunFlashLifetime -= Time.deltaTime;
		}
		if (GunFlashLifetime <= 0f)
		{
			_SetGunFlashActive(false);
		}
		if (!(CurHealth <= 0f) || isKilled)
		{
			return;
		}
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			Debug.Log("killedddddddd");
			if (PlayerPrefs.GetInt("COOP", 0) == 1)
			{
				Debug.Log("MIIINUUUS SCORE!!!");
				_weaponManager.myTable.GetComponent<NetworkStartTable>().score -= 1500f;
				if (_weaponManager.myTable.GetComponent<NetworkStartTable>().score < 0f)
				{
					_weaponManager.myTable.GetComponent<NetworkStartTable>().score = 0f;
				}
				GlobalGameController.Score = Mathf.RoundToInt(_weaponManager.myTable.GetComponent<NetworkStartTable>().score);
				_weaponManager.myTable.GetComponent<NetworkStartTable>().synchState();
			}
			isKilled = true;
			_leftJoystick.SetActive(false);
			_rightJoystick.SetActive(false);
			HOTween.From(base.transform.parent.transform, 2f, new TweenParms().Prop("localRotation", new Vector3(0f, 2520f, 0f)).Ease(EaseType.EaseInCubic).OnComplete(_003CUpdate_003Em__13));
		}
		else
		{
			if (GlobalGameController.Score > PlayerPrefs.GetInt(Defs.BestScoreSett, 0))
			{
				PlayerPrefs.SetInt(Defs.BestScoreSett, GlobalGameController.Score);
				PlayerPrefs.Save();
			}
			GameCenterSingleton.Instance.ReportScore(GlobalGameController.Score);
			Application.LoadLevel("GameOver");
		}
	}

	private void ChangePositionAfterRespawn()
	{
		if ((bool)base.transform.parent)
		{
			base.transform.parent.transform.position += Vector3.forward * 0.01f;
		}
	}

	public static Rect SuccessMessageRect()
	{
		return new Rect((float)(Screen.width / 2) - (float)Screen.height * 0.5f, (float)Screen.height * 0.5f - (float)Screen.height * 0.0525f, Screen.height, (float)Screen.height * 0.105f);
	}

	public void showUnlockGUI()
	{
	}

	private void OnGUI()
	{
		if (!showGUI || coinsShop.thisScript.enabled)
		{
			return;
		}
		GUI.enabled = !showGUIUnlockFullVersion;
		if (showRanks)
		{
			float num = (float)Screen.height / 768f;
			GUI.DrawTexture(new Rect(((float)Screen.width - 2048f * (float)Screen.height / 1154f) / 2f, 0f, 2048f * (float)Screen.height / 1154f, Screen.height), ranksFon, ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect((float)Screen.width / 2f - (float)head_players.width / 2f * num, (float)Screen.height * 0.1f - (float)head_players.height / 2f * (float)Screen.height / 768f, (float)head_players.width * num, (float)head_players.height * num), head_players);
			Texture texture = ((PlayerPrefs.GetInt("COOP", 0) != 1) ? killsStyle : scoreTextureCOOP);
			GUI.DrawTexture(new Rect((float)Screen.width / 2f + ((float)playersWindow.normal.background.width / 2f - (float)texture.width * 1.6f) * num, (float)Screen.height * 0.55f - ((float)playersWindow.normal.background.height + (float)nicksStyle.height * 1.8f) * 0.5f * num, (float)texture.width * num, (float)texture.height * num), texture);
			GUI.DrawTexture(new Rect((float)Screen.width / 2f - (float)playersWindow.normal.background.width / 2f * num, (float)Screen.height * 0.55f - ((float)playersWindow.normal.background.height + (float)nicksStyle.height * 1.8f) * 0.5f * num, (float)nicksStyle.width * num, (float)nicksStyle.height * num), nicksStyle);
			playersWindow.fontSize = Mathf.RoundToInt(30f * num);
			playersWindowFrags.fontSize = Mathf.RoundToInt(30f * num);
			GUILayout.Space((float)Screen.height * 0.55f - (float)playersWindow.normal.background.height * 0.5f * num);
			GUILayout.BeginHorizontal(GUILayout.Height((float)playersWindow.normal.background.height * num));
			GUILayout.Space((float)Screen.width * 0.5f - (float)playersWindow.normal.background.width * 0.525f * num);
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, playersWindow);
			GameObject[] array = GameObject.FindGameObjectsWithTag("NetworkTable");
			for (int i = 1; i < array.Length; i++)
			{
				GameObject gameObject = array[i];
				int num2 = i - 1;
				while (num2 >= 0 && ((PlayerPrefs.GetInt("COOP", 0) != 1) ? ((float)array[num2].GetComponent<NetworkStartTable>().CountKills) : array[num2].GetComponent<NetworkStartTable>().score) < ((PlayerPrefs.GetInt("COOP", 0) != 1) ? ((float)gameObject.GetComponent<NetworkStartTable>().CountKills) : gameObject.GetComponent<NetworkStartTable>().score))
				{
					array[num2 + 1] = array[num2];
					num2--;
				}
				array[num2 + 1] = gameObject;
			}
			if (array.Length > 0)
			{
				GameObject[] array2 = array;
				foreach (GameObject gameObject2 in array2)
				{
					GUILayout.Space(20f * num);
					GUILayout.BeginHorizontal();
					GUILayout.Space(20f * num);
					if (gameObject2.Equals(_weaponManager.myTable))
					{
						playersWindow.normal.textColor = new Color(1f, 1f, 0f, 1f);
						playersWindowFrags.normal.textColor = new Color(1f, 1f, 0f, 1f);
					}
					else
					{
						playersWindow.normal.textColor = new Color(0.7843f, 0.7843f, 0.7843f, 1f);
						playersWindowFrags.normal.textColor = new Color(0.7843f, 0.7843f, 0.7843f, 1f);
					}
					GUILayout.Label(gameObject2.GetComponent<NetworkStartTable>().NamePlayer, playersWindow, GUILayout.Width((float)playersWindow.normal.background.width * num * 0.85f));
					if (PlayerPrefs.GetInt("COOP", 0) == 1)
					{
						float score = gameObject2.GetComponent<NetworkStartTable>().score;
						GUILayout.Label((score != -1f) ? score.ToString() : "---", playersWindowFrags, GUILayout.Width((float)playersWindow.normal.background.width * num * 0.1f));
					}
					else
					{
						int num3 = gameObject2.GetComponent<NetworkStartTable>().CountKills;
						GUILayout.Label((num3 != -1) ? num3.ToString() : "---", playersWindowFrags, GUILayout.Width((float)playersWindow.normal.background.width * num * 0.1f));
					}
					GUILayout.Space(20f * num);
					GUILayout.EndHorizontal();
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndHorizontal();
			if (!GUI.Button(new Rect((float)Screen.width * 0.5f - (float)closeRanksStyle.normal.background.width * num * 0.5f, (float)Screen.height * 0.86f, (float)closeRanksStyle.normal.background.width * num, (float)closeRanksStyle.normal.background.height * num), string.Empty, closeRanksStyle))
			{
				return;
			}
			showRanks = false;
		}
		GUI.depth = 2;
		GUI.skin = MySkin;
		GUI.DrawTexture(new Rect((float)(Screen.width / 2) - (float)Screen.height * 0.023f, (float)(Screen.height / 2) - (float)Screen.height * 0.023f, (float)Screen.height * 0.046f, (float)Screen.height * 0.046f), AimTexture);
		Rect rect = new Rect((float)Screen.width - (float)Screen.width * 0.208f, 0f, (float)Screen.width * 0.208f, (float)Screen.height * 0.078f);
		float num4 = (float)(buyStyle.normal.background.width * Screen.width) / 1024f;
		float num5 = num4 * ((float)buyStyle.normal.background.height / (float)buyStyle.normal.background.width);
		Rect position = new Rect((float)Screen.width - num4, 0f, num4, num5);
		Rect position2 = new Rect(position.x - num5 * (float)ranksStyle.normal.background.width / (float)ranksStyle.normal.background.height, 0f, num5 * (float)ranksStyle.normal.background.width / (float)ranksStyle.normal.background.height, num5);
		Rect position3 = new Rect(0f, 0f, 73f * (float)Screen.width / 1024f, 73f * (float)Screen.width / 1024f);
		AmmoBox.fontSize = Mathf.RoundToInt(18f * (float)Screen.width / 1024f);
		Rect position4 = new Rect((float)Screen.width - 264f * (float)Screen.width / 1024f, 94f * (float)Screen.width / 1024f, 264f * (float)Screen.width / 1024f, 95f * (float)Screen.width / 1024f);
		Rect position5 = new Rect((float)Screen.width - 172f * (float)Screen.width / 1024f, 186f * (float)Screen.width / 1024f, (float)(40 * Screen.width) / 1024f, (float)(28 * Screen.width) / 1024f);
		Rect position6 = new Rect((float)Screen.width - 135f * (float)Screen.width / 1024f, 186f * (float)Screen.width / 1024f, 130f * (float)Screen.width / 1024f, (float)(28 * Screen.width) / 1024f);
		if (_weaponManager.CurrentWeaponIndex >= 0 && _weaponManager.CurrentWeaponIndex < _weaponManager.playerWeapons.Count && !_weaponManager.currentWeaponSounds.isMelee)
		{
			GUI.DrawTexture(position5, ammoTexture);
			GUI.Box(position6, ((Weapon)_weaponManager.playerWeapons[_weaponManager.CurrentWeaponIndex]).currentAmmoInClip + "/" + ((Weapon)_weaponManager.playerWeapons[_weaponManager.CurrentWeaponIndex]).currentAmmoInBackpack, AmmoBox);
		}
		if (PlayerPrefs.GetInt("MultyPlayer") != 1 && Defs.NumberOfElixirs > 0)
		{
			float num6 = 1.5f;
			float num7 = position4.height * (float)(elixir.width / elixir.height) / num6;
			float num8 = position4.height / num6;
			Rect rect2 = new Rect((float)Screen.width - position6.x - position6.width, position6.y, position6.width, position6.height);
			Rect position7 = new Rect(rect2.x + rect2.width / 2f - num7 / 2f, position4.y, num7, num8);
			GUI.DrawTexture(position7, elixir);
		}
		ScoreBox.fontSize = Mathf.RoundToInt((float)Screen.height * 0.035f);
		float num9 = (float)(enemiesTxture.width * Screen.width) / 1024f;
		float num10 = num9 * ((float)enemiesTxture.height / (float)enemiesTxture.width);
		float num11 = 13f;
		EnemiesBox.fontSize = Mathf.RoundToInt((float)Screen.height * 0.035f);
		if (PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			GUI.DrawTexture(new Rect(position.x - num9, 0f, num9, num10), enemiesTxture);
			GUI.Box(new Rect(position.x - num9, num11 * (float)Screen.width / 1024f, num9, num10), string.Empty + (GlobalGameController.EnemiesToKill - _zombieCreator.NumOfDeadZombies), EnemiesBox);
			GUI.DrawTexture(new Rect(position.x - num9 - num9, 0f, num9, num10), scoreTexture);
			GUI.Box(new Rect(position.x - num9 - num9, num11 * (float)Screen.width / 1024f, num9, num10), string.Empty + GlobalGameController.Score, ScoreBox);
		}
		else if (PlayerPrefs.GetInt("COOP", 0) != 1)
		{
			GUI.Box(new Rect(position.x - num9 - num9, 6f * (float)Screen.width / 1024f, num9, num10), "Kills \n" + countKills + "/" + maxCountKills, ScoreBox);
			killedStyle.fontSize = Mathf.RoundToInt((float)Screen.height * 0.04f);
			if (timerShow[0] > 0f)
			{
				GUI.Label(new Rect((float)Screen.height * 0.04f, (float)Screen.height * 0.14f, (float)Screen.width * 0.5f, (float)Screen.height * 0.1f), killedSpisok[0], killedStyle);
			}
			if (timerShow[1] > 0f)
			{
				GUI.Label(new Rect((float)Screen.height * 0.04f, (float)Screen.height * 0.24f, (float)Screen.width * 0.5f, (float)Screen.height * 0.1f), killedSpisok[1], killedStyle);
			}
			if (timerShow[2] > 0f)
			{
				GUI.Label(new Rect((float)Screen.height * 0.04f, (float)Screen.height * 0.34f, (float)Screen.width * 0.5f, (float)Screen.height * 0.1f), killedSpisok[2], killedStyle);
			}
		}
		else
		{
			ScoreBox.fontSize = Mathf.RoundToInt((float)Screen.height * 0.025f);
			float num12 = zombiManager.maxTimeGame - zombiManager.timeGame;
			if (num12 < 0f)
			{
				num12 = 0f;
			}
			GUI.Label(new Rect(position.x - num9 - num9, 0f, num9, num10), "Score\n" + GlobalGameController.Score, ScoreBox);
			GUI.Label(new Rect(position2.x - position2.width, 0f, position2.width, num10), "Time\n" + Mathf.FloorToInt(num12 / 60f) + ":" + ((Mathf.FloorToInt(num12 - (float)(Mathf.FloorToInt(num12 / 60f) * 60)) >= 10) ? string.Empty : "0") + Mathf.FloorToInt(num12 - (float)(Mathf.FloorToInt(num12 / 60f) * 60)), ScoreBox);
		}
		bool flag = true;
		float left = (float)Screen.width * 0.271f;
		float width = (float)Screen.width * 0.521f;
		float num13 = position3.x + position3.width * 1.5f;
		for (int k = 0; (float)k < CurHealth; k++)
		{
			GUI.DrawTexture(new Rect(num13 + (float)k * (49.5f * (float)Screen.width / 1024f), 12f * (float)Screen.width / 1024f, 31f * (float)Screen.width / 1024f, 30f * (float)Screen.width / 1024f), HeartTexture);
		}
		for (int l = 0; (float)l < curArmor; l++)
		{
			GUI.DrawTexture(new Rect(num13 + (float)l * (49.5f * (float)Screen.width / 1024f), 12f * (float)Screen.width / 1024f * 1.5f + 30f * (float)Screen.width / 1024f, 31f * (float)Screen.width / 1024f, 30f * (float)Screen.width / 1024f), armorShield);
		}
		GUI.DrawTexture(position4, _weaponManager.currentWeaponSounds.preview);
		if ((bool)_weaponManager && _weaponManager.playerWeapons != null && _weaponManager.playerWeapons.Count > 1)
		{
			GUI.Box(new Rect((float)Screen.width - 186f * (float)Screen.width / 1024f, 94f * (float)Screen.width / 1024f, 186f * (float)Screen.width / 1024f, 23f * (float)Screen.width / 1024f), "< SWIPE >", ScoreBox);
		}
		bool flag2 = false;
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				_backWasPressed = true;
				Debug.Log("407 androidBackPressed " + flag2);
			}
			else
			{
				if (_backWasPressed)
				{
					flag2 = true;
				}
				_backWasPressed = false;
			}
		}
		if ((GUI.Button(position3, string.Empty, pauseStyle) || (flag2 && !_pauser.paused)) && !_pauser.paused)
		{
			flag2 = false;
			if (CurHealth > 0f)
			{
				SetPause();
			}
		}
		if (PlayerPrefs.GetInt("MultyPlayer") != 1)
		{
			if (GlobalGameController.EnemiesToKill - _zombieCreator.NumOfDeadZombies == 0)
			{
				enemiesLeftStyle.fontSize = Mathf.RoundToInt((float)Screen.height * 0.035f);
				string text = "Enter the Portal...";
				if (_zombieCreator.bossShowm)
				{
					text = "Defeat the Boss!";
				}
				GUI.Box(new Rect(left, height + (float)(enemiesLeftStyle.fontSize * 2), width, height), text, enemiesLeftStyle);
			}
		}
		else if (GUI.Button(position2, string.Empty, ranksStyle))
		{
			showRanks = true;
		}
		GUI.DrawTexture(position, buyStyle.active.background);
		GUI.enabled = !isInappWinOpen;
		if (GUI.Button(position, string.Empty, buyStyle) && !_pauser.paused)
		{
			if (CurHealth > 0f)
			{
				SetInApp();
				SetPause();
			}
			GUI.enabled = true;
		}
		if (isInappWinOpen)
		{
			Rect position8 = new Rect(((float)Screen.width - 2048f * (float)Screen.height / 1154f) / 2f, 0f, 2048f * (float)Screen.height / 1154f, Screen.height);
			Rect position9 = new Rect((float)Screen.width * 0.5f - (float)shopHead.width * Defs.Coef * 0.5f, (float)Screen.height * 0.12f, (float)shopHead.width * Defs.Coef, (float)shopHead.height * Defs.Coef);
			if (currentCategory == -1)
			{
				coinsPlashka.thisScript.enabled = false;
				bool flag3 = GUI.enabled;
				GUI.enabled = true;
				GUI.DrawTexture(position8, shopFon, ScaleMode.StretchToFill);
				GUI.DrawTexture(position9, shopHead);
				for (int m = 0; m < catStyles.Length; m++)
				{
					float num14 = (float)Screen.width / 4f;
					float num15 = num14 * ((float)catStyles[0].normal.background.height / (float)catStyles[0].normal.background.width);
					float num16 = ((float)Screen.width - num14 * (float)catStyles.Length) / (float)(catStyles.Length + 1);
					Rect position10 = new Rect(num16 * (float)(m + 1) + num14 * (float)m, (float)Screen.height * 0.56f - num15 / 2f, num14, num15);
					if (GUI.Button(position10, string.Empty, catStyles[m]))
					{
						currentCategory = m;
						break;
					}
				}
				_shopResume(false);
				GUI.enabled = flag3;
			}
			else
			{
				GUI.DrawTexture(position8, shopFon, ScaleMode.StretchToFill);
				GUI.DrawTexture(position9, categoryHeads[currentCategory]);
				showCategory();
			}
			GUI.enabled = true;
		}
		else
		{
			coinsPlashka.thisScript.enabled = false;
		}
		if (Time.realtimeSinceStartup - _timeWhenPurchShown >= 1.5f)
		{
			productPurchased = false;
		}
		if (productPurchased)
		{
			labelStyle.fontSize = FontSizeForMessages;
			GUI.Label(SuccessMessageRect(), "Purchase was successful", labelStyle);
		}
		if ((bool)_pauser && _pauser.paused && !isInappWinOpen)
		{
			Rect position11 = new Rect(((float)Screen.width - 2048f * (float)Screen.height / 1154f) / 2f, 0f, 2048f * (float)Screen.height / 1154f, Screen.height);
			GUI.DrawTexture(position11, pauseFon, ScaleMode.StretchToFill);
			float num17 = 15f;
			Vector2 vector = new Vector2(176f, 150f - num17);
			float num18 = (float)Screen.height * 0.4781f;
			Rect position12 = new Rect((float)Screen.width * 0.5f - num18 * 0.5f, (float)Screen.height * 0.05f, num18, (float)Screen.height * 0.1343f);
			GUI.DrawTexture(position12, pauseTitle);
			float num19 = (float)resumePauseStyle.normal.background.width * Defs.Coef;
			float num20 = num19 * ((float)resumePauseStyle.normal.background.height / (float)resumePauseStyle.normal.background.width);
			float num21 = num20 * 0.33f;
			if (GUI.Button(new Rect(position12.x + position12.width / 2f - num19 / 2f, position12.y + position12.height + num21 * 1.5f, num19, num20), string.Empty, resumePauseStyle) || flag2)
			{
				SetPause();
			}
			Rect position13 = new Rect(position12.x + position12.width / 2f - num19 / 2f, position12.y + position12.height + num20 + num21 * 2.5f, num19, num20);
			if (GUI.Button(new Rect(position13.x + position13.width / 2f - (float)menuStyle.active.background.width / 2f * (float)Screen.height / 768f, position13.y + position13.height + num21, (float)(menuStyle.active.background.width * Screen.height) / 768f, (float)(menuStyle.active.background.height * Screen.height) / 768f), string.Empty, menuStyle))
			{
				Time.timeScale = 1f;
				Time.timeScale = 1f;
				if (PlayerPrefs.GetInt("MultyPlayer") == 1)
				{
					GameObject[] array3 = GameObject.FindGameObjectsWithTag("NetworkTable");
					GameObject[] array4 = array3;
					foreach (GameObject gameObject3 in array4)
					{
						gameObject3.GetComponent<NetworkStartTable>().sendDelMyPlayer();
					}
					if (PlayerPrefs.GetString("TypeConnect").Equals("local"))
					{
						if (PlayerPrefs.GetString("TypeGame").Equals("server"))
						{
							Network.Disconnect(200);
							GameObject.FindGameObjectWithTag("NetworkTable").GetComponent<LANBroadcastService>().StopBroadCasting();
						}
						else if (Network.connections.Length == 1)
						{
							Debug.Log("Disconnecting: " + Network.connections[0].ipAddress + ":" + Network.connections[0].port);
							Network.CloseConnection(Network.connections[0], true);
						}
						_purchaseActivityIndicator.SetActive(false);
						coinsShop.hideCoinsShop();
						coinsPlashka.hidePlashka();
						ConnectGUI.Local();
					}
					else
					{
						coinsShop.hideCoinsShop();
						coinsPlashka.hidePlashka();
						PhotonNetwork.LeaveRoom();
					}
				}
				else
				{
					Application.LoadLevel("Restart");
				}
			}
			if (GUI.Button(position13, string.Empty, shopFromPauseStyle) && CurHealth > 0f)
			{
				SetInApp();
				inAppOpenedFromPause = true;
			}
			float num22 = 15f;
			bool @bool = PlayerPrefsX.GetBool(PlayerPrefsX.SndSetting, true);
			Rect position14 = new Rect((float)Screen.width * 0.05f, (float)Screen.height * 0.923f - (float)Screen.height * 0.0525f, (float)Screen.height * 0.105f, (float)Screen.height * 0.105f);
			@bool = GUI.Toggle(position14, @bool, string.Empty, soundStyle);
			AudioListener.volume = (@bool ? 1 : 0);
			PlayerPrefsX.SetBool(PlayerPrefsX.SndSetting, @bool);
			PlayerPrefs.Save();
			Rect position15 = new Rect((float)(Screen.width / 2) - (float)sensitPausePlashka.width * 0.5f * Defs.Coef, position14.y + position14.height - (float)sensitPausePlashka.height * Defs.Coef, (float)sensitPausePlashka.width * Defs.Coef, (float)sensitPausePlashka.height * Defs.Coef);
			GUI.DrawTexture(position15, sensitPausePlashka);
			float coef = Defs.Coef;
			sliderSensStyle.fixedWidth = (float)slow_fast.width * coef;
			sliderSensStyle.fixedHeight = (float)slow_fast.height * coef;
			thumbSensStyle.fixedWidth = (float)polzunok.width * coef;
			thumbSensStyle.fixedHeight = (float)polzunok.height * coef;
			float num23 = (float)slow_fast.height * coef;
			Rect position16 = new Rect((float)Screen.width * 0.5f - (float)slow_fast.width * 0.5f * coef, position15.y + position15.height * 0.69f - num23 * 0.5f, (float)slow_fast.width * coef, num23);
			mySens = GUI.HorizontalSlider(position16, PlayerPrefs.GetFloat("SensitivitySett", 12f), 6f, 18f, sliderSensStyle, thumbSensStyle);
			PlayerPrefs.SetFloat("SensitivitySett", mySens);
		}
		GUI.enabled = true;
		if (!showGUIUnlockFullVersion)
		{
			return;
		}
		_purchaseActivityIndicator.SetActive(StoreKitEventListener.purchaseInProcess);
		if (_productsFull.Count > 0)
		{
			GUI.DrawTexture(new Rect(((float)Screen.width - 2048f * (float)Screen.height / 1154f) / 2f, 0f, 2048f * (float)Screen.height / 1154f, Screen.height), fonFull, ScaleMode.StretchToFill);
			if (GUI.Button(new Rect((float)Screen.width * 0.5f - (float)Screen.height / 768f * (float)noStyle.normal.background.width * 1.2f, (float)Screen.height * 0.58f, (float)(noStyle.normal.background.width * Screen.height) / 768f, (float)(noStyle.normal.background.height * Screen.height) / 768f), string.Empty, noStyle))
			{
				GlobalGameController.currentLevel = -1;
				AutoFade.LoadLevel("Loading", 0.5f, 0.5f, Color.white);
			}
			if (GUI.Button(new Rect((float)Screen.width * 0.5f + (float)Screen.height / 768f * (float)unlockStyle.normal.background.width * 0.2f, (float)Screen.height * 0.58f, (float)(unlockStyle.normal.background.width * Screen.height) / 768f, (float)(unlockStyle.normal.background.height * Screen.height) / 768f), string.Empty, unlockStyle))
			{
				StoreKitEventListener.purchaseInProcess = true;
				StoreKitProduct storeKitProduct = _productsFull[0];
				Debug.Log("preparing to purchase product: " + storeKitProduct.productIdentifier);
				StoreKitBinding.purchaseProduct(storeKitProduct.productIdentifier, 1);
			}
		}
		else
		{
			GUI.DrawTexture(new Rect(((float)Screen.width - 2048f * (float)Screen.height / 1154f) / 2f, 0f, 2048f * (float)Screen.height / 1154f, Screen.height), fonFullNoInet, ScaleMode.StretchToFill);
			if (showNoInetTimer > 0f)
			{
				showNoInetTimer -= Time.deltaTime;
				return;
			}
			GlobalGameController.currentLevel = -1;
			AutoFade.LoadLevel("Loading", 0.5f, 0.5f, Color.white);
		}
	}

	private void SetPause()
	{
		_pauser.paused = !_pauser.paused;
		if (_pauser.paused)
		{
			if (PlayerPrefs.GetInt("MultyPlayer") != 1)
			{
				Time.timeScale = 0f;
			}
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	private void SetInApp()
	{
		isInappWinOpen = !isInappWinOpen;
		if (isInappWinOpen)
		{
			if (StoreKitEventListener.restoreInProcess)
			{
				_purchaseActivityIndicator.SetActive(true);
			}
			if (PlayerPrefs.GetInt("MultyPlayer") != 1)
			{
				Time.timeScale = 0f;
			}
		}
		else
		{
			_purchaseActivityIndicator.SetActive(false);
			if (!_pauser.paused)
			{
				Time.timeScale = 1f;
			}
		}
	}

	private void ProvideAmmo()
	{
		_listener.ProvideContent();
		_weaponManager.SetMaxAmmoFrAllWeapons();
		_rightJoystick.SendMessage("HasAmmo");
	}

	private void ProvideHealth()
	{
		CurHealth = MaxHealth;
	}

	public static void SaveMinerWeaponInPrefabs()
	{
		Storager.setInt(Defs.MinerWeaponSett, 1);
		PlayerPrefs.Save();
	}

	public static void SaveSwordInPrefs()
	{
		Storager.setInt(Defs.SwordSett, 1);
		PlayerPrefs.Save();
	}

	public static void SaveCombatRifleInPrefs()
	{
		Storager.setInt(Defs.CombatRifleSett, 1);
		PlayerPrefs.Save();
	}

	public static void SaveGoldenEagleInPrefs()
	{
		Storager.setInt(Defs.GoldenEagleSett, 1);
		PlayerPrefs.Save();
	}

	public static void SaveMagicBowInPrefs()
	{
		Storager.setInt(Defs.MagicBowSett, 1);
		PlayerPrefs.Save();
	}

	public static void SaveChainsawInPrefs()
	{
		Storager.setInt(Defs.ChainsawS, 1);
		PlayerPrefs.Save();
	}

	public static void SaveFAMASPrefs()
	{
		Storager.setInt(Defs.FAMASS, 1);
		PlayerPrefs.Save();
	}

	public static void SaveGlockInPrefs()
	{
		Storager.setInt(Defs.GlockSett, 1);
		PlayerPrefs.Save();
	}

	public static void SaveScytheInPrefs()
	{
		Storager.setInt(Defs.ScytheSN, 1);
		PlayerPrefs.Save();
	}

	public static void SaveShovelPrefs()
	{
		Storager.setInt(Defs.ShovelSN, 1);
		PlayerPrefs.Save();
	}

	public static void SaveSPASInPrefs()
	{
		Storager.setInt(Defs.SPASSett, 1);
		PlayerPrefs.Save();
	}

	public static void SaveMGoldenAxeInPrefs()
	{
		Storager.setInt(Defs.GoldenAxeSett, 1);
		PlayerPrefs.Save();
	}

	private void provideminerweapon()
	{
		GameObject pickPrefab = _weaponManager.GetPickPrefab();
		SaveMinerWeaponInPrefabs();
		AddWeapon(pickPrefab);
	}

	private void providesword()
	{
		GameObject swordPrefab = _weaponManager.GetSwordPrefab();
		SaveSwordInPrefs();
		AddWeapon(swordPrefab);
	}

	private void providecombatrifle()
	{
		GameObject combatRiflePrefab = _weaponManager.GetCombatRiflePrefab();
		SaveCombatRifleInPrefs();
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			AddWeapon(combatRiflePrefab);
		}
	}

	private void providegoldeneagle()
	{
		GameObject goldenEaglePrefab = _weaponManager.GetGoldenEaglePrefab();
		SaveGoldenEagleInPrefs();
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			AddWeapon(goldenEaglePrefab);
		}
	}

	private void providemagicbow()
	{
		GameObject magicBowPrefab = _weaponManager.GetMagicBowPrefab();
		SaveMagicBowInPrefs();
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			AddWeapon(magicBowPrefab);
		}
	}

	private void provideChainsaw()
	{
		GameObject chainsawPrefab = _weaponManager.GetChainsawPrefab();
		SaveChainsawInPrefs();
		AddWeapon(chainsawPrefab);
	}

	private void provideFAMAS()
	{
		GameObject fAMASPrefab = _weaponManager.GetFAMASPrefab();
		SaveFAMASPrefs();
		if (PlayerPrefs.GetInt("MultyPlayer") == 1)
		{
			AddWeapon(fAMASPrefab);
		}
	}

	private void provideGlock()
	{
		GameObject glockPrefab = _weaponManager.GetGlockPrefab();
		SaveGlockInPrefs();
		AddWeapon(glockPrefab);
	}

	private void provideScythe()
	{
		GameObject scythePrefab = _weaponManager.GetScythePrefab();
		SaveScytheInPrefs();
		AddWeapon(scythePrefab);
	}

	private void provideShovel()
	{
		GameObject shovelPrefab = _weaponManager.GetShovelPrefab();
		SaveShovelPrefs();
		AddWeapon(shovelPrefab);
	}

	private void providespas()
	{
		GameObject sPASPrefab = _weaponManager.GetSPASPrefab();
		SaveSPASInPrefs();
		AddWeapon(sPASPrefab);
	}

	private void provideaxe()
	{
		GameObject axePrefab = _weaponManager.GetAxePrefab();
		SaveMGoldenAxeInPrefs();
		AddWeapon(axePrefab);
	}

	public void PurchaseSuccessful(string id)
	{
		Debug.Log("purchased product: " + id);
		if (!GlobalGameController.isFullVersion && id.Equals(_productsFull[0].productIdentifier))
		{
			PlayerPrefs.SetInt("FullVersion", 1);
			_purchaseActivityIndicator.SetActive(false);
			AutoFade.LoadLevel("Loading", 0.5f, 0.5f, Color.white);
		}
		if (_actionsForPurchasedItems.ContainsKey(id))
		{
			_actionsForPurchasedItems[id].Key();
		}
		productPurchased = true;
		_timeWhenPurchShown = Time.realtimeSinceStartup;
	}

	private void purchaseSuccessful(StoreKitTransaction transaction)
	{
		PurchaseSuccessful(transaction.productIdentifier);
	}

	private IEnumerator _ResetProductPurchased()
	{
		yield return new WaitForSeconds(1f);
		productPurchased = false;
	}

	private void showCategory()
	{
		bool flag = false;
		if ((PlayerPrefs.GetInt("MultyPlayer") != 1 && PlayerPrefs.GetInt(Defs.restoreWindowShownSingle, 0) == 0) || (PlayerPrefs.GetInt("MultyPlayer") == 1 && PlayerPrefs.GetInt(Defs.restoreWindowShownMult, 0) == 0 && PlayerPrefs.GetInt(Defs.inappsRestored_3_1, 0) != 1))
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
				_003CshowCategory_003Ec__AnonStorey1B _003CshowCategory_003Ec__AnonStorey1B = new _003CshowCategory_003Ec__AnonStorey1B();
				_003CshowCategory_003Ec__AnonStorey1B.restoreSucceeded = null;
				_003CshowCategory_003Ec__AnonStorey1B.restoreFailde = null;
				_003CshowCategory_003Ec__AnonStorey1B.restoreSucceeded = _003CshowCategory_003Ec__AnonStorey1B._003C_003Em__14;
				_003CshowCategory_003Ec__AnonStorey1B.restoreFailde = _003CshowCategory_003Ec__AnonStorey1B._003C_003Em__15;
				StoreKitManager.restoreTransactionsFinishedEvent += _003CshowCategory_003Ec__AnonStorey1B.restoreSucceeded;
				StoreKitManager.restoreTransactionsFailedEvent += _003CshowCategory_003Ec__AnonStorey1B.restoreFailde;
				StoreKitEventListener.purchaseInProcess = true;
				StoreKitEventListener.restoreInProcess = true;
				StoreKitBinding.restoreCompletedTransactions();
				if (PlayerPrefs.GetInt("MultyPlayer") != 1)
				{
					PlayerPrefs.SetInt(Defs.restoreWindowShownSingle, 1);
				}
				else
				{
					PlayerPrefs.SetInt(Defs.restoreWindowShownMult, 1);
				}
				return;
			}
			if (GUI.Button(new Rect((float)Screen.width / 2f - (float)cancelEindButStyle.normal.background.width * Defs.Coef - num, (float)Screen.height / 2f + (float)restoreWindowTexture.height * num2 * Defs.Coef, (float)cancelEindButStyle.normal.background.width * Defs.Coef, (float)cancelEindButStyle.normal.background.height * Defs.Coef), string.Empty, cancelEindButStyle))
			{
				if (PlayerPrefs.GetInt("MultyPlayer") != 1)
				{
					PlayerPrefs.SetInt(Defs.restoreWindowShownSingle, 1);
				}
				else
				{
					PlayerPrefs.SetInt(Defs.restoreWindowShownMult, 1);
				}
				return;
			}
			GUI.enabled = false;
		}
		GUI.depth = 0;
		GUI.enabled = !StoreKitEventListener.restoreInProcess && !flag;
		RestoreButton(flag);
		GUI.enabled = !StoreKitEventListener.restoreInProcess && !flag;
		_purchaseActivityIndicator.SetActive(StoreKitEventListener.restoreInProcess);
		string[] array = ((PlayerPrefs.GetInt("MultyPlayer") == 1) ? StoreKitEventListener.categoriesMulti[currentCategory] : StoreKitEventListener.categoriesSingle[currentCategory]);
		int num3 = array.Length;
		_003CshowCategory_003Ec__AnonStorey1D _003CshowCategory_003Ec__AnonStorey1D = new _003CshowCategory_003Ec__AnonStorey1D();
		_003CshowCategory_003Ec__AnonStorey1D._003C_003Ef__this = this;
		_003CshowCategory_003Ec__AnonStorey1D.i = 0;
		while (_003CshowCategory_003Ec__AnonStorey1D.i < num3 && !flag)
		{
			GUIStyle value = puliInApp;
			if (_actionsForPurchasedItems.ContainsKey(array[_003CshowCategory_003Ec__AnonStorey1D.i]))
			{
				value = _actionsForPurchasedItems[array[_003CshowCategory_003Ec__AnonStorey1D.i]].Value;
			}
			else
			{
				Debug.Log("InApps: key are not present: " + _products[_003CshowCategory_003Ec__AnonStorey1D.i].productIdentifier);
			}
			float num4 = 320f / (float)healthInApp.normal.background.height * 0.87f;
			float num5 = (float)(healthInApp.normal.background.width * Screen.height) / 768f * num4;
			float num6 = num5 * ((float)healthInApp.normal.background.height / (float)healthInApp.normal.background.width);
			Rect position2 = new Rect((float)(Screen.width / (num3 + 1) * (_003CshowCategory_003Ec__AnonStorey1D.i + 1)) - num5 * 0.5f, (float)Screen.height * 0.62f - 367f * (float)Screen.height / 768f * 0.5f - num6 * 0.15f, num5, num6);
			if (value == pulemetInApp && Storager.getInt(Defs.MinerWeaponSett) > 0)
			{
				GUI.DrawTexture(position2, minerWeaponSoldTexture, ScaleMode.StretchToFill);
			}
			else if (value == crystalSwordInapp && Storager.getInt(Defs.SwordSett) > 0)
			{
				GUI.DrawTexture(position2, swordSoldTexture, ScaleMode.StretchToFill);
			}
			else if (value == elixirInapp && Defs.NumberOfElixirs > 0)
			{
				GUI.DrawTexture(position2, hasElixirTexture, ScaleMode.StretchToFill);
			}
			else if (value == combatRifleStyle && Storager.getInt(Defs.CombatRifleSett) > 0)
			{
				GUI.DrawTexture(position2, combatRifleSoldTexture, ScaleMode.StretchToFill);
			}
			else if (value == goldenEagleInappStyle && Storager.getInt(Defs.GoldenEagleSett) > 0)
			{
				GUI.DrawTexture(position2, goldenEagleSoldTexture, ScaleMode.StretchToFill);
			}
			else if (value == magicBowInappStyle && Storager.getInt(Defs.MagicBowSett) > 0)
			{
				GUI.DrawTexture(position2, magicBowSoldTexture, ScaleMode.StretchToFill);
			}
			else if (value == axeStyle && Storager.getInt(Defs.GoldenAxeSett) > 0)
			{
				GUI.DrawTexture(position2, axeBoughtTexture, ScaleMode.StretchToFill);
			}
			else if (value == spasStyle && Storager.getInt(Defs.SPASSett) > 0)
			{
				GUI.DrawTexture(position2, spasBoughtTexture, ScaleMode.StretchToFill);
			}
			else if (value == chainsawStyle && Storager.getInt(Defs.ChainsawS) > 0)
			{
				GUI.DrawTexture(position2, chainsawOffTexture, ScaleMode.StretchToFill);
			}
			else if (value == famasStyle && Storager.getInt(Defs.FAMASS) > 0)
			{
				GUI.DrawTexture(position2, famasOffTexture, ScaleMode.StretchToFill);
			}
			else if (value == glockStyle && Storager.getInt(Defs.GlockSett) > 0)
			{
				GUI.DrawTexture(position2, GlockOffTexture, ScaleMode.StretchToFill);
			}
			else if (value == scytheStyle && Storager.getInt(Defs.ScytheSN) > 0)
			{
				GUI.DrawTexture(position2, scytheOffTexture, ScaleMode.StretchToFill);
			}
			else if (value == shovelStyle && Storager.getInt(Defs.ShovelSN) > 0)
			{
				GUI.DrawTexture(position2, shovelOffTexture, ScaleMode.StretchToFill);
			}
			else
			{
				GUI.enabled = !StoreKitEventListener.purchaseInProcess && !flag;
				if (GUI.Button(position2, string.Empty, value))
				{
					_003CshowCategory_003Ec__AnonStorey1C _003CshowCategory_003Ec__AnonStorey1C = new _003CshowCategory_003Ec__AnonStorey1C();
					_003CshowCategory_003Ec__AnonStorey1C._003C_003Ef__ref_002429 = _003CshowCategory_003Ec__AnonStorey1D;
					_003CshowCategory_003Ec__AnonStorey1C._003C_003Ef__this = this;
					_003CshowCategory_003Ec__AnonStorey1C.id = array[_003CshowCategory_003Ec__AnonStorey1D.i];
					_003CshowCategory_003Ec__AnonStorey1C.act = null;
					_003CshowCategory_003Ec__AnonStorey1C.act = _003CshowCategory_003Ec__AnonStorey1C._003C_003Em__16;
					_003CshowCategory_003Ec__AnonStorey1C.act();
				}
			}
			_003CshowCategory_003Ec__AnonStorey1D.i++;
		}
		_shopResume(flag);
		coinsPlashka.thisScript.enabled = true && !flag;
	}

	private void _shopResume(bool disableGUI)
	{
		GUI.enabled = true && !disableGUI;
		float num = (float)Screen.height * 0.22f * 1.5f;
		if (!GUI.Button(new Rect((float)Screen.width * 0.5f - num / 2f, (float)Screen.height * 0.86f, num, (float)Screen.height * 0.078f * 1.5f), string.Empty, resumeStyle))
		{
			return;
		}
		if (currentCategory == -1)
		{
			SetInApp();
			if (inAppOpenedFromPause)
			{
				inAppOpenedFromPause = false;
			}
			else
			{
				SetPause();
			}
		}
		else
		{
			currentCategory = -1;
		}
	}

	private void slideScroll()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			scrollEnabled = true;
			scrollStartTouch = Input.GetTouch(0).position;
		}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && scrollEnabled)
		{
			Vector2 position = Input.GetTouch(0).position;
			scrollPosition.x += scrollStartTouch.x - position.x;
			scrollStartTouch = position;
		}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && scrollEnabled)
		{
			scrollEnabled = false;
		}
	}

	[CompilerGenerated]
	private static void _003CStart_003Em__11()
	{
		Defs.NumberOfElixirs++;
	}

	[CompilerGenerated]
	private void _003CStart_003Em__12()
	{
		curArmor = MaxArmor;
	}

	[CompilerGenerated]
	private void _003CUpdate_003Em__13()
	{
		base.transform.parent.transform.localScale = new Vector3(1f, 1f, 1f);
		isKilled = false;
		_leftJoystick.SetActive(true);
		_rightJoystick.SetActive(true);
		CurHealth = MaxHealth;
		curArmor = 0f;
		GameObject gameObject = zoneCreatePlayer[UnityEngine.Random.Range(0, zoneCreatePlayer.Length)];
		BoxCollider component = gameObject.GetComponent<BoxCollider>();
		Vector2 vector = new Vector2(component.size.x * gameObject.transform.localScale.x, component.size.z * gameObject.transform.localScale.z);
		Rect rect = new Rect(gameObject.transform.position.x - vector.x / 2f, gameObject.transform.position.z - vector.y / 2f, vector.x, vector.y);
		Vector3 vector2 = new Vector3(rect.x + UnityEngine.Random.Range(0f, rect.width), gameObject.transform.position.y + 2f, rect.y + UnityEngine.Random.Range(0f, rect.height));
		Debug.Log(string.Concat("spawnZone.transform.position=", gameObject.transform.position, "zoneRect=", rect, " pos=", vector2));
		base.transform.parent.transform.position = vector2;
		Invoke("ChangePositionAfterRespawn", 0.01f);
		foreach (Weapon playerWeapon in _weaponManager.playerWeapons)
		{
			playerWeapon.currentAmmoInClip = playerWeapon.weaponPrefab.GetComponent<WeaponSounds>().ammoInClip;
			playerWeapon.currentAmmoInBackpack = playerWeapon.weaponPrefab.GetComponent<WeaponSounds>().InitialAmmo;
		}
	}
}
