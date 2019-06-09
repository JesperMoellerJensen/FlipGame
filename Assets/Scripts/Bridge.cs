using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : Activateable
{
	public bool Active
	{
		get
		{
			return _active;
		}
		set
		{
			_active = value;
			SetBridge(value);
		}
	}
	public LayerMask LayerMask;
	public Transform Sprite;
	public float BridgeHeight;
	public float ActivationSpeed;
	public bool InvertDirecition;

	[SerializeField]
	private bool _active;
	private BoxCollider2D _boxCollider;

	private void Awake()
	{
		_boxCollider = GetComponent<BoxCollider2D>();
		SetBridge(_active);
	}

	private void Update()
	{
		if (_active)
		{
			MakeBridge();
		}
	}

	private void MakeBridge()
	{
		int dir = InvertDirecition ? -1 : 1;
		RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right*dir/50, transform.right * dir, 100, LayerMask);

		if (hit)
		{
			float distanceLerp = Mathf.MoveTowards(_boxCollider.size.x, hit.distance, ActivationSpeed * Time.deltaTime);
			
			_boxCollider.size = new Vector2(distanceLerp, BridgeHeight);
			_boxCollider.offset = new Vector2(distanceLerp * dir / 2, 0);
			Sprite.localScale = new Vector2(distanceLerp, BridgeHeight);
			Sprite.localPosition = new Vector2(distanceLerp * dir / 2, 0);
		}
	}

	private void SetBridge(bool active)
	{
		_boxCollider.enabled = active;
		Sprite.GetComponent<SpriteRenderer>().enabled = active;

		if(active == false)
		{
			_boxCollider.size = new Vector2(1, BridgeHeight);
			_boxCollider.offset = new Vector2(0, 0);
			Sprite.localScale = new Vector2(1, BridgeHeight);
			Sprite.localPosition = new Vector2(0, 0);
		}
	}

	public override void SetActive(bool active)
	{
		Active = active;
	}
}
