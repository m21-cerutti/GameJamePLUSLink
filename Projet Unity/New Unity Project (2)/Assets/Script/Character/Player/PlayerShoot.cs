using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject bullet;
	public float speed = 10f;
	public float cadence = 0.3f;
	private float timer;

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
		shoot = Input.GetMouseButton(0);
	}

	void FixedUpdate()
	{
		if (shoot && timer < 0) {
			Shoot();
			timer = cadence;
		}else if (timer >= 0)
		{
			timer -= Time.deltaTime;
		}
	}

	void Shoot()
	{
		GameObject obj = Instantiate(bullet, transform.position + bullet.transform.position, Quaternion.identity);
		obj.GetComponent<Rigidbody2D>().velocity = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, 
			Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y).normalized * speed;
	}
}
