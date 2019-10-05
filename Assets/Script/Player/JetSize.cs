using System.Collections;
using UnityEngine;

public class JetSize : MonoBehaviour {

	private float initialSize;
	private float axisVert;
	private float scale;

	void Start () {
		initialSize = transform.localScale.x;
	}

	void Update () {
		axisVert = PlayerControl.SharedInstance.axisVert;
		if(axisVert < 0)
		{
			scale = Mathf.Lerp(initialSize, initialSize - 0.3f, axisVert * -1f);
			transform.localScale = new Vector2(scale, scale);
		}
		else if(axisVert > 0)
		{
			scale = Mathf.Lerp(initialSize, initialSize + 0.3f, axisVert);
			transform.localScale = new Vector2(scale, scale);
		}
		else
		{
			scale = initialSize;
			transform.localScale = new Vector2(scale, scale);
		}
	}
}
