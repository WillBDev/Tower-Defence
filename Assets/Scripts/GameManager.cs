using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

	[SerializeField]
	private GameObject inGameMenu;

	public ObjectPool Pool { get; set; }

	private int wave=0;

	[SerializeField]
	private Text waveTxt;

	[SerializeField]
	private GameObject waveBtn;

	private List<Monster> activeMonsters = new List<Monster>();

	public bool WaveActive
	{
		get{
			return activeMonsters.Count > 0;
		}
	}

	private void Awake()
	{
		Pool = GetComponent<ObjectPool> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void ShowIngameMenu()
	{
		inGameMenu.SetActive (!inGameMenu.activeSelf);
	}

	public void StartWave()
	{
		wave++;

		waveTxt.text = string.Format ("Wave: <color=lime>{0}</color>", wave);

		StartCoroutine (SpawnWave ());
		 
		//waveBtn.SetActive (false);
	}
		
	private IEnumerator SpawnWave()
	{
		for (int i = 0; i < wave; i++) 
		{
			int monsterIndex = Random.Range (0, 5);

			string type = string.Empty;

			switch (monsterIndex) {
			case 0:
				type = "Zombie1";
				break;
			case 1:
				type = "Zombie2";
				break;
			case 2:
				type = "Zombie3";
				break;
			case 3:
				type = "Zombie4";
				break;
			case 4:
				type = "Zombie5";
				break;
			}

			Monster monster = Pool.GetObject (type).GetComponent<Monster>();
			monster.Spawn ();

			activeMonsters.Add (monster);

			yield return new WaitForSeconds (2.5f);
		}
	}

	//public void RemoveMonster(Monster monster)
	//{
	//	activeMonsters.Remove (monster);
	//
	//	if (!WaveActive) 
	//	{
	//		waveBtn.SetActive (true);
	//	}
	//}
}
