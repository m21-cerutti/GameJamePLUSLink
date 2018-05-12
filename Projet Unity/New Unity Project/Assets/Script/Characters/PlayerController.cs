using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody2D player;

	public float speed = 5f;
	
	void Start ()
	{
		player = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
	{
		player.AddRelativeForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed);
	}
}
