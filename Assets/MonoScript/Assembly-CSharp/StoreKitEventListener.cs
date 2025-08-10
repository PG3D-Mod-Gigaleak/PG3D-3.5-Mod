using System;
using System.Collections.Generic;
using UnityEngine;

public class StoreKitEventListener : MonoBehaviour
{
	public static string elixirSettName = Defs.NumberOfElixirsSett;

	public static string fullSettName = "FullVersion";

	public static bool purchaseInProcess = false;

	public static bool restoreInProcess = false;

	public static GameObject purchaseActivityInd = null;

	public static string bigAmmoPackID = ((!GlobalGameController.isFullVersion) ? "bigpackofammolite" : "bigammopack");

	public static string fullHealthID = ((!GlobalGameController.isFullVersion) ? "Fullhealthlite" : "Fullhealth");

	public static string minerWeaponID = ((!GlobalGameController.isFullVersion) ? "trueminerweaponlite" : "MinerWeapon");

	public static string elixirID = ((!GlobalGameController.isFullVersion) ? "elixirlite" : "elixir");

	public static string crystalswordID = ((!GlobalGameController.isFullVersion) ? "crystalswordlite" : "crystalsword");

	public static string endmanskin = ((!GlobalGameController.isFullVersion) ? "endmanskinlite" : "endmanskin");

	public static string chief = ((!GlobalGameController.isFullVersion) ? "chiefskinlite" : "chief");

	public static string spaceengineer = ((!GlobalGameController.isFullVersion) ? "spaceengineerskinlite" : "spaceengineer");

	public static string nanosoldier = ((!GlobalGameController.isFullVersion) ? "nanosoldierlite" : "nanosoldier");

	public static string steelman = ((!GlobalGameController.isFullVersion) ? "steelmanlite" : "steelman");

	public static string CaptainSkin = "captainskin";

	public static string HawkSkin = "hawkskin";

	public static string GreenGuySkin = "greenguyskin";

	public static string TunderGodSkin = "thundergodskin";

	public static string GordonSkin = "gordonskin";

	public static string animeGirl = "animeGirl";

	public static string EMOGirl = "EMOGirl";

	public static string Nurse = "Nurse";

	public static string magicGirl = "magicGirl";

	public static string braveGirl = "braveGirl";

	public static string glamDoll = "glamDoll";

	public static string kittyGirl = "kittyGirl";

	public static string famosBoy = "famosBoy";

	public static string combatrifle = ((!GlobalGameController.isFullVersion) ? "combatriflelite" : "combatrifle");

	public static string goldeneagle = ((!GlobalGameController.isFullVersion) ? "goldeneaglelite" : "goldeneagle");

	public static string magicbow = ((!GlobalGameController.isFullVersion) ? "magicbowlite" : "magicbow");

	public static string fullVersion = "extendedversion";

	public static string coin1 = "coin1";

	public static string coin2 = "coin2";

	public static string coin3 = "coin3";

	public static string coin4 = "coin4";

	public static string coin5 = "coin5";

	public static string coin6 = "coin6";

	public static string coin7 = "coin7";

	public static string axe = "axe";

	public static string spas = "spas";

	public static string chainsaw = "chainsaw";

	public static string famas = "famas";

	public static string glock = "glock";

	public static string scythe = "scythe";

	public static string shovel = "shovel";

	public static string armor = "armor";

	public static string[] skinIDs = new string[18]
	{
		endmanskin, chief, spaceengineer, nanosoldier, steelman, CaptainSkin, HawkSkin, GreenGuySkin, TunderGodSkin, GordonSkin,
		animeGirl, EMOGirl, Nurse, magicGirl, braveGirl, glamDoll, kittyGirl, famosBoy
	};

	public static string[] idsForSingle = new string[11]
	{
		bigAmmoPackID, fullHealthID, crystalswordID, minerWeaponID, axe, spas, elixirID, glock, chainsaw, scythe,
		shovel
	};

	public static string[] idsForMulti = new string[10]
	{
		idsForSingle[2],
		idsForSingle[3],
		axe,
		magicbow,
		combatrifle,
		spas,
		goldeneagle,
		idsForSingle[7],
		idsForSingle[8],
		famas
	};

	public static string[] idsForFull = new string[1] { fullVersion };

	public static string[] coinIds = new string[7] { coin1, coin6, coin7, coin2, coin3, coin4, coin5 };

	public static string[][] categoriesSingle = new string[3][]
	{
		new string[2]
		{
			idsForSingle[5],
			idsForSingle[7]
		},
		new string[6]
		{
			idsForSingle[3],
			idsForSingle[4],
			idsForSingle[2],
			idsForSingle[8],
			idsForSingle[9],
			idsForSingle[10]
		},
		new string[4]
		{
			idsForSingle[0],
			idsForSingle[1],
			armor,
			idsForSingle[6]
		}
	};

	public static string[][] categoriesMulti = new string[3][]
	{
		new string[6]
		{
			idsForMulti[6],
			idsForMulti[4],
			idsForMulti[3],
			idsForSingle[5],
			idsForSingle[7],
			idsForMulti[9]
		},
		new string[6]
		{
			idsForSingle[3],
			idsForSingle[4],
			idsForSingle[2],
			idsForSingle[8],
			idsForSingle[9],
			idsForSingle[10]
		},
		new string[3]
		{
			idsForSingle[0],
			idsForSingle[1],
			armor
		}
	};

	public GameObject messagePrefab;

	public List<StoreKitProduct> _products = new List<StoreKitProduct>();

	public List<StoreKitProduct> _skinProducts = new List<StoreKitProduct>();

	public List<StoreKitProduct> _multiplayerProducts = new List<StoreKitProduct>();

	public List<StoreKitProduct> _fullProducts = new List<StoreKitProduct>();

	public List<StoreKitProduct> _coinProducts = new List<StoreKitProduct>();

	public void ProvideContent()
	{
		Storager.setInt(Defs.InAppBoughtSett, 1);
	}

	private void Start()
	{
		GameObject original = Resources.Load("ActivityIndicator") as GameObject;
		purchaseActivityInd = UnityEngine.Object.Instantiate(original) as GameObject;
		if (StoreKitBinding.canMakePayments())
		{
			string[] array = new string[idsForSingle.Length + idsForMulti.Length + skinIDs.Length + idsForFull.Length + coinIds.Length];
			idsForSingle.CopyTo(array, 0);
			idsForMulti.CopyTo(array, idsForSingle.Length);
			skinIDs.CopyTo(array, idsForSingle.Length + idsForMulti.Length);
			idsForFull.CopyTo(array, idsForSingle.Length + idsForMulti.Length + skinIDs.Length);
			coinIds.CopyTo(array, idsForSingle.Length + idsForMulti.Length + skinIDs.Length + idsForFull.Length);
			StoreKitBinding.requestProductData(array);
		}
	}

	private void OnEnable()
	{
		StoreKitManager.productPurchaseAwaitingConfirmationEvent += productPurchaseAwaitingConfirmationEvent;
		StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
		StoreKitManager.purchaseCancelledEvent += purchaseCancelled;
		StoreKitManager.purchaseFailedEvent += purchaseFailed;
		StoreKitManager.receiptValidationFailedEvent += receiptValidationFailed;
		StoreKitManager.receiptValidationRawResponseReceivedEvent += receiptValidationRawResponseReceived;
		StoreKitManager.receiptValidationSuccessfulEvent += receiptValidationSuccessful;
		StoreKitManager.productListReceivedEvent += productListReceivedEvent;
		StoreKitManager.productListRequestFailedEvent += productListRequestFailed;
		StoreKitManager.restoreTransactionsFailedEvent += restoreTransactionsFailed;
		StoreKitManager.restoreTransactionsFinishedEvent += restoreTransactionsFinished;
		StoreKitManager.paymentQueueUpdatedDownloadsEvent += paymentQueueUpdatedDownloadsEvent;
	}

	private void OnDisable()
	{
		StoreKitManager.productPurchaseAwaitingConfirmationEvent -= productPurchaseAwaitingConfirmationEvent;
		StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessful;
		StoreKitManager.purchaseCancelledEvent -= purchaseCancelled;
		StoreKitManager.purchaseFailedEvent -= purchaseFailed;
		StoreKitManager.receiptValidationFailedEvent -= receiptValidationFailed;
		StoreKitManager.receiptValidationRawResponseReceivedEvent -= receiptValidationRawResponseReceived;
		StoreKitManager.receiptValidationSuccessfulEvent -= receiptValidationSuccessful;
		StoreKitManager.productListReceivedEvent -= productListReceivedEvent;
		StoreKitManager.productListRequestFailedEvent -= productListRequestFailed;
		StoreKitManager.restoreTransactionsFailedEvent -= restoreTransactionsFailed;
		StoreKitManager.restoreTransactionsFinishedEvent -= restoreTransactionsFinished;
		StoreKitManager.paymentQueueUpdatedDownloadsEvent -= paymentQueueUpdatedDownloadsEvent;
	}

	private void productListReceivedEvent(List<StoreKitProduct> productList)
	{
		Debug.Log("productListReceivedEvent. total products received: " + productList.Count);
		IList<string> list = idsForSingle;
		IList<string> list2 = skinIDs;
		IList<string> list3 = idsForMulti;
		IList<string> list4 = idsForFull;
		IList<string> list5 = coinIds;
		foreach (StoreKitProduct product in productList)
		{
			if (list.Contains(product.productIdentifier) && !_products.Contains(product))
			{
				_products.Add(product);
			}
			if (list2.Contains(product.productIdentifier) && !_skinProducts.Contains(product))
			{
				_skinProducts.Add(product);
			}
			if (list3.Contains(product.productIdentifier) && !_multiplayerProducts.Contains(product))
			{
				_multiplayerProducts.Add(product);
			}
			if (list4.Contains(product.productIdentifier) && !_fullProducts.Contains(product))
			{
				_fullProducts.Add(product);
				Debug.Log("----------------- _fullProducts.Add" + product);
			}
			if (list5.Contains(product.productIdentifier) && !_coinProducts.Contains(product))
			{
				_coinProducts.Add(product);
			}
			Debug.Log("+++++++++++ " + product.ToString() + "\n");
		}
	}

	private void productListRequestFailed(string error)
	{
		Debug.Log("productListRequestFailed: " + error);
	}

	private void receiptValidationSuccessful()
	{
		Debug.Log("receipt validation successful");
	}

	private void receiptValidationFailed(string error)
	{
		Debug.Log("receipt validation failed with error: " + error);
	}

	private void receiptValidationRawResponseReceived(string response)
	{
		Debug.Log("receipt validation raw response: " + response);
	}

	private void purchaseFailed(string error)
	{
		purchaseInProcess = false;
		Debug.Log("purchase failed with error: " + error);
	}

	private void purchaseCancelled(string error)
	{
		purchaseInProcess = false;
		Debug.Log("purchase cancelled with error: " + error);
	}

	private void productPurchaseAwaitingConfirmationEvent(StoreKitTransaction transaction)
	{
		Debug.Log("productPurchaseAwaitingConfirmationEvent: " + transaction);
	}

	private void purchaseSuccessful(StoreKitTransaction transaction)
	{
		Debug.Log("purchased product: " + transaction);
		if (transaction.productIdentifier.Equals(elixirID))
		{
			Defs.NumberOfElixirs++;
		}
		if (transaction.productIdentifier.Equals(fullVersion))
		{
			PlayerPrefs.SetInt(fullSettName, 1);
			PlayerPrefs.Save();
			Debug.Log("FULL VERSION");
		}
		if (Array.IndexOf(skinIDs, transaction.productIdentifier) >= 0)
		{
			foreach (int key in InAppData.inAppData.Keys)
			{
				if (InAppData.inAppData[key].Key.Equals(transaction.productIdentifier))
				{
					Storager.setInt(InAppData.inAppData[key].Value, 1);
				}
			}
		}
		int num = Array.IndexOf(coinIds, transaction.productIdentifier);
		if (num >= 0)
		{
			keychainPlugin.updateKCValue(keychainPlugin.getKCValue(Defs.Coins) + VirtualCurrencyHelper.coinInappsQuantity[num], Defs.Coins);
		}
		purchaseInProcess = false;
	}

	private void restoreTransactionsFailed(string error)
	{
		purchaseInProcess = false;
		restoreInProcess = false;
		Debug.Log("restoreTransactionsFailed: " + error);
	}

	private void restoreTransactionsFinished()
	{
		purchaseInProcess = false;
		restoreInProcess = false;
		Debug.Log("restoreTransactionsFinished");
		UnityEngine.Object.Instantiate(messagePrefab);
	}

	private void paymentQueueUpdatedDownloadsEvent(List<StoreKitDownload> downloads)
	{
		Debug.Log("paymentQueueUpdatedDownloadsEvent: ");
		foreach (StoreKitDownload download in downloads)
		{
			Debug.Log(download);
		}
	}
}
