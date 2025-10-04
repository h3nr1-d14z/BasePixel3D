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
		if (instance == null)
		{
			Debug.LogError($"PrefabLoader instance is null! Make sure PrefabLoader is in the scene. Trying to load: {name}");
			return null;
		}

		if (instance.windows == null || instance.windows.Length == 0)
		{
			Debug.LogError($"PrefabLoader windows array is null or empty! Check the PrefabLoader component in the scene. Trying to load: {name}");
			return null;
		}

		var w = instance.windows.FirstOrDefault(t => t != null && t.name == name);
		if (w == null)
		{
			Debug.LogWarning($"Window with name '{name}' not found in PrefabLoader windows array");
		}
		return (T)w;
	}
}
