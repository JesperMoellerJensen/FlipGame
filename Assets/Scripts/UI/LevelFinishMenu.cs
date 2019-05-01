using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class LevelFinishMenu : MonoBehaviour
{
	public TextMeshProUGUI LevelTitle;
	public TextMeshProUGUI Coins;
	public TextMeshProUGUI YourTime;
	public TextMeshProUGUI BestTime;
	public TextMeshProUGUI BestTimeAllCoins;

	public void UpdateTexts(LevelData levelData, long yourTime)
	{
		LevelTitle.text = "Level " + levelData.name.ToString().Split('_')[1];
		Coins.text = string.Format("{0:00} / {1:00}", levelData.CoinsCollected, levelData.TotalCoins);
		YourTime.text = CustomExtensions.MillisecondsToTimer(yourTime);
		BestTime.text = CustomExtensions.MillisecondsToTimer(levelData.FastestTime);
		BestTimeAllCoins.text = CustomExtensions.MillisecondsToTimer(levelData.FastestTimeAllCoins);
	}
}
