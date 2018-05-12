using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRad : CharacterObj {

	public GameObject player = null;
	public bool follow_player;

	void Update()
	{
		if (follow_player && player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
		else if (follow_player)
		{
			player.SendMessage("takeDamage", damage);
		}
	}

}
