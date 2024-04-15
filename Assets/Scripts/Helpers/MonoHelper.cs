
using System.Collections;
using UnityEngine;
public class MonoHelper : UnitySingleton<MonoHelper>
{
	public void StartCourutine(IEnumerator coroutine)
	{
		base.StartCoroutine(coroutine);
	}

	public T FindOrCreate<T>() where T : Component
	{
		T val = (T)Object.FindObjectOfType(typeof(T));
		if (val == null)
		{
			GameObject gameObject = new GameObject();
			val = gameObject.AddComponent<T>();
			val.name = typeof(T).ToString();
		}
		return val;
	}

	public T FindOrCreate<T>(string nameObject) where T : Component
	{
		T val = (T)Object.FindObjectOfType(typeof(T));
		if (val == null)
		{
			GameObject gameObject = new GameObject();
			val = gameObject.AddComponent<T>();
			gameObject.name = nameObject;
		}
		return val;
	}

	public T GetOrCreateComponent<T>() where T : Component
	{
		T val = base.GetComponent<T>();
		if (val == null)
		{
			val = base.gameObject.AddComponent<T>();
		}
		return val;
	}
}
