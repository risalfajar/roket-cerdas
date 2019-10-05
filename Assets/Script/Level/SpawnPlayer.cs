using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

	public List<GameObject> players;
	public Vector2 spawnPos;

	void Awake()
	{
		int index = PlayerPrefs.GetInt("Selected Player", 0);
		players[index].SetActive(true);

		for(int i = 0; i < players.Capacity; i++)
		{
			if(i != index)
			{
				Destroy(players[i]);
			}
		}
	}
}
