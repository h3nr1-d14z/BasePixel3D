using System.Collections.Generic;
using UnityEngine;

public class FilterManager : MonoBehaviour
{
	[SerializeField]
	private List<Texture2D> m_filters;

	public Texture2D GetFilter(int filterId)
	{
		List<Texture2D> list = new List<Texture2D>();
		for (int i = 0; i < this.m_filters.Count; i++)
		{
			list.Add(this.m_filters[i]);
		}
		Texture2D item = list[1];
		list.Remove(item);
		list.Add(item);
		return list[filterId];
	}

	public List<FilterInfo> GetFilters()
	{
		List<FilterInfo> list = new List<FilterInfo>();
		for (int i = 0; i < this.m_filters.Count; i++)
		{
			list.Add(new FilterInfo(this.m_filters[i], i));
		}
		FilterInfo item = list[1];
		list.Remove(item);
		list.Add(item);
		return list;
	}
}


