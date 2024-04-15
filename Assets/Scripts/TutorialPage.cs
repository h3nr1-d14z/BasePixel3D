using UnityEngine;

public class TutorialPage : MonoBehaviour
{
	[SerializeField]
	private GameObject m_content;

	[SerializeField]
	private GameObject m_closeButton;

	public void Play()
	{
	}

	public void Stop()
	{
	}

	public void EnableCloseButton()
	{
		this.m_closeButton.SetActive(true);
	}
}


