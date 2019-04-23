using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	static private GameController _instance;

	private GameState state;

	private int score;

	[SerializeField]
	private int dragonHitScore = 10;

	[SerializeField]
	private int dragonKillScore = 50;

	[SerializeField]
	private float maxHealth;

	[SerializeField]
	private List<InventoryItem> inventory;

	[SerializeField]
	private Knight knight;


	public enum GameState
	{
		Play,
		Pause
	}

	public delegate void InventoryUsedCallback(InventoryItem item);

	public static GameController Instance
	{
		get
		{
			if(_instance == null)
			{
				GameObject gameController = Instantiate(Resources.Load("GameController")) as GameObject;
				_instance = gameController.GetComponent<GameController>();
			}

			return _instance;
		}
	}

	public GameState State
	{
		get
		{
			return state;
		}
		set
		{
			if(value == GameState.Play)
			{
				Time.timeScale = 1.0f;
			}
			else
			{
				Time.timeScale = 0.0f;
			}
			state = value;
		}
	}

	public int Score
	{
		get
		{
			return score;
		}
		set
		{
			score = value;
			
			HUD.Instance.SetScore(score.ToString());
		}
	}

	public float MaxHealth { get => maxHealth; set => maxHealth = value; }
	public Knight Knight { get => knight; set => knight = value; }

	private void Awake()
	{
		if(_instance == null)
		{
			_instance = this;
		}
		else
		{
			if(_instance != this)
			{
				Destroy(gameObject);
				return;
			}
		}

		inventory = new List<InventoryItem>();

		DontDestroyOnLoad(gameObject);

		state = GameState.Play;

		Score = 12;
	}

	void Start()
	{
		HUD.Instance.HealthBar.maxValue = maxHealth;
		HUD.Instance.HealthBar.value = maxHealth;
		HUD.Instance.SetScore(Score.ToString());

		// GameController.Instance.Knight = this;

		HUD.Instance.UpdateCharacterValues(MaxHealth, knight.speed, knight.Damage);
	}

	public void Hit(IDestructable victim)
	{
		if(victim.GetType() == typeof(Dragon))
		{
			if(victim.Health > 0)
			{
				Score += dragonHitScore;
			}
			else
			{
				Score += dragonKillScore;
			}
		}
		else if (victim.GetType() == typeof(Knight))
		{
			HUD.Instance.HealthBar.value = victim.Health;
		}
	}

	public void AddNewInventoryItem(Chest.CrystalType type, int amount)
	{
		InventoryItem newItem = HUD.Instance.AddNewInventoryItem(type, amount);
		InventoryUsedCallback callback = new InventoryUsedCallback(InventoryItemUsed);
		newItem.Callback = callback;
		inventory.Add(newItem);

		// newItem.gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => InventoryItemUsed(newItem));
	}

	public void InventoryItemUsed(InventoryItem item)
	{
		switch (item.CrystalType)  //что мы проверяем
		{
			case Chest.CrystalType.Blue: //если то, что мы проверяем, равно CrystallType.Blue  //сделать то, что должны делать синие кристаллы
				knight.Speed += item.Quantity / 10f;
				break;

			case Chest.CrystalType.Red:
				knight.Damage += item.Quantity / 10f;
				break;

			case Chest.CrystalType.Green:
				maxHealth += item.Quantity / 10f;
				knight.Health = maxHealth;
				HUD.Instance.HealthBar.maxValue = maxHealth;
				HUD.Instance.HealthBar.value = maxHealth;
				break;

			default:
				Debug.LogError("Wrongcrystal type!");
				break;
		}
		inventory.Remove(item);  // удаляем ссылку на предмет инвентаря из массива
		Destroy(item.gameObject); //уничтожаем геймобджект предмета инвентаря

		HUD.Instance.UpdateCharacterValues(knight.Health, knight.speed, knight.Damage);
	}

}
