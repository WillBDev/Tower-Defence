using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager> {

	[SerializeField]
	private GameObject[] tilePrefabs;

	[SerializeField]
	private Transform map;

	private Point blueSpawn, redSpawn;

	[SerializeField]
	private GameObject bluePortalPrefab;

	[SerializeField]
	private GameObject redPortalPrefab;

	private Stack<Node> path;

	public Portal BluePortal { get; set; }

	public Dictionary<Point, TileScript> Tiles { get; set; }

	public float TileSize
	{
		get {return tilePrefabs[0].GetComponent<SpriteRenderer> ().sprite.bounds.size.x;}
	}

	// Use this for initialization
	void Start () 
	{
		CreateLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void CreateLevel() 
	{
		Tiles = new Dictionary<Point, TileScript> ();

		string[] mapData = new string[] 
		{
			"110111011110000000","010101010010000000","010101010010000000","010101010010000000","010101010010000000","010101010010000000","011101110011000000","000000000000000000"
		};
			
		int mapX = mapData [0].ToCharArray ().Length;
		int mapY = mapData.Length;

		Vector3 maxTile = Vector3.zero;

		Vector3 worldStart = Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height));
		for (int y=0; y<mapY; y++)
		{
			char[] newTiles = mapData [y].ToCharArray ();

			for (int x=0; x<mapX; x++)
			{
				PlaceTile (newTiles[x].ToString(), x, y, worldStart);
			}
		}

		maxTile = Tiles [new Point (mapX - 1, mapY - 1)].transform.position;

		//cameraMovement.SetLimits (maxTile);

		SpawnPortal ();
	}

	private void PlaceTile(string tileType, int x, int y, Vector3 worldStart)
	{
		int tileIndex = int.Parse (tileType);
		TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();

		newTile.Setup (new Point (x, y),new Vector3 (worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0),map);

		Tiles.Add (new Point (x, y), newTile);

	}

	private void SpawnPortal()
	{
		blueSpawn = new Point (0, 0);
		GameObject tmp = (GameObject)Instantiate (bluePortalPrefab, Tiles [blueSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
		BluePortal = tmp.GetComponent<Portal> ();
		BluePortal.name = "BluePortal";

		redSpawn = new Point (12,6);
		Instantiate (redPortalPrefab, Tiles [redSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
	}
}

