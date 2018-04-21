using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
	public GameObject projectile;
	public bool applyForce = true;
	public LineRenderer line;
	public float speed;
	public Vector3 shootFromHere;

	private List<GameObject> Projectiles = new List<GameObject> ();

	void Start()
	{
		projectile = GameObject.Find("Projectile");
		line = gameObject.AddComponent<LineRenderer>();
		speed = 3;
	}

	private void Update()
	{
		/*shootFromHere = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z+1);
		if (Input.GetMouseButtonDown(0))
		{
			GameObject laser = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
			Projectiles.Add (laser);
		}
		for (int i = 0; i < Projectiles.Count; i++) {
			GameObject goBullet = Projectiles [i];
			if (goBullet != null) {
				goBullet.transform.Translate (new Vector3 (0, 1) * Time.deltaTime * speed);
			}
		}*/
	}
}
