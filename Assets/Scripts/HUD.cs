using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Chest;

public class HUD : MonoBehaviour
{
	static private HUD _instance;

	[SerializeField]
	private Text scoreLabel;

	[SerializeField]
	private Slider healthBar;

	[SerializeField]
	private GameObject inventoryWindow;

	[SerializeField]
	private InventoryItem InventoryItemPrefab;

	[SerializeField]
	private Transform InventoryContainer;

	[SerializeField]
	private Text damageValue;

	[SerializeField]
	private Text speedValue;

	[SerializeField]
	private Text healthValue;


	public static HUD Instance
	{
		get
		{
			return _instance;
		}
	}

		private void Awake()
	{
			_instance = this;
	}

	private int Score
	{
		get
		{
			return Score;
		}
		set
		{
			if(value !=Score)
			{
				Score = value;
				HUD.Instance.SetScore(Score.ToString);
			}
		}
	}


	public Slider HealthBar { get => healthBar; set => healthBar = value; }
	public Text DamageValue { get => damageValue; set => damageValue = value; }
	public Text SpeedValue { get => speedValue; set => speedValue = value; }
	public Text HealthValue { get => healthValue; set => healthValue = value; }

	private void SetScore(Func<string> toString)
	{
		throw new NotImplementedException();
	}

	public void SetScore(string scoreValue)
	{
		scoreLabel.text = scoreValue;
	}

	public void ShowWindow(GameObject window)
	{
		window.GetComponent<Animator>().SetBool("Open", true);
		GameController.Instance.State = GameController.GameState.Pause;
	}

	public void CloseWindow(GameObject window)
	{
		window.GetComponent<Animator>().SetBool("Open", false);
		GameController.Instance.State = GameController.GameState.Play;
	}

	public InventoryItem AddNewInventoryItem(CrystalType crystalType, int amount)
	{
		InventoryItem newItem = Instantiate(InventoryItemPrefab) as InventoryItem;

		newItem.transform.SetParent(InventoryContainer);
		newItem.Quantity = amount;
		newItem.CrystalType = crystalType;
		return newItem;
	}

	public void UpdateCharacterValues(float newHealth, float newSpeed, float newDamage)
	{
		healthValue.text = newHealth.ToString();
		speedValue.text = newSpeed.ToString();
		damageValue.text = newDamage.ToString();
	}
}
