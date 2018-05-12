using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : CharacterObj {

	public float invulnerability;
	float timeinv;

	public new void takeDamage(int dam)
	{
		Debug.Log(this.gameObject.name + " " + life);
		if (timeinv < 0 )
		{
			base.takeDamage(dam);
			timeinv = invulnerability;
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
			timeinv -= Time.deltaTime;
		}
	}
}
