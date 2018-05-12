using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : CharacterObj {

	void Update()
	{
		
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		foreach (ContactPoint2D pt in coll.contacts)
		{
			if (pt.otherCollider.name == "Player")
			{
				pt.otherCollider.SendMessage("takeDamage",damage);
			}
		}
		
	}

}
