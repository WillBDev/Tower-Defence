using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour {
 
	private Animator animator;
	public float speed = 0.08f;
	public Vector3 pos;
	public GameObject projectile;
	
	void Start()
	{
		projectile = GameObject.Find("Projectile");
		animator = this.GetComponent<Animator>();
		pos = transform.position;
	}
 
	void FixedUpdate()
	{
		if (Input.GetKeyDown("space"))
		{
	
			GameObject bulletInstance = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as GameObject;
			bulletInstance.GetComponent<Rigidbody2D>().velocity = transform.forward * 10;
			Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
		}
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		if (vertical > 0)
		{
			animator.SetInteger("direction", 2);
			pos += new Vector3(0,speed, 0);
		}
		if (vertical < 0)
		{
			animator.SetInteger("direction", 0);
			pos += new Vector3(0,-speed, 0);
		}
		if (horizontal > 0)
		{
			animator.SetInteger("direction", 1);
			pos += new Vector3(speed,0, 0);
		}
		if (horizontal < 0)
		{
			animator.SetInteger("direction", 3);
			pos += new Vector3(-speed ,0, 0);
		}
		/*var move = new Vector3(horizontal, vertical, 0);
		transform.position += move * speed * Time.deltaTime;*/
		transform.position = pos;
	}
}