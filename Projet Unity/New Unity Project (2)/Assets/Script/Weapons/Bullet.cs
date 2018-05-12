using UnityEngine;

public class Bullet : MonoBehaviour
{

	void Start()
	{
		
	}

	void FixedUpdate()
	{
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Destroy(gameObject);
	}
}
