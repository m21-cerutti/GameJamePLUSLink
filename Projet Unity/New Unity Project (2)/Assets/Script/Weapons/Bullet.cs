using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;
	public float damage = 2f;

	private Rigidbody2D rb;
	private Vector2 mousePos;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}

	void FixedUpdate()
	{
		rb.AddForce(mousePos.normalized * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		switch(other.tag)
		{
			case "Player":
				return;
			case "Enemy":
				other.SendMessage("takeDamage", damage);
				break;
		}
		Destroy(this);
	}
}
