using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerBehaivor : MonoBehaviour
{
	public void EnterPortal()
	{
		StartCoroutine(CameraShake());
	}
	IEnumerator CameraShake()
	{
		FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>()
			.m_AmplitudeGain = 0.5f;
		yield return new WaitForSeconds(0.3f);
		FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>()
			.m_AmplitudeGain = 0;
	}
}
