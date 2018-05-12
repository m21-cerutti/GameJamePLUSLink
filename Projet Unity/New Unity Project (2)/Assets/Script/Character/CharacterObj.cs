using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterObj : MonoBehaviour {

	public int max_life;
	public int life;
	public int damage;

	public float ratio()
	{
		return (float)(life/ max_life *1f);
	}

	public void takeDamage(int dam)
	{
		
		life -= dam;
	}

	public void destroy()
	{
		Destroy(this);
	}
}
