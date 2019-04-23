using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Knight knight = collision.gameObject.GetComponent<Knight>();

		if(knight != null)
		{
			knight.OnStairs = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Knight knight = collision.gameObject.GetComponent<Knight>();

		if (knight != null)
		{
			knight.OnStairs = false;
		}
	}
}
