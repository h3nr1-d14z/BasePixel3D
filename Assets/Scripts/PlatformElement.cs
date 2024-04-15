using System.Collections.Generic;
using UnityEngine;

public class PlatformElement : MonoBehaviour
{
	[SerializeField]
	private GameObject target;

	[SerializeField]
	private List<RuntimePlatform> platforms;

	private void Awake()
	{
		if (this.platforms.Contains(Application.platform))
		{
			this.target.SetActive(true);
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}
}


