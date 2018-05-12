using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float damage = 2f;

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
