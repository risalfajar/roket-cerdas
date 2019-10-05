using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameUI : MonoBehaviour
{
	[Header("Main Screen")]
	public Text coinText;
	public Text scoreText;
	public GameObject pauseScreen;
	[Header("Dead Screen")]
	public GameObject deadScreen;
	public Text deadScreenCoinText;
	public Text deadScreenScoreText;

	public static MainGameUI SharedInstance;
	private float curSpeed;

	void Awake()
	{
		SharedInstance = this;
	}

	void Start()
	{
		pauseScreen.SetActive(false);
		deadScreen.SetActive(false);
	}

	void Update()
	{
		scoreText.text = Mathf.Floor(PlayerScore.score).ToString();
		coinText.text = PlayerScore.coin.ToString();
	}

	public void Pause()
	{
		curSpeed = PlayerControl.SharedInstance.forwardSpeed;
		PlayerControl.SharedInstance.forwardSpeed = 0;
		pauseScreen.SetActive(true);
	}

	public void Resume()
	{
		PlayerControl.SharedInstance.forwardSpeed = curSpeed;
		pauseScreen.SetActive(false);
	}

	public void Dead()
	{
		deadScreen.SetActive(true);
		deadScreenCoinText.text = coinText.text;
		deadScreenScoreText.text = scoreText.text;
	}

	public void Exit()
	{
		SceneManager.LoadScene("Main Menu");
	}
}
