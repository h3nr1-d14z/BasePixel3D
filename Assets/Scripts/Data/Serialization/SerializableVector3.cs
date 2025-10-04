using System;
using UnityEngine;

[Serializable]
public class SerializableVector3
{
	public float X { get; set; }

	public float Y { get; set; }

	public float Z { get; set; }

	public SerializableVector3(Vector3 vec)
	{
		this.X = vec.x;
		this.Y = vec.y;
		this.Z = vec.z;
	}

	public SerializableVector3(float x, float y, float z)
	{
		this.X = x;
		this.Y = y;
		this.Z = z;
	}

	public Vector3 ToVector3()
	{
		return new Vector3(this.X, this.Y, this.Z);
	}
}


