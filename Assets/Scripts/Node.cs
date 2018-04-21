using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Point GridPosition { get; private set; }

	public TileScript TileRef {get;private set;}

	public Node(TileScript tileRef)
	{
		this.TileRef = tileRef;
		this.GridPosition = tileRef.GridPosition;
	}
}
