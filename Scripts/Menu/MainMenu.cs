using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
	{
		//Sonraki scene i cagirdik
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		Time.timeScale = 1;
	}

	public void Quit()
	{
		Application.Quit();
	}
}
