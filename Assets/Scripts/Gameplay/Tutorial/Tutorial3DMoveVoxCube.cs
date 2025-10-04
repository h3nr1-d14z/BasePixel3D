using System.Collections.Generic;
using UnityEngine;

public class Tutorial3DMoveVoxCube : MonoBehaviour
{
	private static List<Color32> colorsList = new List<Color32> {
		new Color32(240, 116, 28, 1),
		new Color32(236, 144, 24, 1),
		new Color32(240, 240, 240, 1),
		new Color32(187, 187, 187, 1),
		new Color32(34, 34, 34, 1),
		new Color32(220, 77, 110, 1)
	};

	private static Dictionary<int, Material> s_materials = new Dictionary<int, Material>();

	private void Start()
	{
		MeshRenderer componentInChildren = base.GetComponentInChildren<MeshRenderer>();
		int colorIndex = base.GetComponent<VoxCubeItem>().ColorIndex;
		if (!Tutorial3DMoveVoxCube.s_materials.ContainsKey(colorIndex))
		{
			Color32 c = Tutorial3DMoveVoxCube.colorsList[colorIndex - 1];
			Color color = c;
			Color value = new Color(color.grayscale + 0.2f, color.grayscale + 0.2f, color.grayscale + 0.2f);
			Shader shader = Shader.Find("Custom/StandardVertex");
			Material material = new Material(shader);
			material.SetColor("_Color", value);
			Tutorial3DMoveVoxCube.s_materials.Add(colorIndex, material);
		}
		componentInChildren.sharedMaterial = Tutorial3DMoveVoxCube.s_materials[colorIndex];
	}
}


