using UnityEngine;

public class MessagePanel : MonoBehaviour
{

	public Popup messagePanel;

	private static MessagePanel instance;
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		instance = this;
	}

	public static void ShowMessage(string text, int time = 4)
	{
		instance.messagePanel.Show(text, time);
	}
}
