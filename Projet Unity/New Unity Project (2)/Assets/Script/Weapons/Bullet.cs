using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;
	public float damage = 2f;

	void Start()
	{
		GetComponent<Rigidbody2D>().velocity = (Vector2)Input.mousePosition.normalized * speed;
	}

	void FixedUpdate()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			other.SendMessage("takeDamage", damage);
			Destroy(this);
		}
	}
}
