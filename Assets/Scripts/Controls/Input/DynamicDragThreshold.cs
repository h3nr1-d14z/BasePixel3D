using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventSystem))]
internal class DynamicDragThreshold : MonoBehaviour
{
	private void Awake()
	{
		float density = ScreenToolWrapper.Density;
		EventSystem component = base.GetComponent<EventSystem>();
		component.pixelDragThreshold = (int)((float)component.pixelDragThreshold * density);
	}
}


