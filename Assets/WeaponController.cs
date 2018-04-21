using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
	public GameObject projectile;
	public bool applyForce = true;
	public LineRenderer line;
	public int speed;
	public Vector3 shootFromHere;

	void Start()
	{
		projectile = GameObject.Find("Projectile");
		line = gameObject.AddComponent<LineRenderer>();
	}

	private void Update()
	{
		shootFromHere = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z+1);
		if (Input.GetMouseButtonDown(0))
		{
			SpawnBullet();
		}
	}

	void SpawnBullet()
	{
		GameObject clone;
		clone = Instantiate(projectile, shootFromHere, Quaternion.identity) as GameObject;
		clone.gameObject.GetComponent<Rigidbody2D>().velocity = Camera.main.transform.forward * 350;
	}
}
