using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject highScoreScreen;
	public Text highScoreText;
	private int[] highScores = new int[5];

	void Start()
	{
		for(int i = 1; i <= highScores.Length; i++)
		{
			highScores[i-1] = PlayerPrefs.GetInt("High Score " + i, 0);
		}
		highScoreText.text = "1. " + highScores[0] + "\n" +
			"2. " + highScores[1] + "\n" +
			"3. " + highScores[2] + "\n" +
			"4. " + highScores[3] + "\n" +
			"5. " + highScores[4];
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}

	public void Skor()
	{
		highScoreScreen.SetActive(true);
	}

	public void SkorClose()
	{
		highScoreScreen.SetActive(false);
	}

	public void Shop()
	{
		SceneManager.LoadScene("Shop", LoadSceneMode.Single);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
