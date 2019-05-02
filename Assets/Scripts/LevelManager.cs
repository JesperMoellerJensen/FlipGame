using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public LevelData LevelData;
	public int CurrentCoins = 0;
	public long TimeElapsed;




	private TextMeshProUGUI _timerText;
	private TextMeshProUGUI _coinCounterText;
	private Stopwatch _stopwatch;

	private void Start()
	{
		_timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
		_coinCounterText = GameObject.FindGameObjectWithTag("Counter").GetComponent<TextMeshProUGUI>();
		_coinCounterText.text = string.Format("{0:00}/{1:00}", CurrentCoins, LevelData.TotalCoins);
	}
	public void InitializeLevel()
	{
		Time.timeScale = 1;
		_stopwatch = new Stopwatch();
		Invoke("StartLevel", 0.5f);
	}

	public void StartLevel()
	{
		FindObjectOfType<PlayerMovement>().CanMove = true;
		_stopwatch.Start();
		InvokeRepeating("UpdateTime", 0, 0.01f);
	}

	public void PauseGame()
	{
		_stopwatch.Stop();
		Time.timeScale = 0;
	}

	public void UnPauseGame()
	{
		_stopwatch.Start();
		Time.timeScale = 1;
	}
	public void PickedUpCoin()
	{
		CurrentCoins++;
		_coinCounterText.text = string.Format("{0:00}/{1:00}", CurrentCoins, LevelData.TotalCoins);
	}

	public void FinishedLevel()
	{
		_stopwatch.Stop();
		CancelInvoke("UpdateTime");

		LevelData.Completed = true;
		LevelData.CoinsCollected = Mathf.Max(CurrentCoins, LevelData.CoinsCollected);

		if (_stopwatch.ElapsedMilliseconds < LevelData.FastestTime || LevelData.FastestTime == 0)
		{
			LevelData.FastestTime = _stopwatch.ElapsedMilliseconds;
		}
		if (CurrentCoins == LevelData.TotalCoins && _stopwatch.ElapsedMilliseconds < LevelData.FastestTimeAllCoins || LevelData.FastestTimeAllCoins == 0)
		{
			LevelData.FastestTimeAllCoins = _stopwatch.ElapsedMilliseconds;
		}

		FindObjectOfType<LevelMenus>().ShowLeveFinishMenu(LevelData, _stopwatch.ElapsedMilliseconds);
	}

	public void UpdateTime()
	{
		TimeElapsed = _stopwatch.ElapsedMilliseconds;
		_timerText.text = CustomExtensions.MillisecondsToTimer(TimeElapsed);
	}
}
