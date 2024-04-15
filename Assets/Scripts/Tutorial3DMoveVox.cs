using UnityEngine;

public class Tutorial3DMoveVox : MonoBehaviour
{
	private void Start()
	{
		VoxCubeItem[] componentsInChildren = ((Component)base.transform).GetComponentsInChildren<VoxCubeItem>();
		VoxCubeItem[] array = componentsInChildren;
		foreach (VoxCubeItem voxCubeItem in array)
		{
			voxCubeItem.gameObject.AddComponent<Tutorial3DMoveVoxCube>();
		}
		base.transform.localScale = Vector3.one;
		Object.FindObjectOfType<TutorialWindow>().transform.localScale = Vector3.one;
	}
}


