using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : CharacterObj {

	
	Vector2 startPosition;
	public float speed;


	public GameObject player;
	Rigidbody2D rb;
	public bool follow_player;

	RaycastHit2D hit;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		startPosition = transform.position;

	}
	void Update()
	{
		if (follow_player && player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
		else if (follow_player)
		{
			Debug.Log("follow");
			Vector2 movedir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
			computePathFinding();
			//rb.velocity = .normalized * speed;
		}
	}

	Vector2 computePathFinding()
	{
		//Choisis que le layer 8
		LayerMask layerMask = 1 << 9;
		//Inverse
		//layerMask = ~layerMask;
		//Debug.DrawLine(player.transform.position, transform.position,  Color.green, Time.deltaTime, false);
		RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, layerMask );
		if (hit.collider != null)
		{
			Debug.Log("hit "+hit.collider.gameObject.name);
			Debug.DrawLine(transform.position, hit.point, Color.green, Time.deltaTime, false);
		}
		return Vector2.zero;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		foreach (ContactPoint2D pt in coll.contacts)
		{
			if (pt.collider.tag == "Player")
			{
				Debug.Log("Atackkk");
				pt.collider.gameObject.SendMessage("takeDamage",damage);
			}
		}
		
	}
}
