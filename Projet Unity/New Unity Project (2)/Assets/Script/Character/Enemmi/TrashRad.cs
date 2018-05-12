using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRad : CharacterObj {

	public PlayerMotor player = null;

	void Update()
	{
		if (player != null)
		{
			player.life -= (int)(damage * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			player = col.gameObject.GetComponent<PlayerMotor>();
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			player = null;
		}
	}
}
