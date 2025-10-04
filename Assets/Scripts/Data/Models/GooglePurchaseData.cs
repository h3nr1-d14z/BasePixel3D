using System;
using UnityEngine;

internal class GooglePurchaseData
{
	[Serializable]
	private struct GooglePurchaseReceipt
	{
		public string Payload;
	}

	[Serializable]
	private struct GooglePurchasePayload
	{
		public string json;

		public string signature;
	}

	[Serializable]
	public struct GooglePurchaseJson
	{
		public string autoRenewing;

		public string orderId;

		public string packageName;

		public string productId;

		public string purchaseTime;

		public string purchaseState;

		public string developerPayload;

		public string purchaseToken;
	}

	public string inAppPurchaseData;

	public string inAppDataSignature;

	public GooglePurchaseJson json;

	public GooglePurchaseData(string receipt)
	{
		try
		{
			GooglePurchaseReceipt googlePurchaseReceipt = JsonUtility.FromJson<GooglePurchaseReceipt>(receipt);
			GooglePurchasePayload googlePurchasePayload = JsonUtility.FromJson<GooglePurchasePayload>(googlePurchaseReceipt.Payload);
			GooglePurchaseJson googlePurchaseJson = JsonUtility.FromJson<GooglePurchaseJson>(googlePurchasePayload.json);
			this.inAppPurchaseData = googlePurchasePayload.json;
			this.inAppDataSignature = googlePurchasePayload.signature;
			this.json = googlePurchaseJson;
		}
		catch
		{
			UnityEngine.Debug.Log("Could not parse receipt: " + receipt);
			this.inAppPurchaseData = string.Empty;
			this.inAppDataSignature = string.Empty;
		}
	}
}


