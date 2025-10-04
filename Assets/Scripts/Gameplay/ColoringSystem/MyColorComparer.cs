using System.Collections.Generic;
using UnityEngine;

public class MyColorComparer : IEqualityComparer<Color>
{
	public bool Equals(Color x, Color y)
	{
		if (x.r != y.r)
		{
			return false;
		}
		if (x.g != y.g)
		{
			return false;
		}
		if (x.b != y.b)
		{
			return false;
		}
		return true;
	}

	public int GetHashCode(Color obj)
	{
		return base.GetHashCode();
	}
}


