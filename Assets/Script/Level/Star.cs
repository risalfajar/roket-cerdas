using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	public string offScreenOption;
	private string tagCall;
	private int trigger;

	void OnEnable()
	{
		trigger = 0;
	}

	void Start()
	{
		tagCall = this.gameObject.tag;
	}

	void Update ()
	{
		if(this.transform.localPosition.y < -15)
		{
			StarController.SharedInstance.RemoveStar(this.gameObject, offScreenOption);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "World Boundary" && trigger == 0)
		{
			StarController.SharedInstance.CreateStar(tagCall);
			trigger = 1;
		}
	}
}
