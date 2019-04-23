using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Creature, IDestructable
{

	private bool onStairs;

	[SerializeField]
	private float jumpForce;

	private bool onGround = true;

	[SerializeField]
	private Transform GroundCheck;

	[SerializeField]
	private float stairsSpeed;

	[SerializeField]
	private Transform attackPoint;

	[SerializeField]
	private float attackRange;

	[SerializeField]
	public float Damage;

	[SerializeField]
	private float hitDelay;

	public bool OnStairs
	{
		get
		{
			return onStairs;
		}
		set
		{
			onStairs = value;
		}
	}

	public float Speed { get; internal set; }

	private void Start()
	{
		Health = GameController.Instance.MaxHealth;
	}

	void FixedUpdate()
	{
		onGround = CheckGround();

		animator.SetBool("Jump", !onGround);

		animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		if (Input.GetButtonDown("Fire1"))
		{
			animator.SetTrigger("attack");
			//Attack();
			Invoke("Attack", hitDelay);
		}

		Vector2 velocity = rigidbody.velocity;

		velocity.x = Input.GetAxis("Horizontal") * speed;
		rigidbody.velocity = velocity;

		if (Input.GetButtonDown("Jump") && onGround)
		{
			rigidbody.AddForce(Vector2.up * jumpForce);
		}

		if (transform.localScale.x < 0)
		{
			if (Input.GetAxis("Horizontal") > 0)
			{
				transform.localScale = Vector3.one;
			}
		}
		else
		{
			if (Input.GetAxis("Horizontal") < 0)
			{
				transform.localScale = new Vector3(-1, 1, 1);
			}
		}

		if (onStairs)
		{
			var velocity2 = rigidbody.velocity;
			velocity.y = Input.GetAxis("Vertical") * stairsSpeed;
			rigidbody.velocity = velocity;


		}
	}

	private bool CheckGround()
	{
		RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, GroundCheck.position);
		for (int i = 0; i < hits.Length; i++)
		{
			if (!GameObject.Equals(hits[i].collider.gameObject, gameObject))
			{
				return true;
			}
		}
		return false;

	}

	private void Attack()
	{
		Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

		for(int i = 0; i < hits.Length; i++)
		{
			if(!GameObject.Equals(hits[i].gameObject, gameObject))
			{
				IDestructable destructable = hits[i].gameObject.GetComponent<IDestructable>();

				if(destructable != null)
				{
					Debug.Log("Hit" + destructable.ToString());

					destructable.Hit(Damage);

					break;
				}
			}
		}
	}
}
