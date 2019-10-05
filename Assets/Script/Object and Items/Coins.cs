using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

	public Boundary xSpawnRange;
	
	void OnEnable()
	{
		transform.localPosition = new Vector2(Random.Range(xSpawnRange.min, xSpawnRange.max), transform.localPosition.y);
		for(int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(true);
		}
	}

	void Update () {
		if(transform.position.y < -11f)
		{
			gameObject.SetActive(false);
		}
	}
}
