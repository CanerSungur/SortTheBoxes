using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	/*
		# Genel Skoru tutuyor.
		# Oyun sayaci, paletlerin gorevlerinin tamamlanip tamamlanmadigini tutuyor.
		# Game Over, Win Level durumlarini belirleyip aktif eder.
	*/
	public static int Score;

	public static bool GameIsOver;
	public static bool PusherIsBroken;

	public static float Countdown;
	public static bool GameIsStarted;

	public GameObject gameOverUI;
	public GameObject winLevelUI;

	public Palette leftPalette;
	public Palette rightPalette;

	public GameObject gameOverMessageBroken;
	public GameObject gameOverMessageTime;

    void Awake()
    {
		GameIsStarted = false;
		GameIsOver = false;
		PusherIsBroken = false;
		Countdown = 180.0f;
		Score = 0;
    }

    void Update()
    {
		if (GameIsOver)
		{
			GameOver();
		}
		else if (!GameIsOver && GameIsStarted)
		{
			Countdown -= Time.deltaTime;
			Countdown = Mathf.Clamp(Countdown, 0f, Mathf.Infinity);
			if (Countdown <= 0)
			{
				GameOver();
			}
			else if (Countdown > 0)
			{
				if (leftPalette.SendPaletteTaskInfo() && rightPalette.SendPaletteTaskInfo())
				{
					//Oyunu kazandin.
					WinLevel();
				}
			}	
		}
    }

	void GameOver()
	{
        if (PusherIsBroken)
        {
			gameOverMessageBroken.SetActive(true);
			gameOverMessageTime.SetActive(false);
        }
        else
        {
			gameOverMessageBroken.SetActive(false);
			gameOverMessageTime.SetActive(true);
		}

		Debug.Log("GAME OVER!");
		gameOverUI.SetActive(true);
		Time.timeScale = 0;
	}

	void WinLevel()
	{
		Debug.Log("WIN LEVEL!");
		winLevelUI.SetActive(true);
		Time.timeScale = 0;
	}
}
