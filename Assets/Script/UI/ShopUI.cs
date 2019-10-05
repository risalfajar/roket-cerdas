using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopUI : MonoBehaviour {

	[System.Serializable]
	public class Rockets
	{
		public GameObject lockIcon = null;
		public GameObject checkIcon;
		public GameObject harga = null;
		public int price;
	}

	public List<Rockets> rockets;
	public Text coinText;
	private int coins;

	void Start () {
		coins = PlayerPrefs.GetInt("Coins", 0);
		coinText.text = coins.ToString();

		for(int i = 1; i < rockets.Capacity; i++)
		{
			if(PlayerPrefs.GetInt("Player " + i + " Unlocked", 0) == 1)
			{
				rockets[i].lockIcon.SetActive(false);
				rockets[i].harga.SetActive(false);
			}
			else
			{
				rockets[i].lockIcon.SetActive(true);
				rockets[i].harga.GetComponentInChildren<Text>().text = rockets[i].price.ToString();
			}
		}

		int selectedPlayer = PlayerPrefs.GetInt("Selected Player", 0);
		rockets[selectedPlayer].checkIcon.SetActive(true);
	}

	public void ShopItems(int index)
	{
		if (index > 0)
		{
			if (PlayerPrefs.GetInt("Player " + index + " Unlocked", 0) == 1)
			{
				SelectPlayer(index);
			}
			else
			{
				if(coins > rockets[index].price)
				{
					BuyItems(index);
				}
			}
		}
		else if(index == 0)
		{
			SelectPlayer(index);
		}
	}

	public void Exit()
	{
		PlayerPrefs.Save();
		SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
	}

	void SelectPlayer(int index)
	{
		PlayerPrefs.SetInt("Selected Player", index);
		foreach(Rockets rocket in rockets)
		{
			rocket.checkIcon.SetActive(false);
		}
		rockets[index].checkIcon.SetActive(true);
	}

	void BuyItems(int index)
	{
		coins -= rockets[index].price;
		coinText.text = coins.ToString();

		PlayerPrefs.SetInt("Player " + index + " Unlocked", 1);
		rockets[index].lockIcon.SetActive(false);
		rockets[index].harga.SetActive(false);
	}
}
