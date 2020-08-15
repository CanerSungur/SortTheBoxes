using System.Collections;
using UnityEngine;

public class ManualPusherLeft : MonoBehaviour
{
	public AudioClip machineAudio;

	public Vector3 pointA;
	public Vector3 pointB;

	private bool didItWork = false;

	private float timer;

	void Update()
	{
		if (pointA != transform.position)
		{
			timer += Time.deltaTime;
			if (timer > 3.0f)
			{
				Debug.Log("MAKİNA KIRILDI!");
				GameManager.PusherIsBroken = true;
				GameManager.GameIsOver = true;
				timer = 0f;
				return;
			}
		}
		else
			timer = 0;

		//###### PC icin #######
		/*
		if (Input.GetKeyDown(KeyCode.A))
		{
			didItWork = true;
			StartCoroutine(BackToStart());
		}
		*/

		//###### TELEFON icin #######
		if (Input.touchCount > 0)
		{
			AudioSource.PlayClipAtPoint(machineAudio, transform.position);
			Handheld.Vibrate();

			var touch = Input.GetTouch(0);
			if (touch.position.x < Screen.width / 2.2)
			{
				didItWork = true;
				StartCoroutine(BackToStart());
				return;
			}
		}
	}

	IEnumerator BackToStart()
	{
		//var pointA = transform.position;
		while (didItWork)
		{
			//yield return new WaitForSeconds(0.5f);
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 0.5f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 0.5f));
			yield return new WaitForSeconds(1.0f);
			didItWork = false;
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i = 0.0f;
		var rate = 1.0f / time;
		while (i < 1.0f)
		{
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
	}
}
