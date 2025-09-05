using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	[SerializeField] private GameObject optionsMenu;
	[SerializeField] private Button playButton;
	void Start()
	{
		optionsMenu?.SetActive(false);
		playButton?.onClick.AddListener(Play);
	}

	public void Play()
	{
		SceneManager.LoadScene("TestingScene");
	}
	public void Options()
	{
		optionsMenu.SetActive(true);
	}
	public void Apply()
	{
		optionsMenu.SetActive(false);
	}
	public void Quit()
	{
		Application.Quit();
	}
}
