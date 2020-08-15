using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSpawner : MonoBehaviour
{
	/*
		# Bu scriptte oyundaki box listemizi olusturuyoruz.
		# Sag ve sol spawn noktalarindan random box spawn edebiliyoruz.
		# Sag ve sol icin ayrı iki sayacimiz var sifirlaninca kutular spawn oluyor.
	*/

	public static int BoxesInScene;
	public static int BoxesThrown;

	[Header("General Box List")]
	public List<Box> boxList;

	public Transform spawnPoint1;
	public Transform spawnPoint2;
	
	private float leftCountdown;
	private float rightCountdown;
	private float firstCountdown;

	public Text firstCountdownText;
	public GameObject getReadyPanel;

	void Start()
	{
		BoxesInScene = 0;
		BoxesThrown = 0;
		leftCountdown = 3.0f;
		rightCountdown = 3.0f;
		firstCountdown = 3.0f;
	}

	void Update()
	{
        if (firstCountdown <= 0.0f)
        {
			GameManager.GameIsStarted = true;
			getReadyPanel.SetActive(false);
		}
        else if (firstCountdown > 0.0f)
        {
			GameManager.GameIsStarted = false;
			getReadyPanel.SetActive(true);
			firstCountdownText.text = string.Format(("{0:0}"), firstCountdown);

			firstCountdown -= Time.deltaTime;
			Mathf.Clamp(firstCountdown, 0f, Mathf.Infinity);
		}

		if (leftCountdown <= 0.0f)
		{
			SpawnBoxLeft();
			leftCountdown = Random.Range(1.8f, 4.0f);
		}
		else if (leftCountdown > 0.0f)
		{
			leftCountdown -= Time.deltaTime;
			Mathf.Clamp(leftCountdown, 0f, Mathf.Infinity);
		}

		if (rightCountdown <= 0.0f)
		{
			SpawnBoxRight();
			rightCountdown = Random.Range(1.8f, 4.0f);
		}
		else if (rightCountdown > 0.0f)
		{
			rightCountdown -= Time.deltaTime;
			Mathf.Clamp(rightCountdown, 0f, Mathf.Infinity);
		}
	}

	private void SpawnBoxLeft()
	{
		Instantiate(boxList[GetRandomBoxIndex()].boxPrefab, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
	}

	private void SpawnBoxRight()
	{
		Instantiate(boxList[GetRandomBoxIndex()].boxPrefab, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
	}

	public int GetRandomBoxIndex()
	{
		return Random.Range(0, 3);
	}
}
