using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenus : MonoBehaviour
{

	public GameObject PauseMenu;
	public GameObject LevelFinishMenu;

	private void Update()
	{
		if (Input.GetButtonDown("PauseMenu") && LevelFinishMenu.activeSelf == false)
		{
			PauseMenu.SetActive(!PauseMenu.activeSelf);
			LevelManager levelManager = FindObjectOfType<LevelManager>();
			if (PauseMenu.activeSelf)
			{
				levelManager.PauseGame();
			}
			else
			{
				levelManager.UnPauseGame();
			}
		}
	}

	public void ShowLeveFinishMenu(LevelData levelData, long yourTime)
	{
		foreach (Transform child in transform.root)
		{
			child.gameObject.SetActive(false);
		}
		LevelFinishMenu.SetActive(true);

		LevelFinishMenu.GetComponent<LevelFinishMenu>().UpdateTexts(levelData, yourTime);
		Time.timeScale = 0;
	}
	public void RestartLevel()
	{
		Time.timeScale = 1;
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	public void ReturnToMainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

	public void NextLevel()
	{
		Time.timeScale = 1;
		int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
		SceneManager.LoadScene(sceneIndex);
	}
	public void ExitGame()
	{
		Application.Quit();
	}
}
