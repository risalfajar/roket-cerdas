using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	public GameObject trueOrFalseScreen;
	public AudioSource deadSound;
	public AudioSource coinSound;
	[Header("Boost Power-Up Settings")]
	public float boostDuration = 4;
	[Range(6, 20)]
	public float boostPower = 6;
	public GameObject coinGenerator;
	public AudioSource boostSound;
	public static bool boosted = false;
	public static float curSpeed;
	public static PlayerInteraction SharedInstance;
	private ObjectGenerator coinScript;

	void Awake()
	{
		SharedInstance = this;
		coinScript = coinGenerator.GetComponent<ObjectGenerator>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Enemy") && !boosted)
		{
			Dead();
		}
		if(other.gameObject.CompareTag("Coin"))
		{
			other.gameObject.SetActive(false);
			Coin();
		}
		if(other.gameObject.CompareTag("Boost"))
		{
			curSpeed = PlayerControl.SharedInstance.forwardSpeed;
			PlayerControl.SharedInstance.forwardSpeed = 0;
			trueOrFalseScreen.SetActive(true);
			other.gameObject.SetActive(false);
		}
	}

	void Dead()
	{
		deadSound.Play();
		PlayerControl.SharedInstance.forwardSpeed = 0;
		MainGameUI.SharedInstance.Dead();
	}

	void Coin()
	{
		coinSound.Play();
		PlayerScore.coin++;
	}

	public void Boost()
	{
		if (!boosted)
		{
			boostSound.Play();
			boosted = true;
			PlayerControl.SharedInstance.forwardSpeed = curSpeed * boostPower;
			coinScript.Generate();
			Invoke("StopBoost", boostDuration);
		}
	}

	public void StopBoost()
	{
		boosted = false;
		PlayerControl.SharedInstance.forwardSpeed = curSpeed;
	}
}
