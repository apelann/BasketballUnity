using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
	public float remainingTime;
	public TextMeshProUGUI timerText;

	private void Update()
	{
		remainingTime -= Time.deltaTime;

		int seconds = ((int)remainingTime % 60);
		int minutes = ((int)remainingTime / 60);
		timerText.text = (minutes.ToString()) + ":" + (seconds.ToString().Length < 2 ? "0" + seconds : seconds);
	}
}
