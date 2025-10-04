using System;
using UnityEngine;

[Serializable]
public class SerializableQuaternion
{
	public float X { get; set; }

	public float Y { get; set; }

	public float Z { get; set; }

	public float W { get; set; }

	public SerializableQuaternion(Quaternion vec)
	{
		this.X = vec.x;
		this.Y = vec.y;
		this.Z = vec.z;
		this.W = vec.w;
	}

	public SerializableQuaternion(float x, float y, float z, float w)
	{
		this.X = x;
		this.Y = y;
		this.Z = z;
		this.W = w;
	}

	public Quaternion ToQuaternion()
	{
		return new Quaternion(this.X, this.Y, this.Z, this.W);
	}
}


