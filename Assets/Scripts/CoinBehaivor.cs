using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CoinBehaivor : MonoBehaviour
{
	private LevelManager _manager;
	private Vector2 _startPos;
	private float _offset;
	private float _speed;

	void Start()
	{
		_manager = FindObjectOfType<LevelManager>();
		_startPos = transform.position;
		_offset = Random.Range(-10, 10);
		_speed = Random.Range(1.8f, 2.2f);
	}

	void LateUpdate()
	{
		float sineY = Mathf.Sin((Time.time + _offset) * _speed);
		transform.position = _startPos + new Vector2(0, sineY * 0.3f);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Player"))
		{
			_manager.PickedUpCoin();
			Destroy(gameObject);
		}
	}
}
