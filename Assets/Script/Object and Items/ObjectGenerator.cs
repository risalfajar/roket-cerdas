using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Range
{
	public float min, max;
}

public class ObjectGenerator : MonoBehaviour {

	public string objectTag;
	public bool shuffleSpawnOrder = false;
	[Header("Player Boosted Condition")]
	public bool disableWhenBoosted = false;
	public bool accelerateWhenBoosted = false;

	public Range xSpawnRange;
	public Range delayRange;
	public Range sizeRange;
	private float tempDelay;

	void Start()
	{
		tempDelay = Random.Range(delayRange.min, delayRange.max);
	}

	void Update ()
	{
		if (PlayerControl.SharedInstance.forwardSpeed != 0 && !(disableWhenBoosted && PlayerInteraction.boosted))
		{
			tempDelay -= Time.deltaTime;
		}
		if(tempDelay <= 0)
		{
			Generate();
		}
	}

	public void Generate()
	{
		GameObject generatedObject = PoolManager.SharedInstance.GetPooledObject(objectTag, shuffleSpawnOrder);
		if(generatedObject != null)
		{
			float randomSize = Random.Range(sizeRange.min, sizeRange.max);
			float posY = transform.position.y;
			float posX = Random.Range(xSpawnRange.min, xSpawnRange.max);
			generatedObject.transform.parent = this.transform;
			generatedObject.transform.localPosition = new Vector2(posX, posY);
			generatedObject.transform.localScale = new Vector2(randomSize, randomSize);
			generatedObject.SetActive(true);
		}

		if (accelerateWhenBoosted && PlayerInteraction.boosted)
			tempDelay = 1/(PlayerInteraction.curSpeed*1.5f);
		else
			tempDelay = Random.Range(delayRange.min, delayRange.max);
	}
}
