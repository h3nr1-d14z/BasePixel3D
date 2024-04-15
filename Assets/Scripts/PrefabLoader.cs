using System.Linq;
using UnityEngine;

public class PrefabLoader : MonoBehaviour
{

	public BaseWindow[] windows;

	private static PrefabLoader instance;
	private void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public static T Load<T>(string name) where T : BaseWindow
	{
		var w = instance.windows.FirstOrDefault(t => t.name == name);
		return (T)w;
	}
}
