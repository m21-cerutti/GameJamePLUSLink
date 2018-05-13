using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : CharacterObj {

	public float invulnerability;
	float timeinv;
	public static int nbEnemies;
	GameObject[] enemies;
	public GameObject bulle;
	float waitBulle;
	string[] phrases;

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

	void Start ()
	{
		rend = GetComponent<SpriteRenderer>();
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		nbEnemies = enemies.Length;
		waitBulle = 45f;
		phrases = new string[] { "CREVEZ !!" , "LAISSEZ-MOI BOSSER !" , "NE ME TOUCHEZ PAS !"};
	}
	
	// Update is called once per frame
	void Update ()
	{
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

		if (waitBulle > 0)
			waitBulle -= Time.deltaTime;
		else
		{
			StartCoroutine(displayBulle(phrases[Random.Range(0, phrases.Length)]));
			waitBulle = 45;
		}
	}

	IEnumerator displayBulle(string phrase)
	{
		bulle.GetComponentInChildren<TextMesh>().text = phrase;
		bulle.SetActive(true);
		yield return new WaitForSeconds(4f);
		bulle.GetComponentInChildren<TextMesh>().text = "";
		bulle.SetActive(false);
	}
}
