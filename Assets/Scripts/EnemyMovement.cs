using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
	GameObject player;               // Reference to the player's position.
	int playerHealth=10;      // Reference to the player's health.
	int enemyHealth=10;        // Reference to this enemy's health.             // Reference to the nav mesh agent.
	public float Speed = 0.8f;
	private Image image;
	void Awake ()
	{
		// Set up the references.
		player = GameObject.Find("Character");
		image = GameObject.Find("DamageImage").GetComponent<Image>();
		/*playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();*/
	}


	void Update ()
	{
		Vector2 velocity = new Vector2((transform.position.x - player.transform.position.x) * Speed, (transform.position.y - player.transform.position.y) * Speed);
		bool intersect = (Math.Round(transform.position.x) == Math.Round(player.transform.position.x) &&
		                  Math.Round(transform.position.y) == Math.Round(player.transform.position.y));
		if (intersect)
		{
			image.color = Color.red;
			image.canvasRenderer.SetAlpha(0.5f);
			image.CrossFadeAlpha(0.0f , 0.5f, false);
		}
		GetComponent<Rigidbody2D>().velocity = -velocity;
	} 
}