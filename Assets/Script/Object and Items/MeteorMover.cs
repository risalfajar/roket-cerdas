using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Rangez
{
	public float min;
	public float max;
}

public class MeteorMover : MonoBehaviour {

	public Rangez speedRange;
	private float speed;

	void OnEnable()
	{
		speed = Random.Range(speedRange.min, speedRange.max);
	}

	void Update () {
		transform.Translate(Vector3.down * Time.deltaTime * speed * PlayerControl.SharedInstance.forwardSpeed);
		if (transform.localPosition.y < -13f)
		{
			gameObject.SetActive(false);
		}
	}
}
