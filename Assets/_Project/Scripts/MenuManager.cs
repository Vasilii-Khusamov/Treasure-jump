using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	void Start()
	{
		
	}

	public void Play()
	{
		SceneManager.LoadScene("Level_1");
	}
    public void Options()
	{
		
    }
    public void Quit()
	{
		Application.Quit();
    }
}
