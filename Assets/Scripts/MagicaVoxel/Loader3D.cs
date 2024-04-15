using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoxDLL
{
	public class Loader3D : MonoBehaviour
	{
		public static int CurrentIndex;

		private MVMainChunk v;

		private float sizePerVox = 1f;

		private Action<Color[]> ColorsPalleteLoadComplete;

		private Action<List<VoxCubeItem>> CubesDataLoadComplete;

		private bool isInit;

		public MVMainChunk MV
		{
			get { return v; }
		}

		static Loader3D()
		{
		}

		public Loader3D()
		{
		}

		public void Init(Action<Color[]> actionColorsComplete, Action<List<VoxCubeItem>> actionCubesComplete)
		{
			this.ColorsPalleteLoadComplete = actionColorsComplete;
			this.CubesDataLoadComplete = actionCubesComplete;
			MVImporter.Init(actionColorsComplete, actionCubesComplete);
			this.isInit = true;
		}

		public void Load(byte[] data)
		{
			if (!this.isInit)
			{
				Debug.LogError("[Loader3D] Module isn't initilized. Try call method Init() before");
				return;
			}
			if (data == null)
			{
				Debug.LogError("[Loader3D] Invalid file data");
				return;
			}
			this.v = MVImporter.LoadVOXFromData(data, false);
			ColorSettings colorSetting = new ColorSettings(this.v.palatte);
			if (this.v.palatte == null)
			{
				Debug.LogError("[Loader3D] Invalid file pallete");
				return;
			}
			MVImporter.AddColorSettings(colorSetting);
			Material defaultMaterial = MVImporter.DefaultMaterial;
			defaultMaterial.mainTexture = this.v.PaletteToTexture();
			GameObject gameObject = GameObject.Find("3DVox");
			if (gameObject == null)
			{
				Debug.LogError("[Loader3D] Game object 3DVox not found. Create in scene this object!");
				return;
			}
			MVImporter.CreateIndividualVoxelGameObjects(this.v, gameObject.transform, defaultMaterial, this.sizePerVox);
		}
	}
}