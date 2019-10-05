using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float moveSpeed;

	void Update () {
		transform.Translate (0, -1 * Time.deltaTime * moveSpeed * PlayerControl.SharedInstance.forwardSpeed, 0);
	}
}
