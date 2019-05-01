using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	Animator _UIAnimator;

	private void Start()
	{
		_UIAnimator = FindObjectOfType<Animator>();
	}

	public void GoToLevelSelect()
	{
		_UIAnimator.SetTrigger("LevelSelect");
	}

	public void GoToMainMenu()
	{
		_UIAnimator.SetTrigger("MainMenu");
	}

	public void GoToSettings()
	{

	}
}
