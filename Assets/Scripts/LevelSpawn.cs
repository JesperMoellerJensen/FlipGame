using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelSpawn : MonoBehaviour
{
	private void Start()
	{
		SpawnPlayer();
	}

	private void SpawnPlayer()
	{
		var prefab = Resources.Load<GameObject>("Prefabs/Player");
		GameObject player = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
		FindObjectOfType<CinemachineVirtualCamera>().Follow = player.transform;

		FindObjectOfType<LevelManager>().InitializeLevel();
	}
}
