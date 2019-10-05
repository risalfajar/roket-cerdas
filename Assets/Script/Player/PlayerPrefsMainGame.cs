using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsMainGame : MonoBehaviour {

	#if UNITY_EDITOR_64
	void Start()
	{
		PlayerPrefs.SetInt("Coins", 0);
	}
	#endif

	public void SaveScore () {
		int score = Mathf.FloorToInt(PlayerScore.score);
		for(int i = 1; i <= 5; i++)
		{
			if (score > PlayerPrefs.GetInt("High Score " + i, 0))
			{
				for(int j = 5; j >= i+1; j--)
				{
					PlayerPrefs.SetInt("High Score " + j, PlayerPrefs.GetInt("High Score " + (j-1)));
				}
				PlayerPrefs.SetInt("High Score " + i, score);
				break;
			}
		}
		PlayerPrefs.Save();
	}

	public void SaveCoin()
	{
		int coin = PlayerScore.coin + PlayerPrefs.GetInt("Coins", 0);
		#if UNITY_EDITOR_64
		coin *= 100;
		#endif
		PlayerPrefs.SetInt("Coins", coin);
		PlayerPrefs.Save();
	}
}
