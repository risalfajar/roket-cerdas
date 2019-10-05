using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

	public static float score;
	public static int coin;
	[Range(1, 4)]
	public float scoreRate;

	void Start()
	{
		score = 0;
		coin = 0;
	}

	void Update () {
		score += scoreRate * PlayerControl.SharedInstance.forwardSpeed * Time.deltaTime;
	}
}
