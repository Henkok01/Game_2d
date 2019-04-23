using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestructable
{
	void Hit(float damage);
	void Die();
	float Health { get; set; }
	float MaxHealth { get; }
}
