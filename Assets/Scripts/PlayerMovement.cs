using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
	public List<AudioClip> AudioClips = new List<AudioClip>();
	public LayerMask GroundMask;

	[SerializeField] private float _speed;
	[SerializeField] private float _jumpForce;

	private Rigidbody2D _body;
	private float _moveDir;
	private int _gravityDir = 1;


	void Start()
	{
		_body = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		_moveDir = Input.GetAxisRaw("Horizontal");

		if (Input.GetButtonDown("Jump") && CheckIfOnGround())
		{
			Jump();
		}
	}

	void FixedUpdate()
	{
		_body.velocity = new Vector2(_moveDir * _speed, _body.velocity.y);
		CheckIfOnGround();
	}

	public void ExitPortal(float InVelY)
	{
		_body.velocity = new Vector2(_body.velocity.x, InVelY);
		_gravityDir *= -1;
		_body.gravityScale *= -1;

	}
	private void Jump()
	{
		_body.velocity = new Vector2(_body.velocity.x, _jumpForce * _gravityDir);
	}

	public bool CheckIfOnGround()
	{
		Vector3 offsetLeft = new Vector3(-0.48f, 0.98f * -_gravityDir);
		Vector3 originLeft = transform.position + offsetLeft;

		Vector3 offsetRight = new Vector3(0.48f, 0.98f * -_gravityDir);
		Vector3 originRight = transform.position + offsetRight;

		Vector2 direction = Vector2.down * _gravityDir;

		RaycastHit2D hitLeft = Physics2D.Raycast(originLeft, direction, 0.1f, GroundMask);
		RaycastHit2D hitRight = Physics2D.Raycast(originRight, direction, 0.1f, GroundMask);

		if (hitLeft || hitRight)
		{
			return true;
		}

		return false;
	}
}
