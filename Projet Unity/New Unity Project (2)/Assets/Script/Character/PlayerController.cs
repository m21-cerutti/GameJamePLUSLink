using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D player;

	public float speed = 1f;

	private float vertical;
	private float horizontal;
	
	void Start ()
	{
		player = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		vertical = Input.GetAxis("Vertical");
		horizontal = Input.GetAxis("Horizontal");
	}

	void FixedUpdate ()
	{
		player.velocity = new Vector2(horizontal, vertical) * speed;
	}
}
