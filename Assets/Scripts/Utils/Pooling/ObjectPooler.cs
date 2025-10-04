using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	public static ObjectPooler Instance;

	protected virtual void Awake()
	{
		ObjectPooler.Instance = this;
	}

	protected virtual void Start()
	{
		this.FillObjectPool();
	}

	protected virtual void FillObjectPool()
	{
	}

	public virtual GameObject GetPooledGameObject()
	{
		return null;
	}
}


