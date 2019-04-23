using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creature : MonoBehaviour, IDestructable
{
	[SerializeField]
	protected Animator animator;

	[SerializeField]
	protected new Rigidbody2D rigidbody;

	private float health;

	[SerializeField]
	private float maxHealth = 100;

	[SerializeField]
	public float speed;

	public float Health { get => health; set => health = value; }
	public float MaxHealth { get => maxHealth; }

	private void Awake()
	{
		health = maxHealth;
	}

	public void Hit(float damage)
	{
		Health -= damage;
		GameController.Instance.Hit(this);

		if(Health <= 0)
		{
			Die();
		}

	}

	public void Die()
	{
		Destroy(gameObject);

		Knight knight = GetComponent<Knight>();
		if (knight != null)
		{
				SceneManager.LoadScene(0);
		}
	
		
	}
}
