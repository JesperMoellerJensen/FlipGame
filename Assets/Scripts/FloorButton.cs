using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
	public Transform Sprite;

	[SerializeField]
	private bool _active;
	private BoxCollider2D _boxCollider;
	private bool _onCooldown;

	[SerializeField]
	public List<Activateable> Entities;

	private void Awake()
	{
		_boxCollider = GetComponent<BoxCollider2D>();
		if(_active)
		{
			SetActive();
		}
		else
		{
			SetNonActive();
		}
	}

	private void Toggle()
	{
		if (_onCooldown) return;


		_active = !_active;
		_onCooldown = true;
		Invoke("Cooldown", 0.8f);
		foreach (var entity in Entities)
		{
			entity.SetActive(_active);
		}

		if (_active)
		{
			SetActive();
		}
		else
		{
			SetNonActive();
		}
	}

	private void Cooldown()
	{
		_onCooldown = false;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Toggle();
	}

	public void SetActive()
	{
		Sprite.localScale = new Vector2(1,0.15f);
		Sprite.localPosition = new Vector2(0, -0.425f);
		_boxCollider.size = new Vector2(1, 0.15f);
		_boxCollider.offset = new Vector2(0, -0.425f);

	}
	public void SetNonActive()
	{
		Sprite.localScale = new Vector2(1, 0.3f);
		Sprite.localPosition = new Vector2(0, -0.35f);
		_boxCollider.size= new Vector2(1, 0.3f);
		_boxCollider.offset = new Vector2(0, -0.35f);
	}
}
