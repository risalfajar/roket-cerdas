using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    public static StarController SharedInstance;
    public Vector2 spawnPos;
    public List<GameObject> firstStars;

    void Awake()
    {
        SharedInstance = this;
    }

	public void CreateStar (string tag) {
        GameObject star = PoolManager.SharedInstance.GetPooledObject(tag); 
        if (star != null) {
			star.transform.SetParent(this.transform);
			star.transform.localPosition = spawnPos;
			if (Random.value < 0.5f)
				star.transform.localScale = new Vector2(-1, 1);
            star.SetActive(true);
        }
	}

	public void RemoveStar(GameObject star, string option)
    {
		if(option == "Destroy")
		{
			Destroy(star);
		}
		else if(option == "Pool")
		{
			star.SetActive(false);
		}
    }
}
