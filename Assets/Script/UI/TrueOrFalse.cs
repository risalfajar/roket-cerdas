using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrueOrFalse : MonoBehaviour {

	public Text questionText;
	public AudioSource wrongSound;
	int a, b, c;


	void OnEnable () {
		a = Random.Range(1, 10);
		b = Random.Range(1, 15);
		if (Random.value < 0.5f)
			c = a + b;
		else
			c = Random.Range(10, 20);

		questionText.text = a + " + " + b + " = " + c ;
	}
	
	public void True()
	{
		if(a+b == c)
		{
			Correct();
		}else
		{
			wrongSound.Play();
			Invoke("Incorrect", wrongSound.clip.length);
		}
	}

	public void False()
	{
		if(a+b != c)
		{
			Correct();
		}else
		{
			wrongSound.Play();
			Invoke("Incorrect", wrongSound.clip.length);
		}
	}

	void Correct()
	{
		PlayerInteraction.SharedInstance.Boost();
		gameObject.SetActive(false);
	}

	void Incorrect()
	{
		PlayerInteraction.SharedInstance.StopBoost();
		gameObject.SetActive(false);
	}
}
