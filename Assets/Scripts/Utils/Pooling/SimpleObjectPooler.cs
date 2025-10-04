

using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPooler : ObjectPooler
{
	public GameObject GameObjectToPool;

	public int PoolSize = 20;

	public bool PoolCanExpand = true;

	protected GameObject _waitingPool;

	protected List<GameObject> _pooledGameObjects;

	protected override void FillObjectPool()
	{
		this._waitingPool = new GameObject("[SimpleObjectPooler] " + base.name);
		this._pooledGameObjects = new List<GameObject>();
		for (int i = 0; i < this.PoolSize; i++)
		{
			this.AddOneObjectToThePool();
		}
	}

	public void DisableAll()
	{
		if (this._pooledGameObjects != null)
		{
			for (int i = 0; i < this._pooledGameObjects.Count; i++)
			{
				if (this._pooledGameObjects[i].gameObject != null && this._pooledGameObjects[i].gameObject.activeInHierarchy)
				{
					this._pooledGameObjects[i].gameObject.SetActive(false);
				}
			}
		}
	}

	public override GameObject GetPooledGameObject()
	{
		for (int i = 0; i < this._pooledGameObjects.Count; i++)
		{
			if (!this._pooledGameObjects[i].gameObject.activeInHierarchy)
			{
				return this._pooledGameObjects[i];
			}
		}
		if (this.PoolCanExpand)
		{
			return this.AddOneObjectToThePool();
		}
		return null;
	}

	protected virtual GameObject AddOneObjectToThePool()
	{
		if (this.GameObjectToPool == null)
		{
			UnityEngine.Debug.LogWarning("The " + base.gameObject.name + " ObjectPooler doesn't have any GameObjectToPool defined.", base.gameObject);
			return null;
		}
		GameObject gameObject = Object.Instantiate(this.GameObjectToPool);
		gameObject.gameObject.SetActive(false);
		gameObject.transform.parent = this._waitingPool.transform;
		gameObject.name = this.GameObjectToPool.name + "-" + this._pooledGameObjects.Count;
		this._pooledGameObjects.Add(gameObject);
		return gameObject;
	}
}


