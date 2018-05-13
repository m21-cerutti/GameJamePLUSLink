using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : CharacterObj {

	public float invulnerability;
	float timeinv;

	SpriteRenderer rend;

	public new void takeDamage(int dam)
	{
		//Debug.Log(this.gameObject.name + " " + life);
		if (timeinv <= 0 )
		{
			base.takeDamage(dam);
			timeinv = invulnerability;
		}
	}

	public override void die()
	{
		HUDManager.Instance.GameOver();
	}

	void Start () {
		rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeinv > 0)
		{
			rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.5f);
			timeinv -= Time.deltaTime;
		}
		else
		{
			if (rend.color.a < 0.9f)
			{
				rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 1);
			}
		}
	}
}
