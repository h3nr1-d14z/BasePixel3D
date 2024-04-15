using System;

[Serializable]
public class MVVoxelChunk
{
	public byte[,,] voxels;

	public MVFaceCollection[] faces;

	public int x;

	public int y;

	public int z;

	public int sizeX
	{
		get
		{
			return this.voxels.GetLength(0);
		}
	}

	public int sizeY
	{
		get
		{
			return this.voxels.GetLength(1);
		}
	}

	public int sizeZ
	{
		get
		{
			return this.voxels.GetLength(2);
		}
	}

	public MVVoxelChunk()
	{
	}
}