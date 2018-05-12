using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : CharacterObj {


	public float invulnerability;

	public new void takeDamage(int dam)
	{
		if (invulnerability > 0)
		{
			base.takeDamage(dam);
			invulnerability = 3f;
		}
	}

	public void die()
	{
		destroy();
		HUDManager.Instance.GameOver();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (invulnerability > 0)
		{
			invulnerability -= Time.deltaTime;
		}
	}
}
