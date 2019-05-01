using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
	public RectTransform LevelsParent;
	[Space]
	public LevelData[] Levels;
	[Space]
	public int TotalCoinsInGame;
	public int TotalCollectedCoins;

	private void Start()
	{
		SetTotalCoins();
		CreateLevelIcons();
	}

	public void ChangeLevel(string levelId)
	{
		SceneManager.LoadScene("Level" + levelId);
	}

	private void SetTotalCoins()
	{
		TotalCollectedCoins = 0;
		foreach (var level in Levels)
		{
			TotalCoinsInGame += level.TotalCoins;
			TotalCollectedCoins += level.CoinsCollected;
		}

		GetComponentsInChildren<TextMeshProUGUI>()[0].text = string.Format("{0} / {1}", TotalCollectedCoins, TotalCoinsInGame);
	}

	private void CreateLevelIcons()
	{
		for (int i = 0; i < Levels.Length; i++)
		{
			GameObject prefab = Resources.Load<GameObject>("Prefabs/UI_Level");
			GameObject levelIcon = Instantiate(prefab) as GameObject;
			levelIcon.transform.SetParent(LevelsParent, false);

			RectTransform levelTransform = levelIcon.GetComponent<RectTransform>();
			levelTransform.localPosition = new Vector3(0, 0, 0);
			levelTransform.localScale = new Vector3(1, 1, 1);

			TextMeshProUGUI Title = levelIcon.GetComponentsInChildren<TextMeshProUGUI>()[0];
			TextMeshProUGUI Coins = levelIcon.GetComponentsInChildren<TextMeshProUGUI>()[1];
			TextMeshProUGUI RequiredCoins = levelIcon.GetComponentsInChildren<TextMeshProUGUI>()[2];
			Button icon = levelIcon.GetComponentInChildren<Button>();


			Title.text = Levels[i].name.ToString().Split('_')[1];
			Coins.text = string.Format("{0} / {1}", Levels[i].CoinsCollected, Levels[i].TotalCoins);
			RequiredCoins.text = Levels[i].RequiredCoins.ToString();


			if (TotalCollectedCoins >= Levels[i].RequiredCoins)
			{
				RequiredCoins.enabled = false;
				Coins.enabled = true;
				icon.interactable = true;
				icon.onClick.AddListener(() => ChangeLevel(Title.text));
			}
			else
			{
				RequiredCoins.enabled = true;
				Coins.enabled = false;
				icon.interactable = false;
			}
		}
	}
}
