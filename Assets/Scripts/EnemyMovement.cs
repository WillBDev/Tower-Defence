using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
	GameObject player;               // Reference to the player's position.
	GameObject laser;
	int playerHealth=10;      // Reference to the player's health.
	public int startingHealth=10;        // Reference to this enemy's health.  
	public int currentHealth=10;
	public float Speed = 0.8f;
	private Image image;
	void Awake ()
	{
		// Set up the references.
		player = GameObject.Find("Character");
		image = GameObject.Find("DamageImage").GetComponent<Image>();
		laser = GameObject.Find ("Projectile(Clone)");
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
	public void TakeDamage(){
		currentHealth--;
		print (currentHealth);
		if (currentHealth < 1)
			Destroy (gameObject);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		if (col.gameObject.tag == "Bullet") {
			print ("HIT!");
			Destroy (col.gameObject);
			TakeDamage ();
		}
	}
}