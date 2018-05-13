using UnityEngine;

public class Bullet : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D other)
	{
		foreach (ContactPoint2D con in other.contacts)
		{
			if (other.collider.tag == "Enemy")
				if (other.collider.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
					other.collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				bulletDamage(other.collider, 2f);
		}
		Destroy(gameObject);

	}
	/*
	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
	*/
	void bulletDamage(Collider2D other, float damage)
	{
		if(other.tag == "Enemy")
			other.SendMessage("takeDamage", damage);
	}

	void explosiveDamage(Collider2D other, float radius, float damage)
	{
		Collider2D[] colliders = new Collider2D[20];
		Physics2D.OverlapCircleNonAlloc(transform.position, radius, colliders, (8 | 10));
		foreach (Collider2D entity in colliders)
		{
			entity.SendMessage("takeDamage", damage);
			Debug.Log(entity.name + " has taken damage !");
		}
	}
}
