using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
	public Text timerText;

    void Update()
    {
		timerText.text = string.Format(("{0:00.0}"), GameManager.Countdown);
	}
}
