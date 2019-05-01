using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 1)]
public class LevelData : ScriptableObject
{
	[Header("Level Select")]
	public int RequiredCoins;
	public bool Completed;
	[Header("Attributes")]
	public int TotalCoins;
	public int CoinsCollected;
	public long FastestTime;
	public long FastestTimeAllCoins;
}
