using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotionController : MonoBehaviour {
 
	private Animator animator;
	public float speed = 0.08f;
	public Vector3 pos;
	public GameObject projectile;
	public float pSpeed = 100;
	public float health = 10;

	public Text gameOverText;

	public List<GameObject> Projectiles = new List <GameObject>();
	public List<String> Directions = new List <String> ();

	public String direction;
	
	void Start()
	{
		projectile = GameObject.Find("Projectile");
		animator = this.GetComponent<Animator>();
		pos = transform.position;
		gameOverText.text = "";
	}
 
	void FixedUpdate()
	{

		/*if (Input.GetMouseButtonDown (0)) {
			GameObject bulletInstance = Instantiate (projectile, transform.position, Quaternion.Euler (new Vector3 (0, 0, 1))) as GameObject;
			bulletInstance.GetComponent<Rigidbody2D> ().velocity = transform.forward * 10;
			Physics2D.IgnoreCollision (bulletInstance.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
		}*/
		var vertical = Input.GetAxis ("Vertical");
		var horizontal = Input.GetAxis ("Horizontal");
		if (vertical > 0) {
			animator.SetInteger ("direction", 2);
			pos += new Vector3 (0, speed, 0);
			direction = "up";
		}
		if (vertical < 0) {
			animator.SetInteger ("direction", 0);
			pos += new Vector3 (0, -speed, 0);
			direction = "down";
		}
		if (horizontal > 0) {
			animator.SetInteger ("direction", 1);
			pos += new Vector3 (speed, 0, 0);
			direction = "left";
		}
		if (horizontal < 0) {
			animator.SetInteger ("direction", 3);
			pos += new Vector3 (-speed, 0, 0);
			direction = "right";
		}
		/*var move = new Vector3(horizontal, vertical, 0);
		transform.position += move * speed * Time.deltaTime;*/
		transform.position = pos;

	}
	void Update(){
		if (Input.GetKeyDown("space"))
		{
			GameObject laser = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
			Projectiles.Add (laser);
			Directions.Add (direction);
		}
		for (int i = 0; i < Projectiles.Count; i++) {
			GameObject goBullet = Projectiles[i];
			if (goBullet != null) {
				switch (Directions[i]) {
				case "up":
					goBullet.transform.Translate (new Vector3 (0, 3) * Time.deltaTime * pSpeed);
					break;
				case "down":
					goBullet.transform.Translate (new Vector3 (0, -3) * Time.deltaTime * pSpeed);
					break;
				case "left":
					goBullet.transform.Translate (new Vector3 (3, 0) * Time.deltaTime * pSpeed);
					break;
				case "right":
					goBullet.transform.Translate (new Vector3 (-3, 0) * Time.deltaTime * pSpeed);
					break;
				default:
					DestroyObject (goBullet);
					Projectiles.Remove (goBullet);
					Directions.RemoveAt (i);
					break;
				}
				Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint (goBullet.transform.position);
				if (bulletScreenPos.y >= Screen.height || bulletScreenPos.y <= 0 || bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0) {
					DestroyObject (goBullet);
					Projectiles.Remove (goBullet);
					Directions.RemoveAt (i);
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			print ("DAMAGED!");
			health--;
			print (health);
			if (health < 1) {
				gameOverText.text = "GAME OVER";
				Time.timeScale = 0; //freezes game
			}
		}
	}
}