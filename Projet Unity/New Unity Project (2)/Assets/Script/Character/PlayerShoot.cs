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
		Instantiate(bullet, transform.position, Quaternion.LookRotation(Input.mousePosition));
		Debug.Log("Shoot !");
	}
}
