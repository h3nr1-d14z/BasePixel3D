

using System.Collections.Generic;
using UnityEngine;

public class MultipleObjectPooler : ObjectPooler
{
	public GameObject[] GameObjectsToPool;

	public int[] PoolSize;

	public bool PoolCanExpand = true;

	protected GameObject _waitingPool;

	protected List<GameObject> _pooledGameObjects;

	protected override void FillObjectPool()
	{
		this._waitingPool = new GameObject("[MultipleObjectPooler] " + base.name);
		this._pooledGameObjects = new List<GameObject>();
		int num = 0;
		GameObject[] gameObjectsToPool = this.GameObjectsToPool;
		foreach (GameObject typeOfObject in gameObjectsToPool)
		{
			if (num > this.PoolSize.Length)
			{
				break;
			}
			for (int j = 0; j < this.PoolSize[num]; j++)
			{
				this.AddOneObjectToThePool(typeOfObject);
			}
			num++;
		}
	}

	protected virtual GameObject AddOneObjectToThePool(GameObject typeOfObject)
	{
		GameObject gameObject = Object.Instantiate(typeOfObject);
		gameObject.gameObject.SetActive(false);
		gameObject.transform.parent = this._waitingPool.transform;
		gameObject.name = typeOfObject.name + "-" + this._pooledGameObjects.Count;
		this._pooledGameObjects.Add(gameObject);
		return gameObject;
	}

	public override GameObject GetPooledGameObject()
	{
		int index = Random.Range(0, this._pooledGameObjects.Count);
		int num = 0;
		while (this._pooledGameObjects[index].gameObject.activeInHierarchy && num < this._pooledGameObjects.Count)
		{
			index = Random.Range(0, this._pooledGameObjects.Count);
			num++;
		}
		if (this._pooledGameObjects[index].gameObject.activeInHierarchy)
		{
			if (this.PoolCanExpand)
			{
				index = Random.Range(0, this.GameObjectsToPool.Length);
				return this.AddOneObjectToThePool(this.GameObjectsToPool[index]);
			}
			return null;
		}
		return this._pooledGameObjects[index];
	}

	public virtual GameObject GetPooledGameObjectOfType(string type)
	{
		GameObject gameObject = null;
		for (int i = 0; i < this._pooledGameObjects.Count; i++)
		{
			if (this._pooledGameObjects[i].name.Contains(type))
			{
				if (!this._pooledGameObjects[i].gameObject.activeInHierarchy)
				{
					return this._pooledGameObjects[i];
				}
				gameObject = this._pooledGameObjects[i];
			}
		}
		if (this.PoolCanExpand && gameObject != null)
		{
			GameObject gameObject2 = Object.Instantiate(gameObject);
			this._pooledGameObjects.Add(gameObject2);
			return gameObject2;
		}
		return null;
	}
}


