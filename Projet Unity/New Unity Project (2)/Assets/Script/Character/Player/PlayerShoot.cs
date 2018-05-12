﻿using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject bullet;
	public float speed = 10f;

	public enum Weapons
	{
		MP5,
		MachineGun,
		RocketLauncher,
		C4
	};

	private bool shoot;
	
	void Update ()
	{
		shoot = Input.GetMouseButtonDown(0);
	}

	void FixedUpdate()
	{
		if(shoot)
			Shoot();
	}

	void Shoot()
	{
		Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * speed;
	}
}
