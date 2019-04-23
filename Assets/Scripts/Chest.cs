using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour

{
	public CrystalType content;

	private int amount;

	public enum CrystalType { Random, Red, Green, Blue }
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		Knight knight = collider.gameObject.GetComponent<Knight>();
		if(knight != null)
		{
			if( content == CrystalType.Random)
			{
				content = (CrystalType)Random.Range(1, 4);

				if(amount == 0)
				{
					amount = Random.Range(1, 6);
				}
			}

			GameController.Instance.AddNewInventoryItem(content, amount);

			Destroy(gameObject);
		}
	}

}
