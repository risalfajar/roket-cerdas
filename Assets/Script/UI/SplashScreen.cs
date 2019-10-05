using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	void Start()
	{
		StartCoroutine(PlayVideo());
	}

	private IEnumerator PlayVideo()
	{
		yield return new WaitForSeconds(2.5f);
		SceneManager.LoadScene("Main Menu");
	}
}
