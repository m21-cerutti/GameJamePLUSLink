using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public GameObject bullet;

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
		Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().velocity = new Vector2(Input.mousePosition.x, Input.mousePosition.y).normalized;
		Debug.Log("Shoot !");
	}
}
