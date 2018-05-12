using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject bullet;
	public float speed = 10f;

	private bool shoot;
	
	void Start ()
	{
		
	}
	
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
		Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized * speed;
		Debug.Log("Shoot !");
	}
}
