using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
	public Text scoreText;
   
    void Update()
    {
		scoreText.text = GameManager.Score.ToString();
    }
}
