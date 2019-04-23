using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Chest;

public class InventoryItem : MonoBehaviour
{
	[SerializeField]
	private Text label;

	[SerializeField]
	private Text count;

	[SerializeField]
	private Image image;

	public CrystalType crystalType;

	private float quantity;

	[SerializeField]
	private List<Sprite> sprites;

	private GameController.InventoryUsedCallback callback;

	private void Start()
	{

		label.text = crystalType.ToString();
		count.text = quantity.ToString();

		string spriteNameToSearch = crystalType.ToString().ToLower();
		image.sprite = sprites.Find( x => x.name.Contains(spriteNameToSearch));

		label.text = spriteNameToSearch;
		count.text = quantity.ToString();

		gameObject.GetComponent<Button>().onClick.AddListener(() => Callback(this));
	}

	/*public void ButtonClick()
	{
		GameController.Instance.InventoryItemUsed(this);
	}*/




	public CrystalType CrystalType { get => crystalType; set => crystalType = value; }

	public float Quantity { get => quantity; set => quantity = value; }

	public GameController.InventoryUsedCallback Callback { get => callback; set => callback = value; }
}
