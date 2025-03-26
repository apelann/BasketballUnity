using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public int currentScore;
	public TextMeshProUGUI scoreText;

	public float secondsSaved;
	public Timer timer;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Basketball"))
		{
			currentScore++;
			scoreText.text = currentScore.ToString();
			timer.remainingTime += secondsSaved;
		}
	}
}
