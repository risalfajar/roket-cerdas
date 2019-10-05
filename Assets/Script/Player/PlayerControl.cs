using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary2
{
	public float minX, maxX, minY, maxY;
}

[System.Serializable]
public class Boundary
{
	public float min, max;
}

public class PlayerControl : MonoBehaviour
{

	public static PlayerControl SharedInstance;
	public Boundary2 bound;
	public float forwardSpeed;
	public float moveSpeed;
	[HideInInspector]
	public float axisVert;

	void Awake()
	{
		SharedInstance = this;
	}

	void Update()
	{
		if (forwardSpeed != 0)
		{
			#if UNITY_ANDROID
				AndroidControl();
			#endif

			#if UNITY_EDITOR_64
				WindowsControl();
			#endif

			transform.position = new Vector2(
				Mathf.Clamp(transform.position.x, bound.minX, bound.maxX),
				Mathf.Clamp(transform.position.y, bound.minY, bound.maxY)
			);
		}
	}

	void AndroidControl()
	{
		if(Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Vector2 translate = Input.GetTouch(0).deltaPosition.normalized;
				axisVert = translate.y;

				translate *= Time.deltaTime * moveSpeed * 1.4f;
				transform.Translate(translate);
			}
		}
		else
		{
			axisVert = 0;
		}
	}

	void WindowsControl()
	{
		axisVert = Input.GetAxis("Vertical");
		float translateX = Input.GetAxis("Horizontal") * moveSpeed;
		float translateY = axisVert * moveSpeed;

		translateX *= Time.deltaTime;
		translateY *= Time.deltaTime;
		transform.Translate(translateX, translateY, 0);
	}
}
