using System;
using System.Collections.Generic;
using UnityEngine;

public class coinsShop : MonoBehaviour
{
	public static coinsShop thisScript;

	public static bool showPlashkuPriExit;

	public Action onReturnAction;

	private float kfSize = (float)Screen.height / 768f;

	private float reSizeWidth;

	public GameObject _purchaseActivityIndicator;

	private bool productPurchased;

	private float _timeWhenPurchShown;

	public GUIStyle labelStyle;

	public GUIStyle notEnoughCoinsStyle;

	public bool notEnoughCoins;

	public Texture txFon;

	public Texture txTitle;

	public GUIStyle stBut1;

	public GUIStyle stBut2;

	public GUIStyle stBut3;

	public GUIStyle stBut4;

	public GUIStyle stBut5;

	public GUIStyle stBut6;

	public GUIStyle stBut7;

	public GUIStyle stButBack;

	public GUIStyle noInternetStyle;

	private Rect[] rects = new Rect[7];

	private GUIStyle[] styles = new GUIStyle[7];

	private bool coinsBought;

	private Rect rectFon;

	private Rect rectBut1;

	private Rect rectBut2;

	private Rect rectBut3;

	private Rect rectBut4;

	private Rect rectBut5;

	private Rect rectButBack;

	private Rect rectTitle;

	private bool productsReceived;

	private void SetProducts(List<StoreKitProduct> allProducts)
	{
		productsReceived = true;
	}

	private void OnEnable()
	{
		StoreKitManager.productListReceivedEvent += SetProducts;
		StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
		GameObject gameObject = GameObject.FindGameObjectWithTag("InAppGameObject");
		StoreKitEventListener component = gameObject.GetComponent<StoreKitEventListener>();
		if (component._coinProducts.Count > 0)
		{
			SetProducts(null);
		}
		_purchaseActivityIndicator = StoreKitEventListener.purchaseActivityInd;
		if (_purchaseActivityIndicator != null)
		{
			_purchaseActivityIndicator.SetActive(false);
		}
		coinsBought = false;
	}

	private void OnDisable()
	{
		StoreKitManager.productListReceivedEvent -= SetProducts;
		StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessful;
		if (_purchaseActivityIndicator != null)
		{
			_purchaseActivityIndicator.SetActive(false);
		}
		coinsBought = false;
	}

	private void purchaseSuccessful(StoreKitTransaction transaction)
	{
		if (coinsBought)
		{
			productPurchased = true;
			_timeWhenPurchShown = Time.realtimeSinceStartup;
		}
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		thisScript = base.gameObject.GetComponent<coinsShop>();
		hideCoinsShop();
		rectFon = new Rect((float)Screen.width * 0.5f - 683f * kfSize, 0f, 1366f * kfSize, 768f * kfSize);
		float num = (float)Screen.width / 45f;
		float num2 = ((float)Screen.width - ((float)StoreKitEventListener.coinIds.Length + 1f) * num) / (float)StoreKitEventListener.coinIds.Length;
		for (int i = 0; i < StoreKitEventListener.coinIds.Length; i++)
		{
			rects[i] = new Rect((float)(i + 1) * num + (float)i * num2, 288f * kfSize, num2, num2 * ((float)stBut1.normal.background.height / (float)stBut1.normal.background.width));
		}
		rectButBack = new Rect((float)Screen.width * 0.5f - (float)stButBack.normal.background.width * kfSize * 0.5f, (float)Screen.height - 108f * kfSize, (float)stButBack.normal.background.width * kfSize, (float)stButBack.normal.background.height * kfSize);
		rectTitle = new Rect((float)Screen.width * 0.5f - (float)txTitle.width * kfSize * 0.5f, 137f * kfSize, (float)txTitle.width * kfSize, (float)txTitle.height * kfSize);
		styles[0] = stBut1;
		styles[1] = stBut6;
		styles[2] = stBut7;
		styles[3] = stBut2;
		styles[4] = stBut3;
		styles[5] = stBut4;
		styles[6] = stBut5;
	}

	public static void showCoinsShop()
	{
		thisScript.enabled = true;
		coinsPlashka.hideButtonCoins = true;
		coinsPlashka.showPlashka();
	}

	public static void hideCoinsShop()
	{
		thisScript.enabled = false;
	}

	private void OnGUI()
	{
		GUI.depth = -2;
		GUI.enabled = !StoreKitEventListener.purchaseInProcess;
		if (notEnoughCoins)
		{
			float num = 2f * (float)Screen.width / 5f;
			float num2 = 2f * (float)Screen.height / 10f;
			Rect position = new Rect((float)Screen.width / 2f - num / 2f, coinsPlashka.thisScript.rectLabelCoins.y + coinsPlashka.thisScript.rectLabelCoins.height / 2f - num2 / 2f, num, num2);
			notEnoughCoinsStyle.fontSize = Mathf.RoundToInt(30f * Defs.Coef);
			GUI.Box(position, "Not enough coins...", notEnoughCoinsStyle);
		}
		if (Time.realtimeSinceStartup - _timeWhenPurchShown >= 2f)
		{
			productPurchased = false;
		}
		if (productPurchased)
		{
			labelStyle.fontSize = Player_move_c.FontSizeForMessages;
			GUI.Label(Player_move_c.SuccessMessageRect(), "Purchase was successful", labelStyle);
		}
		_purchaseActivityIndicator.SetActive(StoreKitEventListener.purchaseInProcess);
		GUI.DrawTexture(rectFon, txFon);
		GUI.DrawTexture(rectTitle, txTitle);
		guiButtonCoins();
		if (GUI.Button(rectButBack, string.Empty, stButBack))
		{
			hideCoinsShop();
			if (showPlashkuPriExit)
			{
				coinsPlashka.hidePlashka();
			}
			coinsPlashka.hideButtonCoins = false;
			if (onReturnAction != null && coinsBought)
			{
				coinsBought = false;
				onReturnAction();
			}
			else
			{
				onReturnAction = null;
			}
		}
		GUI.enabled = true;
	}

	private void guiButtonCoins()
	{
		if (!productsReceived)
		{
			float num = (float)Screen.width / 2f;
			noInternetStyle.fontSize = Mathf.RoundToInt(30f * (float)Screen.height / 768f);
			GUI.Box(new Rect((float)Screen.width / 2f - num / 2f, (float)Screen.height / 4f, num, (float)Screen.height / 2f), "No connection to App Store...", noInternetStyle);
			return;
		}
		for (int i = 0; i < StoreKitEventListener.coinIds.Length; i++)
		{
			if (GUI.Button(rects[i], string.Empty, styles[i]))
			{
				coinsBought = true;
				StoreKitEventListener.purchaseInProcess = true;
				StoreKitBinding.purchaseProduct(StoreKitEventListener.coinIds[i], 1);
			}
		}
	}
}
