using System;
using System.Collections;
using System.Collections.Generic;
using Prime31;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	private GameObject _inAppGameObject;

	private StoreKitEventListener _listener;

	public Texture inAppFon;

	public GUIStyle puliInApp;

	public GUIStyle healthInApp;

	public GUIStyle pulemetInApp;

	public GUIStyle crystalSwordInapp;

	public GUIStyle elixirInapp;

	public bool isFirstFrame = true;

	public bool isInappWinOpen;

	private bool productPurchased;

	private Dictionary<string, KeyValuePair<Action, GUIStyle>> _actionsForPurchasedItems = new Dictionary<string, KeyValuePair<Action, GUIStyle>>();

	private List<StoreKitProduct> _products = new List<StoreKitProduct>();

	private bool showUnlockDialog;

	private bool isPressFullOnMulty;

	private string[] productIdentifiers = StoreKitEventListener.idsForFull;

	private float _timeWhenPurchShown;

	public Texture fon;

	public Texture plashkaPodScore;

	public Texture playMultyStyleNO;

	public Texture fonFull;

	public GameObject skinsManagerPrefab;

	public GameObject weaponManagerPrefab;

	public GUIStyle playStyle;

	public GUIStyle playMultyStyle;

	public GUIStyle unlockStyle;

	public GUIStyle noStyle;

	public GUIStyle fullVerStyle;

	public GUIStyle soundStyle;

	public GUIStyle bestScoreStyle;

	public GUIStyle facebookStyle;

	public GUIStyle twitterStyle;

	public GUIStyle gamecenterStyle;

	public GUIStyle labelStyle;

	public GUIStyle skinsMakerStyle;

	public GUIStyle backBut;

	public GUIStyle coopStyle;

	public bool iswinter;

	private bool showMessagFacebook;

	private bool showMessagTiwtter;

	private GameObject _purchaseActivityIndicator;

	private bool clickButtonFacebook;

	private string _userId;

	private bool _canUserUseFacebookComposer;

	private bool _hasPublishPermission;

	private bool _hasPublishActions;

	private GameCenterSingleton _gc;

	public static int FontSizeForMessages
	{
		get
		{
			return Mathf.RoundToInt((float)Screen.height * 0.03f);
		}
	}

	public static float iOSVersion
	{
		get
		{
			float result = -1f;
			string text = SystemInfo.operatingSystem.Replace("iPhone OS ", string.Empty);
			float.TryParse(text.Substring(0, 1), out result);
			return result;
		}
	}

	private string _SocialMessage()
	{
		return "I scored " + PlayerPrefs.GetInt(Defs.BestScoreSett, 0) + " points in Pixel Gun 3D! Try to beat my result! Check out Pixel Gun 3D right now! https://itunes.apple.com/us/app/pixlgun-3d-block-world-pocket/id640111933?mt=8";
	}

	private string _SocialSentSuccess(string SocialName)
	{
		return "Your best score was sent to " + SocialName;
	}

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

	private void Start()
	{
		PhotonNetwork.PhotonServerSettings.UseCloud("a2d8764b-7e5d-40d3-9f10-7fc682e3ca2e", 0);
		InitFacebookEvents();
		keychainPlugin.createKCValue(0, Defs.EarnedCoins);
		keychainPlugin.updateKCValue(0, Defs.EarnedCoins);
		FacebookBinding.init();
		FacebookBinding.setSessionLoginBehavior(FacebookSessionLoginBehavior.UseSystemAccountIfPresent);
		Invoke("setEnabledGUI", 0.1f);
		if (GlobalGameController.isFullVersion)
		{
			PlayerPrefs.SetInt("FullVersion", 1);
			Debug.Log("FULL VERSION");
		}
		else
		{
			Debug.Log("LITE VERSION");
		}
		_purchaseActivityIndicator = StoreKitEventListener.purchaseActivityInd;
		_purchaseActivityIndicator.SetActive(false);
		PlayerPrefs.SetInt("typeConnect__", 0);
		productIdentifiers = StoreKitEventListener.idsForFull;
		Debug.Log("productIdentifiers = " + productIdentifiers);
		if (!GameObject.FindGameObjectWithTag("SkinsManager") && (bool)skinsManagerPrefab)
		{
			UnityEngine.Object.Instantiate(skinsManagerPrefab, Vector3.zero, Quaternion.identity);
		}
		if (!GameObject.FindGameObjectWithTag("WeaponManager") && (bool)weaponManagerPrefab)
		{
			UnityEngine.Object.Instantiate(weaponManagerPrefab, Vector3.zero, Quaternion.identity);
		}
		GlobalGameController.ResetParameters();
		GlobalGameController.Score = 0;
		_inAppGameObject = GameObject.FindGameObjectWithTag("InAppGameObject");
		_listener = _inAppGameObject.GetComponent<StoreKitEventListener>();
		SetProducts(null);
		StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
		if (StoreKitBinding.canMakePayments())
		{
			StoreKitManager.productListReceivedEvent += SetProducts;
		}
		if (iOSVersion > 5f)
		{
			FacebookManager.graphRequestCompletedEvent += facebookGraphReqCompl;
			FacebookManager.sessionOpenedEvent += facebookSessionOpened;
			FacebookManager.reauthorizationSucceededEvent += facebookreauthorizationSucceededEvent;
			_canUserUseFacebookComposer = FacebookBinding.canUserUseFacebookComposer();
		}
		_gc = GameCenterSingleton.Instance;
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

	private void Update()
	{
		if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	private void setEnabledGUI()
	{
		isFirstFrame = false;
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

	private void OnEventFacebookLoginFailed(string s)
	{
		clickButtonFacebook = false;
		Debug.Log("OnEventFacebookLoginFailed=" + s);
	}

	private void OnGUI()
	{
		GUI.DrawTexture(new Rect(((float)Screen.width - 2048f * (float)Screen.height / 1154f) / 2f, 0f, 2048f * (float)Screen.height / 1154f, Screen.height), fon, ScaleMode.StretchToFill);
		Rect position = new Rect((float)Screen.width / 4f - (float)(playStyle.normal.background.width * Screen.height) / 768f * 0.5f, (float)Screen.height * 0.68f - (float)playStyle.normal.background.height * 0.5f * (float)Screen.height / 768f, (float)(playStyle.normal.background.width * Screen.height) / 768f, (float)(playStyle.normal.background.height * Screen.height) / 768f);
		if (GUI.RepeatButton(position, string.Empty, playStyle))
		{
			GUIHelper.DrawLoading();
			PlayerPrefs.SetInt("MultyPlayer", 0);
			PlayerPrefs.SetInt("COOP", 0);
			GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>().Reset();
			PlayerPrefs.SetFloat(Defs.CurrentHealthSett, Player_move_c.MaxPlayerHealth);
			PlayerPrefs.SetFloat(Defs.CurrentArmorSett, 0f);
			Application.LoadLevel("LoadingNoWait");
		}
		Rect position2 = new Rect((float)Screen.width / 4f * 2f - (float)playMultyStyle.normal.background.width * 0.5f * (float)Screen.height / 768f, position.y, (float)(playMultyStyle.normal.background.width * Screen.height) / 768f, (float)(playMultyStyle.normal.background.height * Screen.height) / 768f);
		if (GUI.RepeatButton(position2, string.Empty, playMultyStyle))
		{
			GUIHelper.DrawLoading();
			PlayerPrefs.SetInt("MultyPlayer", 1);
			PlayerPrefs.SetInt("COOP", 0);
			GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>().Reset();
			Application.LoadLevel("ConnectScene");
		}
		Rect position3 = new Rect((float)Screen.width / 4f * 3f - (float)(coopStyle.normal.background.width * Screen.height) / 768f * 0.5f, position.y, (float)(coopStyle.normal.background.width * Screen.height) / 768f, (float)(coopStyle.normal.background.height * Screen.height) / 768f);
		if (GUI.RepeatButton(position3, string.Empty, coopStyle))
		{
			GUIHelper.DrawLoading();
			PlayerPrefs.SetString("TypeConnect", "inet");
			PlayerPrefs.SetInt("COOP", 1);
			PlayerPrefs.SetInt("MultyPlayer", 1);
			GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>().Reset();
			Application.LoadLevel("ConnectScene");
		}
		float num = (float)facebookStyle.normal.background.width * Defs.Coef / 3f;
		Rect position4 = new Rect((float)Screen.width / 2f + (float)facebookStyle.normal.background.width * Defs.Coef * 0.5f + num, (float)Screen.height * 0.923f - (float)Screen.height * 0.0525f, (float)twitterStyle.normal.background.width * Defs.Coef, (float)twitterStyle.normal.background.height * Defs.Coef);
		Rect position5 = new Rect(position.x, (float)Screen.height * 0.923f - (float)Screen.height * 0.0525f, (float)soundStyle.normal.background.width * Defs.Coef, (float)soundStyle.normal.background.height * Defs.Coef);
		float num2 = 1.25f;
		Rect position6 = new Rect((float)Screen.width / 2f - (float)facebookStyle.normal.background.width * Defs.Coef * 1.5f - num, (float)Screen.height * 0.923f - (float)Screen.height * 0.0525f, (float)facebookStyle.normal.background.width * Defs.Coef, (float)facebookStyle.normal.background.height * Defs.Coef);
		float coef = Defs.Coef;
		float num3 = (float)skinsMakerStyle.normal.background.width * coef;
		float height = num3 * ((float)skinsMakerStyle.normal.background.height / (float)skinsMakerStyle.normal.background.width);
		if (GUI.RepeatButton(new Rect(position3.x + position3.width - num3, position5.y, num3, height), string.Empty, skinsMakerStyle))
		{
			GUIHelper.DrawLoading();
			PlayerPrefs.SetInt(Defs.SkinEditorMode, 0);
			Application.LoadLevel("SkinEditor");
		}
		if (GUI.Button(position4, string.Empty, twitterStyle))
		{
			InitTwitter();
		}
		if (!iswinter && GUI.Button(position6, string.Empty, facebookStyle))
		{
			//InitFacebook();
			fon = Resources.Load("winter_fon") as Texture;
			iswinter = true;
		}
		if (iswinter && GUI.Button(position6, string.Empty, facebookStyle))
		{
			//InitFacebook();
			fon = Resources.Load("slender_fon") as Texture;
			iswinter = false;
		}
		float left = (float)Screen.width / 2f - position6.width / 2f;
		float width = (float)Screen.height * 0.105f;
		if (GUI.Button(new Rect(left, (float)Screen.height * 0.923f - (float)Screen.height * 0.0525f, width, (float)Screen.height * 0.105f), string.Empty, gamecenterStyle))
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
		if (GUI.Button(position5, string.Empty, soundStyle) && !isFirstFrame)
		{
			Application.LoadLevel("SettingScene");
		}
		float num4 = (float)Screen.height / 768f;
		bestScoreStyle.fontSize = Mathf.RoundToInt((float)Screen.height * 0.04f);
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
		if (Time.realtimeSinceStartup - _timeWhenPurchShown >= 2f)
		{
			productPurchased = false;
		}
		if (productPurchased)
		{
			labelStyle.fontSize = FontSizeForMessages;
			GUI.Label(Player_move_c.SuccessMessageRect(), "Purchase was successful", labelStyle);
		}
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
		_products = _listener._fullProducts;
		_products.Sort(Comparison);
	}

	private void purchaseSuccessful(StoreKitTransaction transaction)
	{
		Debug.Log("purchased product: " + transaction.productIdentifier);
		if (transaction.productIdentifier.Equals(_products[0].productIdentifier))
		{
			PlayerPrefs.SetInt("FullVersion", 1);
			if (isPressFullOnMulty)
			{
				PlayerPrefs.SetInt("MultyPlayer", 1);
				GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>().Reset();
				Application.LoadLevel("ConnectScene");
			}
			else
			{
				showUnlockDialog = false;
			}
		}
		productPurchased = true;
		_timeWhenPurchShown = Time.realtimeSinceStartup;
	}

	private IEnumerator _ResetProductPurchased()
	{
		yield return new WaitForSeconds(1f);
		productPurchased = false;
	}

	private void OnDestroy()
	{
		FacebookManager.graphRequestCompletedEvent -= facebookGraphReqCompl;
		FacebookManager.sessionOpenedEvent -= facebookSessionOpened;
		FacebookManager.reauthorizationSucceededEvent -= facebookreauthorizationSucceededEvent;
		StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessful;
		StoreKitManager.productListReceivedEvent -= SetProducts;
		CleanFacebookEvents();
	}

	private void hideMessag()
	{
		showMessagFacebook = false;
	}

	private void hideMessagTwitter()
	{
		showMessagTiwtter = false;
	}
}
