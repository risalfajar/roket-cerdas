using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRemove : MonoBehaviour {

	void Update () {
		if(transform.localPosition.y < -15)
		{
			gameObject.SetActive(false);
		}
	}
}
