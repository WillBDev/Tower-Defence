using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour {
 
	private Animator animator;
	public float speed = 0.08f;
	public Vector3 pos;
	
	void Start()
	{
		animator = this.GetComponent<Animator>();
		pos = transform.position;
	}
 
	void Update()
	{
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		if (vertical > 0)
		{
			animator.SetInteger("direction", 2);
			pos += new Vector3(0,speed, 0);
		}
		else if (vertical < 0)
		{
			animator.SetInteger("direction", 0);
			pos += new Vector3(0,-speed, 0);
		}
		else if (horizontal > 0)
		{
			animator.SetInteger("direction", 1);
			pos += new Vector3(speed,0, 0);
		}
		else if (horizontal < 0)
		{
			animator.SetInteger("direction", 3);
			pos += new Vector3(-speed ,0, 0);
		}
		/*var move = new Vector3(horizontal, vertical, 0);
		transform.position += move * speed * Time.deltaTime;*/
		transform.position = pos;
	}
}