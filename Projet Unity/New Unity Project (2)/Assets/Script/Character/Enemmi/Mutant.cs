using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : CharacterObj {

	Vector2 move;
	bool follow_player;

	void Update()
	{
		if (follow_player)
		{

		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		foreach (ContactPoint2D pt in coll.contacts)
		{

			if (pt.otherCollider.tag == "Player")
			{
				pt.otherCollider.SendMessage("takeDamage",damage);
			}
		}
		
	}

}
