using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Portal : MonoBehaviour
{
	private float InVelY;

	void OnTriggerEnter2D(Collider2D collider)
	{
		PlayerMovement playerMovement = collider?.GetComponent<PlayerMovement>();

		if (playerMovement != null)
		{
			Rigidbody2D body = collider.GetComponent<Rigidbody2D>();
			InVelY = body.velocity.y;
			FireParticle(body);
			playerMovement.EnterPortal();
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		PlayerMovement playerMovement = collider?.GetComponent<PlayerMovement>();

		if (playerMovement != null)
		{
			playerMovement.ExitPortal(InVelY);
		}
		InVelY = 0;
	}

	private void FireParticle(Rigidbody2D body)
	{
		var particle = GetComponent<ParticleSystem>();
		var velocity = particle.velocityOverLifetime;

		velocity.x = body.velocity.x;
		velocity.y = body.velocity.y;

		particle.Emit(100);
	}
}
