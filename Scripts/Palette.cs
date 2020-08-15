using UnityEngine;
using UnityEngine.UI;

public class Palette : MonoBehaviour
{
	/*
		# Burada palete dizmemiz gereken kutu gorevlerini, kac gorev tamamlandigini belirliyoruz.
		# Gorev generate ediliyor. 3 gorev tamamlaninca o palet tamamlanmis oluyor.
		# Gerekli kutular eklendikce score artiyor. Fazla kutu eklendikce puan gidiyor.
	*/

	public AudioClip correctAudio;
	public AudioClip wrongAudio;

	public BoxSpawner boxSpawner;

	private bool taskIsDone;
	private bool paletteIsDone;
	private int taskCount;

	public int littleTaskNo;
	public int wideTaskNo;
	public int tallTaskNo;

	public Text littleTaskText;
	public Text tallTaskText;
	public Text wideTaskText;

	public Image littleBoxImage;
	public Image tallBoxImage;
	public Image wideBoxImage;

	void Start()
	{
		littleBoxImage.GetComponent<Image>().sprite = boxSpawner.boxList[0].boxSprite;
		tallBoxImage.GetComponent<Image>().sprite = boxSpawner.boxList[1].boxSprite;
		wideBoxImage.GetComponent<Image>().sprite = boxSpawner.boxList[2].boxSprite;

		paletteIsDone = false;
		taskIsDone = false;
		taskCount = 0;
		GeneratePaletteTask();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.rigidbody.GetComponent<Box>().boxName == "Little Box")
		{
			littleTaskNo--;
			if (littleTaskNo >= 0)
			{
				AudioSource.PlayClipAtPoint(correctAudio, transform.position);
				GameManager.Score += 5;
			}
			else if (littleTaskNo < 0)
			{
				AudioSource.PlayClipAtPoint(wrongAudio, transform.position);
				GameManager.Score -= 5;
			}
		}
		else if (other.rigidbody.GetComponent<Box>().boxName == "Tall Box")
		{
			tallTaskNo--;
			if (tallTaskNo >= 0)
			{
				AudioSource.PlayClipAtPoint(correctAudio, transform.position);
				GameManager.Score += 6;
			}
			else if (tallTaskNo < 0)
			{
				AudioSource.PlayClipAtPoint(wrongAudio, transform.position);
				GameManager.Score -= 6;
			}
		}
		else if (other.rigidbody.GetComponent<Box>().boxName == "Wide Box")
		{
			wideTaskNo--;
			if (wideTaskNo >= 0)
			{
				AudioSource.PlayClipAtPoint(correctAudio, transform.position);
				GameManager.Score += 7;
			}
			else if (wideTaskNo < 0)
			{
				AudioSource.PlayClipAtPoint(wrongAudio, transform.position);
				GameManager.Score -= 7;
			}
		}

		Destroy(other.rigidbody.GetComponent<Box>().boxPrefab, 1.0f);
	}

	void Update()
	{
		if (taskIsDone)
		{
			Debug.Log("GÖREV BAŞARILI");
			taskCount++;
			if (taskCount < 2)
			{
				GeneratePaletteTask();
			}
			else if (taskCount >= 2)
			{
				paletteIsDone = true;
			}
		}
		else if (!taskIsDone)
		{
			CheckIfPaletteIsDone();
		}

		if (littleTaskNo >= 0)
		{
			littleTaskText.text = littleTaskNo.ToString();
		}
		else if (littleTaskNo < 0)
		{
			littleTaskText.text = "0";
		}

		if (tallTaskNo >= 0)
		{
			tallTaskText.text = tallTaskNo.ToString();
		}
		else if (tallTaskNo < 0)
		{
			tallTaskText.text = "0";
		}

		if (wideTaskNo >= 0)
		{
			wideTaskText.text = wideTaskNo.ToString();
		}
		else if (wideTaskNo < 0)
		{
			wideTaskText.text = "0";
		}
	}

	private void CheckIfPaletteIsDone()
	{
		if (littleTaskNo <= 0 && tallTaskNo <= 0 && wideTaskNo <= 0)
		{
			taskIsDone = true;
		}
		else
		{
			taskIsDone = false;
		}
	}

	private void GeneratePaletteTask()
	{
		littleTaskNo = Random.Range(1, 4);
		tallTaskNo = Random.Range(1, 4);
		wideTaskNo = Random.Range(1, 4);
		taskIsDone = false;
	}

	public bool SendPaletteTaskInfo()
	{
		if (paletteIsDone)
			return true;
		else
			return false;
	}
}
