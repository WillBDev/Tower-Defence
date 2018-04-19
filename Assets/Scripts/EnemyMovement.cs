using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	int playerHealth=10;      // Reference to the player's health.
	int enemyHealth=10;        // Reference to this enemy's health.             // Reference to the nav mesh agent.
	public float Speed = 0.8f;

	void Awake ()
	{
		// Set up the references.
		player = GameObject.Find("Character").transform;
		/*playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();*/
	}


	void Update ()
	{
		// If the enemy and the player have health left...
		Vector2 velocity = new Vector2((transform.position.x - player.position.x) * Speed, (transform.position.y - player.position.y) * Speed);
		GetComponent<Rigidbody2D>().velocity = -velocity;
	} 
}