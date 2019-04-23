using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Creature, IDestructable
{

	[SerializeField]
	private float damage;

	[SerializeField]
	private CircleCollider2D hitCollider;


	void Update()
    {
		var velocity = rigidbody.velocity;
		velocity.x = speed * transform.localScale.x * -1;
		rigidbody.velocity = velocity;

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Knight knight = collision.gameObject.GetComponent<Knight>();

		if (knight != null)
		{
			animator.SetTrigger("attack");
		}
		else
		{
			ChangeDirection();
		}
	}

	private void ChangeDirection()
	{
		if(transform.localScale.x < 0)
		{
			transform.localScale = Vector3.one;
		}
		else
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	private void Attack()
	{
		Vector3 hitPosition = transform.TransformPoint(hitCollider.offset);
		Collider2D[] hits = Physics2D.OverlapCircleAll(hitPosition, hitCollider.radius);

		for (int i = 0; i < hits.Length; i++)
		{
			if (!GameObject.Equals(hits[i].gameObject, gameObject))
			{
				IDestructable destructable = hits[i].gameObject.GetComponent<IDestructable>();

				if (destructable != null)
				{
					destructable.Hit(damage);
				}
			}
		}
	}
}
