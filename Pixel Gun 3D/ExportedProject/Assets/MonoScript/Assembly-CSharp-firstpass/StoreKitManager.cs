using System;
using System.Collections.Generic;
using Prime31;
using UnityEngine;

public class StoreKitManager : AbstractManager
{
	public static bool autoConfirmTransactions;

	public static event Action<List<StoreKitProduct>> productListReceivedEvent;

	public static event Action<string> productListRequestFailedEvent;

	public static event Action<StoreKitTransaction> productPurchaseAwaitingConfirmationEvent;

	public static event Action<StoreKitTransaction> purchaseSuccessfulEvent;

	public static event Action<string> purchaseFailedEvent;

	public static event Action<string> purchaseCancelledEvent;

	public static event Action<string> receiptValidationFailedEvent;

	public static event Action<string> receiptValidationRawResponseReceivedEvent;

	public static event Action receiptValidationSuccessfulEvent;

	public static event Action<string> restoreTransactionsFailedEvent;

	public static event Action restoreTransactionsFinishedEvent;

	public static event Action<List<StoreKitDownload>> paymentQueueUpdatedDownloadsEvent;

	static StoreKitManager()
	{
		autoConfirmTransactions = true;
		AbstractManager.initialize(typeof(StoreKitManager));
	}

	public void productPurchaseAwaitingConfirmation(string json)
	{
		if (StoreKitManager.productPurchaseAwaitingConfirmationEvent != null)
		{
			StoreKitManager.productPurchaseAwaitingConfirmationEvent(StoreKitTransaction.transactionFromJson(json));
		}
		if (autoConfirmTransactions)
		{
			StoreKitBinding.finishPendingTransactions();
		}
	}

	public void productPurchased(string json)
	{
		Debug.Log("productPurchased");
		if (StoreKitManager.purchaseSuccessfulEvent != null)
		{
			StoreKitManager.purchaseSuccessfulEvent(StoreKitTransaction.transactionFromJson(json));
		}
	}

	public void productPurchaseFailed(string error)
	{
		Debug.Log("productPurchaseFailed");
		if (StoreKitManager.purchaseFailedEvent != null)
		{
			StoreKitManager.purchaseFailedEvent(error);
		}
	}

	public void productPurchaseCancelled(string error)
	{
		Debug.Log("productPurchaseCancelled");
		if (StoreKitManager.purchaseCancelledEvent != null)
		{
			StoreKitManager.purchaseCancelledEvent(error);
		}
	}

	public void productsReceived(string json)
	{
		Debug.Log("productsReceived");
		if (StoreKitManager.productListReceivedEvent != null)
		{
			StoreKitManager.productListReceivedEvent(StoreKitProduct.productsFromJson(json));
		}
	}

	public void productsRequestDidFail(string error)
	{
		Debug.Log("productsRequestDidFail");
		if (StoreKitManager.productListRequestFailedEvent != null)
		{
			StoreKitManager.productListRequestFailedEvent(error);
		}
	}

	public void validateReceiptFailed(string error)
	{
		Debug.Log("validateReceiptFailed");
		if (StoreKitManager.receiptValidationFailedEvent != null)
		{
			StoreKitManager.receiptValidationFailedEvent(error);
		}
	}

	public void validateReceiptRawResponse(string response)
	{
		Debug.Log("validateReceiptRawResponse");
		if (StoreKitManager.receiptValidationRawResponseReceivedEvent != null)
		{
			StoreKitManager.receiptValidationRawResponseReceivedEvent(response);
		}
	}

	public void validateReceiptFinished(string statusCode)
	{
		Debug.Log("validateReceiptFinished");
		if (statusCode == "0")
		{
			if (StoreKitManager.receiptValidationSuccessfulEvent != null)
			{
				StoreKitManager.receiptValidationSuccessfulEvent();
			}
		}
		else if (StoreKitManager.receiptValidationFailedEvent != null)
		{
			StoreKitManager.receiptValidationFailedEvent("Receipt validation failed with statusCode: " + statusCode);
		}
	}

	public void restoreCompletedTransactionsFailed(string error)
	{
		Debug.Log("restoreCompletedTransactionsFailed");
		if (StoreKitManager.restoreTransactionsFailedEvent != null)
		{
			StoreKitManager.restoreTransactionsFailedEvent(error);
		}
	}

	public void restoreCompletedTransactionsFinished(string empty)
	{
		Debug.Log("restoreCompletedTransactionsFinished");
		if (StoreKitManager.restoreTransactionsFinishedEvent != null)
		{
			StoreKitManager.restoreTransactionsFinishedEvent();
		}
	}

	public void paymentQueueUpdatedDownloads(string json)
	{
		Debug.Log("paymentQueueUpdatedDownloads");
		if (StoreKitManager.paymentQueueUpdatedDownloadsEvent != null)
		{
			StoreKitManager.paymentQueueUpdatedDownloadsEvent(StoreKitDownload.downloadsFromJson(json));
		}
	}
}
