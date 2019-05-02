using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
	public float MaxZoom;
	public float MinZoom;
	[Range(0f,0.99f)]
	public float ZoomSmooth;

	private Rigidbody2D _playerBody;
	private CinemachineVirtualCamera _camera;

	private void Start()
	{
		_playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		_camera = GetComponent<CinemachineVirtualCamera>();
	}

	private void LateUpdate()
	{
		if (_playerBody == null || _camera == null)
		{
			return;
		}

		_playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

		float zoom = CustomExtensions.Remap(_playerBody.velocity.magnitude, 0, 40, MinZoom, MaxZoom);
		float zoomDamp = Mathf.Lerp(_camera.m_Lens.OrthographicSize, zoom, (1-ZoomSmooth)/100);
		_camera.m_Lens.OrthographicSize = zoomDamp;
	}
}
