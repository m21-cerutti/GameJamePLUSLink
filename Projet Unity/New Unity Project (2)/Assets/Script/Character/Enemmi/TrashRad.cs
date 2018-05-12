using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRad : CharacterObj {

	public PlayerMotor player;

	void Update()
	{
		if (player != null)
		{
			player.life -= damage;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "Player")
		{
			player = col.gameObject.GetComponent<PlayerMotor>();
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.name == "Player")
		{
			player = null;
		}
	}
}
