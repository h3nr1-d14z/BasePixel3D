using UnityEngine;

public class NativeAdsWrapper : MonoBehaviour
{
	public static NativeAdsWrapper Instance;

	private static string placementId = "599653430210285_731306580378302";

	private void Awake()
	{
		NativeAdsWrapper.Instance = this;
	}

	private void Log(string s)
	{
	}
}


